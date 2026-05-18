using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadGenres();
            LoadMovies();
        }

        private void LoadGenres()
        {
            clbGenres.Items.Clear();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT GenreName FROM Movie_Genre ORDER BY GenreName", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clbGenres.Items.Add(reader["GenreName"].ToString());
                    }
                }
            }
        }

        private void LoadMovies()
        {
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                        mt.MovieID, mt.Title, mt.LeadActor, mt.ReleaseYear, 
                        mt.NoOfCopies, mt.Price_Per_Day,
                        STRING_AGG(mg.GenreName, ', ') AS Genres
                      FROM Movie_Tape mt
                      LEFT JOIN MovieGenre mg ON mt.MovieID = mg.MovieID
                      GROUP BY mt.MovieID, mt.Title, mt.LeadActor, mt.ReleaseYear, 
                               mt.NoOfCopies, mt.Price_Per_Day",
                    conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovies.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtLeadActor.Text) ||
                clbGenres.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please fill all fields and select at least one genre", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get next available MovieID
                        SqlCommand idCmd = new SqlCommand(
                            "SELECT ISNULL(MAX(MovieID), 0) + 1 FROM Movie_Tape",
                            conn, transaction);
                        int movieId = Convert.ToInt32(idCmd.ExecuteScalar());

                        // Insert movie with explicit ID
                        SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO Movie_Tape 
                    (MovieID, Title, ReleaseYear, LeadActor, NoOfCopies, Price_Per_Day, AddDate, AvailabilityStatus)
                    VALUES (@id, @title, @year, @actor, @copies, @price, GETDATE(), 1)",
                            conn, transaction);

                        cmd.Parameters.AddWithValue("@id", movieId);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@year", (int)numYear.Value);
                        cmd.Parameters.AddWithValue("@actor", txtLeadActor.Text.Trim());
                        cmd.Parameters.AddWithValue("@copies", (int)numCopies.Value);
                        cmd.Parameters.AddWithValue("@price", numPrice.Value);
                        cmd.ExecuteNonQuery();


                        // Add genres
                        foreach (var genre in clbGenres.CheckedItems)
                        {
                            SqlCommand genreCmd = new SqlCommand(
                                "INSERT INTO MovieGenre (MovieID, GenreName) VALUES (@mid, @genre)",
                                conn, transaction);
                            genreCmd.Parameters.AddWithValue("@mid", movieId);
                            genreCmd.Parameters.AddWithValue("@genre", genre.ToString());
                            genreCmd.ExecuteNonQuery();
                        }

                        // Record admin action - only if admin is logged in
                        if (UserSession.IsLoggedIn && UserSession.IsAdmin)
                        {
                            SqlCommand logCmd = new SqlCommand(
                                "INSERT INTO AddsAndUpdates (AdminID, MovieID) VALUES (@admin, @mid)",
                                conn, transaction);
                            logCmd.Parameters.AddWithValue("@admin", UserSession.UserName);
                            logCmd.Parameters.AddWithValue("@mid", movieId);
                            logCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Movie added successfully", "Success");
                        LoadMovies();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Database Error");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = $"%{txtSearch.Text.Trim()}%";

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                        mt.MovieID, mt.Title, mt.LeadActor, mt.ReleaseYear, 
                        mt.NoOfCopies, mt.Price_Per_Day,
                        STRING_AGG(mg.GenreName, ', ') AS Genres
                      FROM Movie_Tape mt
                      LEFT JOIN MovieGenre mg ON mt.MovieID = mg.MovieID
                      WHERE mt.Title LIKE @search OR 
                            mt.LeadActor LIKE @search OR
                            mg.GenreName LIKE @search
                      GROUP BY mt.MovieID, mt.Title, mt.LeadActor, mt.ReleaseYear, 
                               mt.NoOfCopies, mt.Price_Per_Day",
                    conn);

                cmd.Parameters.AddWithValue("@search", searchTerm);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovies.DataSource = dt;
            }
        }
        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMovies();
            txtSearch.Clear();
        }

        private void btnManageGenres_Click(object sender, EventArgs e)
        {
            GenreForm genreForm = new GenreForm();
            genreForm.ShowDialog();
            LoadGenres();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtLeadActor.Clear();
            numYear.Value = DateTime.Now.Year;
            numCopies.Value = 1;
            numPrice.Value = 3.99m;
            for (int i = 0; i < clbGenres.Items.Count; i++)
            {
                clbGenres.SetItemChecked(i, false);
            }
        }
    }
}