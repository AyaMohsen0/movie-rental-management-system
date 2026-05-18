
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalMovieSystemReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonReport.Click += btnLoadReport_Click;
            this.Load += Form1_Load;
        }

        string connectionString = "Data Source=DESKTOP-HFKRDHF\\SQLEXPRESS;Initial Catalog=MovieRentalAppDB;Integrated Security=True;";

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxReportType.Items.AddRange(new string[]
  {
    // Movies
    "All Movies",
    "Available Movies",
    "Rented Movies",
    "Top Rented Movies",
    "Movies by Genre",

    // Memberships
    "All Memberships",
    "Active Memberships",
    "Inactive Memberships",
    "Top Renting Members",

    // Rentals
    "All Rentals",

    // Custom Genre & Supplier Reports (a–f)
    "Most Rented Genres",                 // (a)
    "Genres Without Rentals Last Month", // (b)
    "Movies Added by Genre and Date",    // (c)
    "Member Rental Counts",              // (d)
    "Top Rented Genres and Sales",       // (e)
    "Inactive Suppliers (Last 3 Months)" // (f)
  });

        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string selectedReport = comboBoxReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("Please select a report.");
                return;
            }

            string query = "";

            switch (selectedReport)
            {
                // --- Movies ---
                case "All Movies":
                    query = "SELECT * FROM Movie_Tape";
                    break;
                case "Available Movies":
                    query = @"SELECT M.MovieID, M.Title
                              FROM Movie_Tape M
                              WHERE M.NoOfCopies > (
                                  SELECT COUNT(*) FROM Rental R WHERE R.MovieID = M.MovieID AND R.ReturnDate IS NULL)";
                    break;
                case "Rented Movies":
                    query = @"SELECT DISTINCT M.MovieID, M.Title
                              FROM Movie_Tape M
                              JOIN Rental R ON M.MovieID = R.MovieID
                              WHERE R.RentalDate IS Not NULL";
                    break;
                case "Top Rented Movies":
                    query = @"SELECT M.MovieID, M.Title, COUNT(*) AS RentalCount
                              FROM Movie_Tape M
                              JOIN Rental R ON M.MovieID = R.MovieID
                              GROUP BY M.MovieID, M.Title
                              ORDER BY RentalCount DESC";
                    break;
                case "Movies by Genre":
                    query = @"SELECT GenreName, COUNT(*) AS TotalMovies
                              FROM MovieGenre
                              GROUP BY GenreName";
                    break;

                // --- Memberships ---
                case "All Memberships":
                    query = "SELECT * FROM MemberShip";
                    break;
                case "Active Memberships":
                    query = @"SELECT DISTINCT M.MemberShipID
                              FROM MemberShip M
                              JOIN Rental R ON M.MemberShipID = R.MemberShipID";
                    break;
                case "Inactive Memberships":
                    query = @"SELECT M.MemberShipID
                              FROM MemberShip M
                              WHERE NOT EXISTS (
                                  SELECT * FROM Rental R WHERE R.MemberShipID = M.MemberShipID)";
                    break;
                case "Top Renting Members":
                    query = @"SELECT M.MemberShipID, COUNT(*) AS TotalRentals
                              FROM MemberShip M
                              JOIN Rental R ON M.MemberShipID = R.MemberShipID
                              GROUP BY M.MemberShipID
                              ORDER BY TotalRentals DESC";
                    break;

                // --- Rentals ---
                case "All Rentals":
                    query = "SELECT * FROM Rental";
                    break;
                case "Most Rented Genres":
                    query = @"
        SELECT G.GenreName, COUNT(R.MovieID) as Rental_Count
        FROM Rental R
        JOIN Movie_Tape M ON M.MovieID = R.MovieID
        JOIN MovieGenre MC ON MC.MovieID = R.MovieID
        JOIN Movie_Genre G ON G.GenreName = MC.GenreName
        GROUP BY G.GenreName
        HAVING COUNT(R.MovieID) = (
            SELECT MAX(Rental_Count)
            FROM (
                SELECT COUNT(R2.MovieID) as Rental_Count
                FROM Rental R2
                JOIN Movie_Tape M2 ON M2.MovieID = R2.MovieID
                JOIN MovieGenre MC2 ON MC2.MovieID = R2.MovieID
                JOIN Movie_Genre G2 ON G2.GenreName = MC2.GenreName
                GROUP BY G2.GenreName
            ) MaxRentals
        )
        ORDER BY G.GenreName";
                    break;

                case "Genres Without Rentals Last Month":
                    query = @"
        SELECT G.GenreName
        FROM MovieGenre G
        WHERE G.GenreName NOT IN (
            SELECT DISTINCT MC.GenreName
            FROM Rental R
            JOIN Movie_Tape M ON M.MovieID = R.MovieID
            JOIN MovieGenre MC ON MC.MovieID = R.MovieID
            WHERE R.RENTALDATE >= DATEADD(MONTH, -1, GETDATE())
        )";
                    break;

                case "Movies Added by Genre and Date":
                    query = @"
        SELECT G.GenreName, M.Title, MS.SupplyDate
        FROM MovieSupply MS
        JOIN Movie_Tape M ON M.MovieID = MS.MovieID
        JOIN MovieGenre MC ON MC.MovieID = M.MovieID
        JOIN Movie_Genre G ON G.GenreName = MC.GenreName
        ORDER BY G.GenreName, MS.SupplyDate";
                    break;

                case "Member Rental Counts":
                    query = @"
        SELECT M.*, 
               (SELECT COUNT(*) 
                FROM Rental R 
                WHERE R.MemberShipID = M.MemberShipID) AS Rented_Movies
        FROM MemberShip M";
                    break;

                case "Top Rented Genres and Sales":
                    query = @"
        SELECT G.GenreName, COUNT(R.MovieID) AS Total_Rentals, SUM(R.rentalcharge) AS Total_Sales
        FROM Rental R
        JOIN Movie_Tape M ON M.MovieID = R.MovieID
        JOIN MovieGenre MC ON MC.MovieID = R.MovieID
        JOIN Movie_Genre G ON G.GenreName = MC.GenreName
        GROUP BY G.GenreName
        ORDER BY Total_Rentals DESC";
                    break;

                case "Inactive Suppliers (Last 3 Months)":
                    query = @"
        SELECT S.*
        FROM Supplier S
        WHERE S.SupplierName NOT IN (
            SELECT DISTINCT MS.SupplierName
            FROM MovieSupply MS
            WHERE MS.SupplyDate >= DATEADD(MONTH, -3, GETDATE())
        )";
                    break;

                default:
                    MessageBox.Show("Invalid report type.");
                    return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
