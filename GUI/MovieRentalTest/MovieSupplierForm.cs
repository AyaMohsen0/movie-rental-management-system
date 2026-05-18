using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class MovieSupplyForm : Form
    {
        private DataTable suppliesTable;

        public MovieSupplyForm()
        {
            InitializeComponent();
        }

        private void MovieSupplyForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadMovies();
            LoadMovieSupplies();
            dtpSupplyDate.Value = DateTime.Today;
        }

        private void LoadSuppliers()
        {
            cmbSuppliers.Items.Clear();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT SupplierName FROM Supplier ORDER BY SupplierName", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbSuppliers.Items.Add(reader["SupplierName"].ToString());
                }
            }
        }

        private void LoadMovies()
        {
            cmbMovies.Items.Clear();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MovieID, Title FROM Movie_Tape ORDER BY Title", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbMovies.Items.Add(new ComboBoxItem(
                        reader["Title"].ToString(),
                        Convert.ToInt32(reader["MovieID"]))
                    );
                }
            }
        }

        private void LoadMovieSupplies()
        {
            suppliesTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        ms.MovieID, 
                        mt.Title, 
                        ms.SupplierName, 
                        ms.SupplyDate
                    FROM MovieSupply ms
                    JOIN Movie_Tape mt ON ms.MovieID = mt.MovieID
                    ORDER BY ms.SupplyDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(suppliesTable);
            }
            dgvMovieSupplies.DataSource = suppliesTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSuppliers.SelectedItem == null || cmbMovies.SelectedItem == null)
            {
                MessageBox.Show("Please select a supplier and movie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string supplierName = cmbSuppliers.SelectedItem.ToString();
            int movieId = ((ComboBoxItem)cmbMovies.SelectedItem).Value;
            DateTime supplyDate = dtpSupplyDate.Value;

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MovieSupply (MovieID, SupplierName, SupplyDate) " +
                    "VALUES (@movieId, @supplier, @date)", conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@supplier", supplierName);
                cmd.Parameters.AddWithValue("@date", supplyDate);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supply record added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMovieSupplies();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovieSupplies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvMovieSupplies.SelectedRows[0];
            int movieId = Convert.ToInt32(row.Cells["colMovieID"].Value);
            string supplierName = row.Cells["colSupplierName"].Value.ToString();
            DateTime supplyDate = Convert.ToDateTime(row.Cells["colSupplyDate"].Value);

            if (MessageBox.Show("Delete this supply record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM MovieSupply " +
                        "WHERE MovieID = @movieId AND SupplierName = @supplier AND SupplyDate = @date", conn);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    cmd.Parameters.AddWithValue("@supplier", supplierName);
                    cmd.Parameters.AddWithValue("@date", supplyDate);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supply record deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMovieSupplies();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    // Helper class for ComboBox items
    public class ComboBoxItem
    {
        public string Text { get; }
        public int Value { get; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() => Text;
    }
}