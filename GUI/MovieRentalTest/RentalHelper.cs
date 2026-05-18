using Microsoft.Data.SqlClient;
using System;

namespace MovieRentalTest
{
    public static class RentalHelper
    {
        public static bool HasActiveMembership(int customerId)
        {
            if (string.IsNullOrEmpty(Database.ConnectionString))
                throw new InvalidOperationException("Database connection string not configured");

            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT TOP 1 m.EndDate 
                      FROM SubscribesTo st
                      JOIN MemberShip m ON st.MemberShipID = m.MemberShipID
                      WHERE st.CustomerID = @customerId
                      ORDER BY m.EndDate DESC", conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);

                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return false;

                DateTime endDate = (DateTime)result;
                return endDate >= DateTime.Today;
            }
        }

        public static void RentMovie(int customerId, int movieId, int quantity, int duration)
        {
            if (string.IsNullOrEmpty(Database.ConnectionString))
                throw new InvalidOperationException("Database connection string not configured");

            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get active membership
                        var membershipCmd = new SqlCommand(
                            @"SELECT TOP 1 st.MemberShipID 
                              FROM SubscribesTo st
                              JOIN MemberShip ms ON st.MemberShipID = ms.MemberShipID
                              WHERE st.CustomerID = @customerId
                              AND ms.Status = 'Active'
                              AND ms.StartDate <= GETDATE()
                              AND ms.EndDate >= GETDATE()
                              ORDER BY ms.EndDate DESC",
                            conn, transaction);
                        membershipCmd.Parameters.AddWithValue("@customerId", customerId);
                        object membershipId = membershipCmd.ExecuteScalar();

                        if (membershipId == null || membershipId == DBNull.Value)
                            throw new Exception("No active membership found for this customer");

                        // Verify stock
                        var stockCmd = new SqlCommand(
                            "SELECT NoOfCopies FROM Movie_Tape WHERE MovieID = @movieId",
                            conn, transaction);
                        stockCmd.Parameters.AddWithValue("@movieId", movieId);
                        int available = (int)stockCmd.ExecuteScalar();

                        if (available < quantity)
                            throw new Exception($"Only {available} copies available. Cannot rent {quantity}.");

                        // Calculate price
                        decimal pricePerDay = GetMoviePrice(movieId, conn, transaction);

                        // Create rental record
                        var rentCmd = new SqlCommand(
                            @"INSERT INTO Rental (
                                MemberShipID, MovieID, RentalDate, 
                                RentalDuration, Quantity, RentalCharge
                              ) VALUES (
                                @membershipId, @movieId, GETDATE(), 
                                @duration, @quantity, @charge
                              )",
                            conn, transaction);

                        rentCmd.Parameters.AddWithValue("@membershipId", membershipId);
                        rentCmd.Parameters.AddWithValue("@movieId", movieId);
                        rentCmd.Parameters.AddWithValue("@duration", duration);
                        rentCmd.Parameters.AddWithValue("@quantity", quantity);
                        rentCmd.Parameters.AddWithValue("@charge", quantity * duration * pricePerDay);

                        rentCmd.ExecuteNonQuery();

                        // Update stock
                        var updateCmd = new SqlCommand(
                            "UPDATE Movie_Tape SET NoOfCopies = NoOfCopies - @quantity WHERE MovieID = @movieId",
                            conn, transaction);
                        updateCmd.Parameters.AddWithValue("@quantity", quantity);
                        updateCmd.Parameters.AddWithValue("@movieId", movieId);
                        updateCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            throw new Exception($"Rental failed and rollback failed: {rollbackEx.Message}");
                        }
                        throw;
                    }
                }
            }
        }

        private static decimal GetMoviePrice(int movieId, SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(
                "SELECT Price_Per_Day FROM Movie_Tape WHERE MovieID = @movieId",
                conn, transaction);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            return (decimal)cmd.ExecuteScalar();
        }
    }
}