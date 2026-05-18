using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Org.BouncyCastle.Asn1.Cmp;

namespace MovieRentalTest
{
    public partial class MovieListForm : Form
    {
        public MovieListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadData();
        }

        private void ConfigureDataGridView()
        {
            // Clear existing columns
            dgvMovies.Columns.Clear();

            // Add data columns
            dgvMovies.Columns.Add("Title", "Title");
            dgvMovies.Columns.Add("LeadActor", "Lead Actor");
            dgvMovies.Columns.Add("Genres", "Genre");
            dgvMovies.Columns.Add("ReleaseYear", "Year");
            dgvMovies.Columns.Add("Price", "Price Per Day");
            dgvMovies.Columns.Add("AvailabilityStatus", "Available");

            // Add button column
            var rentButton = new DataGridViewButtonColumn
            {
                Name = "Rent",
                Text = "Rent",
                UseColumnTextForButtonValue = true
            };
            dgvMovies.Columns.Add(rentButton);

            // Style settings
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovies.Columns["LeadActor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.Columns["ReleaseYear"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.Columns["AvailabilityStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.ReadOnly = true;
            dgvMovies.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            if (!UserSession.IsLoggedIn || UserSession.IsAdmin)
            {
                this.Close();
                return;
            }

            LoadGenres();
            LoadMovies();
        }

        private void LoadGenres()
        {
            cmbGenre.Items.Clear();
            cmbGenre.Items.Add("All");

            try
            {
                using (var conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT DISTINCT GenreName FROM MovieGenre ORDER BY GenreName", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbGenre.Items.Add(reader["GenreName"].ToString());
                        }
                    }
                }
                cmbGenre.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading genres: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMovies()
        {
            try
            {
                StringBuilder sql = new StringBuilder(@"
                    SELECT 
                        mt.Title,
                        mt.LeadActor,
                        STUFF((
                            SELECT ', ' + mg.GenreName
                            FROM MovieGenre mg
                            WHERE mg.MovieID = mt.MovieID
                            FOR XML PATH('')
                        ), 1, 2, '') AS Genres,
                        mt.ReleaseYear,
                        mt.Price_Per_Day AS Price,
                        CASE WHEN mt.AvailabilityStatus = 1 THEN 'Yes' ELSE 'No' END AS AvailabilityStatus,
                        mt.MovieID
                    FROM Movie_Tape mt
                    WHERE 1=1
                ");

                // Apply filters
                if (!string.IsNullOrEmpty(txtSearchTitle.Text.Trim()))
                {
                    sql.Append(" AND mt.Title LIKE @title ");
                }

                if (cmbGenre.SelectedIndex > 0)
                {
                    sql.Append(" AND EXISTS (SELECT 1 FROM MovieGenre mg WHERE mg.MovieID = mt.MovieID AND mg.GenreName = @genre) ");
                }

                if (numYear.Value != 1900)
                {
                    sql.Append(" AND mt.ReleaseYear = @year ");
                }

                if (!string.IsNullOrWhiteSpace(txtLeadActor.Text))
                {
                    sql.Append(" AND mt.LeadActor LIKE @actor ");
                }

                // Only show available movies
                sql.Append(" AND mt.AvailabilityStatus = 1");

                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

                    if (!string.IsNullOrEmpty(txtSearchTitle.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@title", "%" + txtSearchTitle.Text.Trim() + "%");
                    }
                    if (cmbGenre.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@genre", cmbGenre.SelectedItem.ToString());
                    }
                    if (numYear.Value != 1900)
                    {
                        cmd.Parameters.AddWithValue("@year", (int)numYear.Value);
                    }
                    if (!string.IsNullOrWhiteSpace(txtLeadActor.Text))
                    {
                        cmd.Parameters.AddWithValue("@actor", "%" + txtLeadActor.Text.Trim() + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvMovies.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvMovies.Rows.Add(
                                reader["Title"].ToString(),
                                reader["LeadActor"].ToString(),
                                reader["Genres"].ToString(),
                                reader["ReleaseYear"].ToString(),
                                $"${Convert.ToDecimal(reader["Price"]):0.00}",
                                reader["AvailabilityStatus"].ToString()
                            );
                            dgvMovies.Rows[dgvMovies.Rows.Count - 1].Tag = reader["MovieID"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMovies.Columns[e.ColumnIndex].Name == "Rent")
            {
                var row = dgvMovies.Rows[e.RowIndex];
                int movieId = (int)row.Tag;
                decimal price = decimal.Parse(row.Cells["Price"].Value.ToString().Trim('$'));

                using (var rentalForm = new RentalDetailsForm(movieId, price))
                {
                    if (rentalForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            RentalHelper.RentMovie(
                                UserSession.CustomerID,
                                movieId,
                                rentalForm.Quantity,
                                rentalForm.Duration);

                            LoadMovies();
                            MessageBox.Show("Movie rented successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Rental failed: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            // Clear all search filters
            txtSearchTitle.Text = string.Empty;
            txtLeadActor.Text = string.Empty;
            numYear.Value = 1900;
            cmbGenre.SelectedIndex = 0;

            // Reload the movies with cleared filters
            LoadMovies();
        }
    }
}