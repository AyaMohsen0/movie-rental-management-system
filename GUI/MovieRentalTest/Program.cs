using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace MovieRentalTest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                VerifyDatabaseConnection().Wait();
                UserSession.Logout();
                Application.Run(new LogInForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatal startup error: {ex.Message}\n\n" +
                                "Please check:\n" +
                                "1. Database server is running\n" +
                                "2. Connection string is correct\n" +
                                "3. Database schema matches expectations",
                                "Startup Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private static async Task VerifyDatabaseConnection()
        {
            try
            {
                using var conn = new SqlConnection(Database.ConnectionString);
                await conn.OpenAsync();

                var cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                      WHERE TABLE_NAME IN ('Customer', 'Admin', 'MemberShip')", conn);

                int tableCount = (int)await cmd.ExecuteScalarAsync();
                if (tableCount != 3)
                    throw new Exception("Required tables are missing in database");
            }
            catch (Exception ex)
            {
                throw new Exception($"Database verification failed: {ex.Message}");
            }
        }


    }
}
