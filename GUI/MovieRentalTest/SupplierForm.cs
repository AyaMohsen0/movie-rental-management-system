using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class SupplierForm : Form
    {
        private DataTable suppliersTable;
        private bool isEditMode = false;
        private string currentSupplierName = "";

        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            suppliersTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT SupplierName, SupplierEmail, SupplierPhone FROM Supplier", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(suppliersTable);
            }
            dgvSuppliers.DataSource = suppliersTable;
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                currentSupplierName = row.Cells["colName"].Value.ToString();
                txtSupplierName.Text = currentSupplierName;
                txtSupplierEmail.Text = row.Cells["colEmail"].Value.ToString();
                txtSupplierPhone.Text = row.Cells["colPhone"].Value.ToString();
                isEditMode = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (isEditMode)
                {
                    // Update existing supplier
                    cmd = new SqlCommand(
                        "UPDATE Supplier SET SupplierName = @name, SupplierEmail = @email, SupplierPhone = @phone " +
                        "WHERE SupplierName = @oldName", conn);
                    cmd.Parameters.AddWithValue("@oldName", currentSupplierName);
                }
                else
                {
                    // Insert new supplier
                    cmd = new SqlCommand(
                        "INSERT INTO Supplier (SupplierName, SupplierEmail, SupplierPhone) " +
                        "VALUES (@name, @email, @phone)", conn);
                }

                cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtSupplierEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text.Trim());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadSuppliers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSupplierName))
            {
                MessageBox.Show("Please select a supplier to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Delete supplier '{currentSupplierName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Supplier WHERE SupplierName = @name", conn);
                    cmd.Parameters.AddWithValue("@name", currentSupplierName);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                        LoadSuppliers();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n\nEnsure no movies are linked to this supplier.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtSupplierName.Clear();
            txtSupplierEmail.Clear();
            txtSupplierPhone.Clear();
            currentSupplierName = "";
            isEditMode = false;
        }
    }
}