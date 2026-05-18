using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class MemberShipForm : Form
    {
        private DataTable membershipsTable;
        private bool isEditMode = false;
        private int currentMemberShipId = -1;

        public MemberShipForm()
        {
            InitializeComponent();
        }

        private void MemberShipForm_Load(object sender, EventArgs e)
        {
            LoadMemberships();
            dtpStartDate.Value = DateTime.Today;
            cmbType.SelectedIndex = 0; // Default to "Annual"
            cmbStatus.Enabled = false; // Disable status editing since it's auto-calculated
        }

        private void LoadMemberships()
        {
            membershipsTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT m.MemberShipID, m.Type, m.Price, m.StartDate, m.EndDate, 
                      CASE WHEN m.EndDate >= GETDATE() THEN 'Active' ELSE 'Expired' END AS Status
                      FROM MemberShip m
                      JOIN SubscribesTo st ON m.MemberShipID = st.MemberShipID
                      WHERE st.CustomerID = @customerId
                      ORDER BY m.StartDate DESC", conn);
                cmd.Parameters.AddWithValue("@customerId", UserSession.CustomerID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(membershipsTable);
            }
            dgvMemberships.DataSource = membershipsTable;
        }

        private void dgvMemberships_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMemberships.Rows[e.RowIndex];
                currentMemberShipId = Convert.ToInt32(row.Cells["colMemberShipID"].Value);
                cmbType.Text = row.Cells["colType"].Value.ToString();
                numPrice.Value = Convert.ToDecimal(row.Cells["colPrice"].Value);
                dtpStartDate.Value = Convert.ToDateTime(row.Cells["colStartDate"].Value);

                // Calculate duration based on EndDate - StartDate
                DateTime endDate = Convert.ToDateTime(row.Cells["colEndDate"].Value);
                numDuration.Value = (endDate.Year - dtpStartDate.Value.Year) * 12 + endDate.Month - dtpStartDate.Value.Month;

                // Status is read-only and calculated
                cmbStatus.Text = endDate >= DateTime.Today ? "Active" : "Expired";
                isEditMode = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == -1 || numPrice.Value <= 0 || numDuration.Value <= 0)
            {
                MessageBox.Show("Please fill all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = cmbType.SelectedItem.ToString();
            decimal price = numPrice.Value;
            int durationMonths = (int)numDuration.Value;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = startDate.AddMonths(durationMonths);
            string status = endDate >= DateTime.Today ? "Active" : "Expired";

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                // Prevent multiple active memberships for new memberships
                if (!isEditMode)
                {
                    var checkCmd = new SqlCommand(
                        @"SELECT COUNT(*) FROM SubscribesTo st
                          JOIN MemberShip m ON st.MemberShipID = m.MemberShipID
                          WHERE st.CustomerID = @customerId
                          AND m.EndDate >= GETDATE()", conn);
                    checkCmd.Parameters.AddWithValue("@customerId", UserSession.CustomerID);
                    int activeCount = (int)checkCmd.ExecuteScalar();

                    if (activeCount > 0)
                    {
                        MessageBox.Show("You already have an active membership.", "Error");
                        return;
                    }
                }

                SqlCommand cmd;
                if (isEditMode)
                {
                    cmd = new SqlCommand(
                        "UPDATE MemberShip SET " +
                        "Type = @type, Price = @price, StartDate = @start, " +
                        "EndDate = @end " + // Removed Status from update
                        "WHERE MemberShipID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", currentMemberShipId);
                }
                else
                {
                    cmd = new SqlCommand(
                        "INSERT INTO MemberShip (Type, Price, StartDate, EndDate) " + // Removed Status from insert
                        "VALUES (@type, @price, @start, @end); " +
                        "SELECT SCOPE_IDENTITY();", conn);
                }

                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);

                try
                {
                    if (isEditMode)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // For new memberships, link to customer
                        int membershipId = Convert.ToInt32(cmd.ExecuteScalar());
                        SqlCommand linkCmd = new SqlCommand(
                            "INSERT INTO SubscribesTo (CustomerID, MemberShipID) " +
                            "VALUES (@customerId, @membershipId)", conn);
                        linkCmd.Parameters.AddWithValue("@customerId", UserSession.CustomerID);
                        linkCmd.Parameters.AddWithValue("@membershipId", membershipId);
                        linkCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Membership saved successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadMemberships();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentMemberShipId == -1)
            {
                MessageBox.Show("Please select a membership to delete.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Delete this membership?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    // First delete the subscription link
                    SqlCommand deleteLinkCmd = new SqlCommand(
                        "DELETE FROM SubscribesTo WHERE MemberShipID = @id", conn);
                    deleteLinkCmd.Parameters.AddWithValue("@id", currentMemberShipId);
                    deleteLinkCmd.ExecuteNonQuery();

                    // Then delete the membership
                    SqlCommand deleteCmd = new SqlCommand(
                        "DELETE FROM MemberShip WHERE MemberShipID = @id", conn);
                    deleteCmd.Parameters.AddWithValue("@id", currentMemberShipId);

                    try
                    {
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Membership deleted.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                        LoadMemberships();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Delete Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            cmbType.SelectedIndex = 0;
            numPrice.Value = 0;
            numDuration.Value = 1;
            dtpStartDate.Value = DateTime.Today;
            cmbStatus.Text = "";
            currentMemberShipId = -1;
            isEditMode = false;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem != null)
            {
                numPrice.Value = cmbType.SelectedItem.ToString() == "Annual" ? 120 : 15;
            }
        }
    }
}