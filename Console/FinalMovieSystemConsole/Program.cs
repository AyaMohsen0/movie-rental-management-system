using System;
using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    private static readonly string connectionString = "Server=DESKTOP-HFKRDHF\\SQLEXPRESS;Database=MovieRentalAppDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

    static void Main()
    {
        Console.WriteLine("=== Welcome to Movie Rental App ===");
        while (true)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Register as Customer");
            Console.WriteLine("2. Login as Customer");
            Console.WriteLine("3. Login as Admin");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterCustomer();
                    break;
                case "2":
                    LoginCustomer();
                    break;
                case "3":
                    LoginAdmin();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void RegisterCustomer()
    {
        Console.WriteLine("\n=== Customer Registration ===");
        Console.Write("First Name: ");
        string fname = Console.ReadLine();
        Console.Write("Last Name: ");
        string lname = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        // For simplicity, let's create a basic membership upon registration
        decimal defaultMembershipPrice = 9.99m;
        DateTime membershipStartDate = DateTime.Now;
        DateTime membershipEndDate = DateTime.Now.AddMonths(6); // Example: 6-month basic membership
        string membershipStatus = "Active";
        string membershipType = "Basic";

        string customerInsertQuery = @"
            INSERT INTO Customer (Fname, Lname, UserName, Password, Email, PhoneNumber)
            VALUES (@Fname, @Lname, @UserName, @Password, @Email, @PhoneNumber);
            SELECT SCOPE_IDENTITY();"; // Get the newly inserted CustomerID

        string membershipInsertQuery = @"
            INSERT INTO MemberShip (Price, StartDate, EndDate, Status, Type)
            VALUES (@Price, @StartDate, @EndDate, @Status, @Type);
            SELECT SCOPE_IDENTITY();"; // Get the newly inserted MemberShipID

        string subscribesToInsertQuery = @"
            INSERT INTO SubscribesTo (CustomerID, MemberShipID)
            VALUES (@CustomerID, @MemberShipID)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(customerInsertQuery, conn, transaction);

            try
            {
                cmd.Parameters.AddWithValue("@Fname", fname);
                cmd.Parameters.AddWithValue("@Lname", lname);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password); // In a real app, hash this!
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                int customerId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = membershipInsertQuery;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Price", defaultMembershipPrice);
                cmd.Parameters.AddWithValue("@StartDate", membershipStartDate);
                cmd.Parameters.AddWithValue("@EndDate", membershipEndDate);
                cmd.Parameters.AddWithValue("@Status", membershipStatus);
                cmd.Parameters.AddWithValue("@Type", membershipType);

                int membershipId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = subscribesToInsertQuery;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@MemberShipID", membershipId);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine($"Customer '{username}' registered successfully with a Basic Membership.");
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error registering customer: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    static void LoginCustomer()
    {
        Console.WriteLine("\n=== Customer Login ===");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        string query = "SELECT CustomerID, Fname FROM Customer WHERE UserName = @UserName AND Password = @Password"; // In real app, compare hashed passwords
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int customerId = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        ShowCustomerMenu(firstName, customerId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
        }
    }

    static void LoginAdmin()
    {
        Console.WriteLine("\n=== Admin Login ===");
        Console.Write("Admin ID: ");
        string adminId = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        string query = "SELECT AdminID FROM Admin WHERE AdminID = @AdminID AND Password = @Password";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@AdminID", adminId);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    ShowAdminMenu(adminId);
                }
                else
                {
                    Console.WriteLine("Invalid Admin ID or password.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error logging in as admin: {ex.Message}");
            }
        }
    }

    static void ShowCustomerMenu(string firstName, int customerId)
    {
        while (true)
        {
            Console.WriteLine($"\n=== Customer Menu (Welcome, {firstName}) ===");
            Console.WriteLine("1. View Available Movies");
            Console.WriteLine("2. Search Movie by Title");
            Console.WriteLine("3. Rent Movie");
            Console.WriteLine("4. Return Movie");
            Console.WriteLine("5. View Rental History");
            Console.WriteLine("6. Logout");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewAvailableMovies();
                    break;
                case "2":
                    SearchMovieByTitle();
                    break;
                case "3":
                    RentMovie(customerId);
                    break;
                case "4":
                    ReturnMovie(customerId);
                    break;
                case "5":
                    ViewRentalHistory(customerId);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void ShowAdminMenu(string adminId)
    {
        while (true)
        {
            Console.WriteLine($"\n=== Admin Menu (Admin ID: {adminId}) ===");
            Console.WriteLine("1. Add New Movie");
            Console.WriteLine("2. Update Movie Details");
            Console.WriteLine("3. Remove Movie");
            Console.WriteLine("4. View All Rentals");
            Console.WriteLine("5. Logout");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddMovie(adminId);
                    break;
                case "2":
                    UpdateMovie();
                    break;
                case "3":
                    RemoveMovie();
                    break;
                case "4":
                    ViewAllRentals();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void ViewAvailableMovies()
    {
        string query = "SELECT MovieID, Title, ReleaseYear, LeadActor, NoOfCopies, Price_Per_Day FROM Movie_Tape WHERE AvailabilityStatus = 1 AND NoOfCopies > 0";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n=== Available Movies ===");
                    Console.WriteLine("ID\tTitle\tYear\tActor\tCopies\tPrice/Day");
                    Console.WriteLine("--------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["MovieID"]}\t{reader["Title"]}\t{reader["ReleaseYear"]}\t{reader["LeadActor"]}\t{reader["NoOfCopies"]}\t{reader["Price_Per_Day"]}");
                    }
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No movies currently available.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error viewing movies: {ex.Message}");
            }
        }
    }
    static void SearchMovieByTitle()
    {
        Console.WriteLine("\n=== Search Movie by Title ===");
        Console.Write("Enter title to search: ");
        string searchTitle = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchTitle))
        {
            Console.WriteLine("Please enter a title to search.");
            return;
        }

        string query = @"
            SELECT MovieID, Title, ReleaseYear, LeadActor, NoOfCopies, Price_Per_Day
            FROM Movie_Tape
            WHERE Title LIKE @SearchTitle AND AvailabilityStatus = 1 AND NoOfCopies > 0";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@SearchTitle", "%" + searchTitle + "%"); // Use LIKE for partial matches

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n=== Search Results ===");
                    Console.WriteLine("ID\tTitle\tYear\tActor\tCopies\tPrice/Day");
                    Console.WriteLine("--------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["MovieID"]}\t{reader["Title"]}\t{reader["ReleaseYear"]}\t{reader["LeadActor"]}\t{reader["NoOfCopies"]}\t{reader["Price_Per_Day"]}");
                    }
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"No movies found with title containing '{searchTitle}'.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error searching movies: {ex.Message}");
            }
        }
    }

    static void RentMovie(int customerId)
    {
        Console.WriteLine("\n=== Rent Movie ===");
        ViewAvailableMovies();
        Console.Write("Enter Movie ID to rent: ");
        if (!int.TryParse(Console.ReadLine(), out int movieId))
        {
            Console.WriteLine("Invalid Movie ID.");
            return;
        }
        Console.Write("Enter number of copies to rent: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }
        Console.Write("Enter rental duration (in days): ");
        if (!int.TryParse(Console.ReadLine(), out int rentalDuration) || rentalDuration <= 0)
        {
            Console.WriteLine("Invalid rental duration.");
            return;
        }

        // Get the customer's MembershipID
        int? membershipId = GetCustomerMembershipId(customerId);
        if (!membershipId.HasValue)
        {
            Console.WriteLine("Customer does not have an active membership.");
            return;
        }

        string checkAvailabilityQuery = "SELECT NoOfCopies, Price_Per_Day FROM Movie_Tape WHERE MovieID = @MovieID AND AvailabilityStatus = 1 AND NoOfCopies >= @Quantity";
        string insertRentalQuery = @"
            INSERT INTO Rental (MemberShipID, MovieID, RentalDate, ReturnDate, RentalDuration, Quantity, RentalCharge)
            VALUES (@MemberShipID, @MovieID, @RentalDate, @ReturnDate, @RentalDuration, @Quantity, @RentalCharge);
            UPDATE Movie_Tape SET NoOfCopies = NoOfCopies - @Quantity WHERE MovieID = @MovieID;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(checkAvailabilityQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@MovieID", movieId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int availableCopies = reader.GetInt32(0);
                        decimal pricePerDay = reader.GetDecimal(1);
                        reader.Close();

                        decimal rentalCharge = pricePerDay * quantity * rentalDuration;
                        DateTime rentalDate = DateTime.Now.Date;
                        DateTime returnDate = rentalDate.AddDays(rentalDuration);

                        cmd.CommandText = insertRentalQuery;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MemberShipID", membershipId);
                        cmd.Parameters.AddWithValue("@MovieID", movieId);
                        cmd.Parameters.AddWithValue("@RentalDate", rentalDate);
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                        cmd.Parameters.AddWithValue("@RentalDuration", rentalDuration);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@RentalCharge", rentalCharge);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        Console.WriteLine($"Successfully rented {quantity} copies of Movie ID {movieId}. Total charge: {rentalCharge:C}. Return by: {returnDate:yyyy-MM-dd}.");
                    }
                    else
                    {
                        Console.WriteLine("Movie not available or not enough copies.");
                    }
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error renting movie: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    static void ReturnMovie(int customerId)
    {
        Console.WriteLine("\n=== Return Movie ===");
        // Get the customer's MembershipID
        int? membershipId = GetCustomerMembershipId(customerId);
        if (!membershipId.HasValue)
        {
            Console.WriteLine("Customer does not have an active membership.");
            return;
        }

        string getRentalsQuery = @"
            SELECT r.RentalID, mt.Title, r.Quantity, r.ReturnDate
            FROM Rental r
            JOIN Movie_Tape mt ON r.MovieID = mt.MovieID
            WHERE r.MemberShipID = @MemberShipID AND r.ReturnDate >= @CurrentDate"; // Show current or overdue rentals
        string updateRentalQuery = @"
            UPDATE Rental SET ReturnDate = @ActualReturnDate WHERE RentalID = @RentalID;
            UPDATE Movie_Tape SET NoOfCopies = NoOfCopies + @Quantity WHERE MovieID = @MovieID;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(getRentalsQuery, conn);
            cmd.Parameters.AddWithValue("@MemberShipID", membershipId);
            cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

            Console.WriteLine("\n=== Your Current Rentals ===");
            Console.WriteLine("Rental ID\tTitle\tQuantity\tReturn Due");
            Console.WriteLine("--------------------------------------------------");
            using (SqlDataReader rentalsReader = cmd.ExecuteReader()) // Renamed the first reader
            {
                while (rentalsReader.Read())
                {
                    Console.WriteLine($"{rentalsReader["RentalID"]}\t\t{rentalsReader["Title"]}\t\t{rentalsReader["Quantity"]}\t\t{((DateTime)rentalsReader["ReturnDate"]).ToString("yyyy-MM-dd")}");
                }
                if (!rentalsReader.HasRows)
                {
                    Console.WriteLine("No current rentals found.");
                    return;
                }
            }

            Console.Write("Enter Rental ID to return: ");
            if (!int.TryParse(Console.ReadLine(), out int rentalId))
            {
                Console.WriteLine("Invalid Rental ID.");
                return;
            }

            Console.Write("Enter quantity to return: ");
            if (!int.TryParse(Console.ReadLine(), out int returnQuantity) || returnQuantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            // Verify the rental belongs to the customer's membership
            string verifyRentalQuery = "SELECT MovieID, Quantity FROM Rental WHERE RentalID = @RentalID AND MemberShipID = @MemberShipID";
            cmd.CommandText = verifyRentalQuery;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RentalID", rentalId);
            cmd.Parameters.AddWithValue("@MemberShipID", membershipId);

            using (SqlDataReader verificationReader = cmd.ExecuteReader()) // Renamed the second reader
            {
                if (verificationReader.Read())
                {
                    int rentedMovieId = verificationReader.GetInt32(0);
                    int rentedQuantity = verificationReader.GetInt32(1);
                    verificationReader.Close();

                    if (returnQuantity > rentedQuantity)
                    {
                        Console.WriteLine($"You only rented {rentedQuantity} copies.");
                        return;
                    }

                    SqlCommand updateCmd = new SqlCommand(updateRentalQuery, conn);
                    updateCmd.Parameters.AddWithValue("@RentalID", rentalId);
                    updateCmd.Parameters.AddWithValue("@ActualReturnDate", DateTime.Now.Date);
                    updateCmd.Parameters.AddWithValue("@MovieID", rentedMovieId);
                    updateCmd.Parameters.AddWithValue("@Quantity", returnQuantity);
                    updateCmd.ExecuteNonQuery();

                    Console.WriteLine($"Successfully returned {returnQuantity} copies of Rental ID {rentalId}.");
                }
                else
                {
                    Console.WriteLine("Rental not found or does not belong to your membership.");
                }
            }
        }
    }

    static void ViewRentalHistory(int customerId)
    {
        // Get the customer's MembershipID
        int? membershipId = GetCustomerMembershipId(customerId);
        if (!membershipId.HasValue)
        {
            Console.WriteLine("Customer does not have an active membership.");
            return;
        }

        string query = @"
            SELECT r.RentalID, mt.Title, r.RentalDate, r.ReturnDate, r.Quantity, r.RentalCharge
            FROM Rental r
            JOIN Movie_Tape mt ON r.MovieID = mt.MovieID
            WHERE r.MemberShipID = @MemberShipID
            ORDER BY r.RentalDate DESC";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@MemberShipID", membershipId);

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n=== Your Rental History ===");
                    Console.WriteLine("Rental ID\tTitle\t\tRental Date\tReturn Date\tQuantity\tCharge");
                    Console.WriteLine("------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RentalID"]}\t\t{reader["Title"]}\t\t{((DateTime)reader["RentalDate"]).ToString("yyyy-MM-dd")}\t{((DateTime)reader["ReturnDate"]).ToString("yyyy-MM-dd")}\t\t{reader["Quantity"]}\t\t{reader["RentalCharge"]:C}");
                    }
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No rental history found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error viewing rental history: {ex.Message}");
            }
        }
    }

    static void AddMovie(string adminId)
    {
        Console.WriteLine("\n=== Add New Movie ===");
        Console.Write("Movie ID: ");
        if (!int.TryParse(Console.ReadLine(), out int movieId))
        {
            Console.WriteLine("Invalid Movie ID.");
            return;
        }
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Release Year: ");
        if (!int.TryParse(Console.ReadLine(), out int releaseYear))
        {
            Console.WriteLine("Invalid Release Year.");
            return;
        }
        Console.Write("Lead Actor: ");
        string leadActor = Console.ReadLine();
        Console.Write("Number of Copies: ");
        if (!int.TryParse(Console.ReadLine(), out int noOfCopies) || noOfCopies < 0)
        {
            Console.WriteLine("Invalid number of copies.");
            return;
        }
        Console.Write("Price Per Day: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal pricePerDay) || pricePerDay < 0)
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        string insertMovieQuery = @"
            INSERT INTO Movie_Tape (MovieID, Title, ReleaseYear, AddDate, LeadActor, NoOfCopies, AvailabilityStatus, Price_Per_Day)
            VALUES (@MovieID, @Title, @ReleaseYear, @AddDate, @LeadActor, @NoOfCopies, 1, @PricePerDay);
            INSERT INTO AddsAndUpdates (AdminID, MovieID)
            VALUES (@AdminID, @MovieID);";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(insertMovieQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@MovieID", movieId);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
            cmd.Parameters.AddWithValue("@AddDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@LeadActor", leadActor);
            cmd.Parameters.AddWithValue("@NoOfCopies", noOfCopies);
            cmd.Parameters.AddWithValue("@PricePerDay", pricePerDay);
            cmd.Parameters.AddWithValue("@AdminID", adminId);

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine($"Movie '{title}' (ID: {movieId}) added successfully.");
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error adding movie: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    static void UpdateMovie()
    {
        Console.WriteLine("\n=== Update Movie Details ===");
        Console.Write("Enter Movie ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int movieIdToUpdate))
        {
            Console.WriteLine("Invalid Movie ID.");
            return;
        }

        Console.WriteLine("Enter new details (leave blank to keep current):");
        Console.Write($"New Title: ");
        string newTitle = Console.ReadLine();
        Console.Write($"New Release Year: ");
        string releaseYearInput = Console.ReadLine();
        int? newReleaseYear = string.IsNullOrEmpty(releaseYearInput) ? (int?)null : int.Parse(releaseYearInput);
        Console.Write($"New Lead Actor: ");
        string newLeadActor = Console.ReadLine();
        Console.Write($"New Number of Copies: ");
        string noOfCopiesInput = Console.ReadLine();
        int? newNoOfCopies = string.IsNullOrEmpty(noOfCopiesInput) ? (int?)null : int.Parse(noOfCopiesInput);
        Console.Write($"New Price Per Day: ");
        string pricePerDayInput = Console.ReadLine();
        decimal? newPricePerDay = string.IsNullOrEmpty(pricePerDayInput) ? (decimal?)null : decimal.Parse(pricePerDayInput);
        Console.Write($"New Availability Status (0 or 1): ");
        string availabilityInput = Console.ReadLine();
        bool? newAvailabilityStatus = string.IsNullOrEmpty(availabilityInput) ? (bool?)null : (availabilityInput == "1");

        string updateQuery = "UPDATE Movie_Tape SET ";
        bool isFirst = true;

        if (!string.IsNullOrEmpty(newTitle)) { updateQuery += $"Title = @Title"; isFirst = false; }
        if (newReleaseYear.HasValue) { updateQuery += (isFirst ? "" : ", ") + $"ReleaseYear = @ReleaseYear"; isFirst = false; }
        if (!string.IsNullOrEmpty(newLeadActor)) { updateQuery += (isFirst ? "" : ", ") + $"LeadActor = @LeadActor"; isFirst = false; }
        if (newNoOfCopies.HasValue) { updateQuery += (isFirst ? "" : ", ") + $"NoOfCopies = @NoOfCopies"; isFirst = false; }
        if (newPricePerDay.HasValue) { updateQuery += (isFirst ? "" : ", ") + $"Price_Per_Day = @PricePerDay"; isFirst = false; }
        if (newAvailabilityStatus.HasValue) { updateQuery += (isFirst ? "" : ", ") + $"AvailabilityStatus = @AvailabilityStatus"; isFirst = false; }

        if (!isFirst)
        {
            updateQuery += " WHERE MovieID = @MovieID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MovieID", movieIdToUpdate);
                if (!string.IsNullOrEmpty(newTitle)) cmd.Parameters.AddWithValue("@Title", newTitle);
                if (newReleaseYear.HasValue) cmd.Parameters.AddWithValue("@ReleaseYear", newReleaseYear);
                if (!string.IsNullOrEmpty(newLeadActor)) cmd.Parameters.AddWithValue("@LeadActor", newLeadActor);
                if (newNoOfCopies.HasValue) cmd.Parameters.AddWithValue("@NoOfCopies", newNoOfCopies);
                if (newPricePerDay.HasValue) cmd.Parameters.AddWithValue("@PricePerDay", newPricePerDay);
                if (newAvailabilityStatus.HasValue) cmd.Parameters.AddWithValue("@AvailabilityStatus", newAvailabilityStatus);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Movie ID {movieIdToUpdate} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Movie ID {movieIdToUpdate} not found.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error updating movie: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("No updates provided.");
        }
    }

    static void RemoveMovie()
    {
        Console.WriteLine("\n=== Remove Movie ===");
        Console.Write("Enter Movie ID to remove: ");
        if (!int.TryParse(Console.ReadLine(), out int movieIdToRemove))
        {
            Console.WriteLine("Invalid Movie ID.");
            return;
        }

        // Check if there are any active rentals for this movie
        string checkRentalsQuery = "SELECT COUNT(*) FROM Rental WHERE MovieID = @MovieID AND ReturnDate >= @CurrentDate";
        string deleteMovieQuery = "DELETE FROM Movie_Tape WHERE MovieID = @MovieID";
        string deleteAddsUpdatesQuery = "DELETE FROM AddsAndUpdates WHERE MovieID = @MovieID";
        string deleteMovieGenreQuery = "DELETE FROM MovieGenre WHERE MovieID = @MovieID";
        string deleteMovieSupplyQuery = "DELETE FROM MovieSupply WHERE MovieID = @MovieID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(checkRentalsQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@MovieID", movieIdToRemove);
            cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

            try
            {
                int activeRentals = (int)cmd.ExecuteScalar();
                if (activeRentals > 0)
                {
                    Console.WriteLine("Cannot remove movie with active rentals. Please ensure all copies are returned first.");
                    transaction.Rollback();
                    return;
                }

                cmd.CommandText = deleteAddsUpdatesQuery;
                cmd.ExecuteNonQuery();

                cmd.CommandText = deleteMovieGenreQuery;
                cmd.ExecuteNonQuery();

                cmd.CommandText = deleteMovieSupplyQuery;
                cmd.ExecuteNonQuery();

                cmd.CommandText = deleteMovieQuery;
                int rowsAffected = cmd.ExecuteNonQuery();

                transaction.Commit();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Movie ID {movieIdToRemove} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Movie ID {movieIdToRemove} not found.");
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error removing movie: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    static void ViewAllRentals()
    {
        string query = @"
            SELECT r.RentalID, c.Fname + ' ' + c.Lname AS CustomerName, mt.Title, r.RentalDate, r.ReturnDate, r.Quantity, r.RentalCharge
            FROM Rental r
            JOIN MemberShip ms ON r.MemberShipID = ms.MemberShipID
            JOIN SubscribesTo st ON ms.MemberShipID = st.MemberShipID
            JOIN Customer c ON st.CustomerID = c.CustomerID
            JOIN Movie_Tape mt ON r.MovieID = mt.MovieID
            ORDER BY r.RentalDate DESC";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n=== All Rentals ===");
                    Console.WriteLine("Rental ID\tCustomer Name\tTitle\t\tRental Date\tReturn Date\tQuantity\tCharge");
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RentalID"]}\t\t{reader["CustomerName"]}\t\t{reader["Title"]}\t\t{((DateTime)reader["RentalDate"]).ToString("yyyy-MM-dd")}\t{((DateTime)reader["ReturnDate"]).ToString("yyyy-MM-dd")}\t\t{reader["Quantity"]}\t\t{reader["RentalCharge"]:C}");
                    }
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No rentals found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error viewing all rentals: {ex.Message}");
            }
        }
    }

    static int? GetCustomerMembershipId(int customerId)
    {
        string query = @"
            SELECT m.MemberShipID
            FROM MemberShip m
            JOIN SubscribesTo s ON m.MemberShipID = s.MemberShipID
            WHERE s.CustomerID = @CustomerID AND m.EndDate >= @CurrentDate AND m.Status = 'Active'";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@CustomerID", customerId);
            cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result == null ? (int?)null : Convert.ToInt32(result);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting membership ID: {ex.Message}");
                return null;
            }
        }
    }
}