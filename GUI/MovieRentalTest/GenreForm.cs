using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MovieRentalTest
{
    public partial class GenreForm : Form
    {
        public GenreForm()
        {
            InitializeComponent();
            LoadGenres();
        }

        private async void LoadGenres()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SELECT GenreName, Description FROM Movie_Genre", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvGenres.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading genres: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreName.Text))
            {
                MessageBox.Show("Genre name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    await conn.OpenAsync();

                    // Check if genre already exists
                    SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Movie_Genre WHERE GenreName = @name", conn);
                    checkCmd.Parameters.AddWithValue("@name", txtGenreName.Text.Trim());

                    if ((int)await checkCmd.ExecuteScalarAsync() > 0)
                    {
                        MessageBox.Show("Genre already exists", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add new genre
                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO Movie_Genre (GenreName, Description) VALUES (@name, @desc)", conn);
                    insertCmd.Parameters.AddWithValue("@name", txtGenreName.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());

                    await insertCmd.ExecuteNonQueryAsync();

                    MessageBox.Show("Genre added successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the list
                    LoadGenres();
                    txtGenreName.Clear();
                    txtDescription.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding genre: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGenres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a genre to delete", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string genreName = dgvGenres.SelectedRows[0].Cells["GenreName"].Value.ToString();

            if (MessageBox.Show($"Delete genre '{genreName}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                    {
                        await conn.OpenAsync();

                        // First check if any movies use this genre
                        SqlCommand checkCmd = new SqlCommand(
                            "SELECT COUNT(*) FROM MovieGenre WHERE GenreName = @name", conn);
                        checkCmd.Parameters.AddWithValue("@name", genreName);

                        if ((int)await checkCmd.ExecuteScalarAsync() > 0)
                        {
                            MessageBox.Show("Cannot delete - this genre is assigned to movies", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Delete the genre
                        SqlCommand deleteCmd = new SqlCommand(
                            "DELETE FROM Movie_Genre WHERE GenreName = @name", conn);
                        deleteCmd.Parameters.AddWithValue("@name", genreName);

                        await deleteCmd.ExecuteNonQueryAsync();

                        MessageBox.Show("Genre deleted successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the list
                        LoadGenres();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting genre: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}