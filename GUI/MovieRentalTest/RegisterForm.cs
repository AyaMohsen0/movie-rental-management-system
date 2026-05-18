using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Data.SqlClient;

namespace MovieRentalTest
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            lblStatus.Text = "Please fill the form";
            lblStatus.ForeColor = Color.Red;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblStatus.Text = "Please fill all required fields";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                lblStatus.Text = "Invalid email format";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                lblStatus.Text = "Password must be 8+ characters";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            if (txtEmail.Text.EndsWith("@admin.com"))
            {
                lblStatus.Text = "Admin accounts cannot be registered here";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private async Task<bool> UserExists(SqlConnection conn)
        {
            string checkSql = @"SELECT COUNT(*) FROM Customer 
                              WHERE Email = @email OR UserName = @username";

            using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                checkCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());

                int count = (int)await checkCmd.ExecuteScalarAsync();
                if (count > 0)
                {
                    lblStatus.Text = "Email or Username already registered";
                    lblStatus.ForeColor = Color.Red;
                    return true;
                }
            }
            return false;
        }

        private async Task<int> CreateCustomer(SqlConnection conn)
        {
            string customerSql = @"INSERT INTO Customer 
                (Fname, Lname, UserName, Password, Email, PhoneNumber, 
                 CreditCardNumber, BusinessAddress, ResidenceAddress)
                OUTPUT INSERTED.CustomerID
                VALUES (@fname, @lname, @username, @password, @email, @phone, 
                        @card, @bizAddr, @resAddr)";

            using (SqlCommand customerCmd = new SqlCommand(customerSql, conn))
            {
                customerCmd.Parameters.AddWithValue("@fname", txtFName.Text.Trim());
                customerCmd.Parameters.AddWithValue("@lname", txtLName.Text.Trim());
                customerCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                customerCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                customerCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                // Handle optional fields
                customerCmd.Parameters.AddWithValue("@phone",
                    string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? DBNull.Value : (object)txtPhoneNumber.Text.Trim());
                customerCmd.Parameters.AddWithValue("@card",
                    string.IsNullOrWhiteSpace(txtCreditCard.Text) ? DBNull.Value : (object)txtCreditCard.Text.Trim());
                customerCmd.Parameters.AddWithValue("@bizAddr",
                    string.IsNullOrWhiteSpace(txtBusinessAdd.Text) ? DBNull.Value : (object)txtBusinessAdd.Text.Trim());
                customerCmd.Parameters.AddWithValue("@resAddr",
                    string.IsNullOrWhiteSpace(txtResidenceAdd.Text) ? DBNull.Value : (object)txtResidenceAdd.Text.Trim());

                return Convert.ToInt32(await customerCmd.ExecuteScalarAsync());
            }
        }

        private async Task<int> CreateAndLinkMembership(SqlConnection conn, int customerId)
        {
            // Create membership
            string memberSql = @"INSERT INTO MemberShip 
                (Price, StartDate, EndDate, Status, Type) 
                OUTPUT INSERTED.MemberShipID
                VALUES (9.99, GETDATE(), DATEADD(MONTH, 1, GETDATE()), 'Active', 'Monthly')";

            int memberShipId;
            using (SqlCommand memberCmd = new SqlCommand(memberSql, conn))
            {
                memberShipId = Convert.ToInt32(await memberCmd.ExecuteScalarAsync());
            }

            // Link membership
            string subscribeSql = "INSERT INTO SubscribesTo (CustomerID, MemberShipID) VALUES (@cid, @mid)";
            using (SqlCommand subscribeCmd = new SqlCommand(subscribeSql, conn))
            {
                subscribeCmd.Parameters.AddWithValue("@cid", customerId);
                subscribeCmd.Parameters.AddWithValue("@mid", memberShipId);
                await subscribeCmd.ExecuteNonQueryAsync();
            }

            return memberShipId;
        }

        private void ShowSuccessMessage(int customerId)
        {
            lblStatus.Text = $"Registered successfully! Your ID: {customerId}";
            lblStatus.ForeColor = Color.Green;

            MessageBox.Show($"Registration successful!\n\nYour details:\nUsername: {txtUserName.Text}\nCustomer ID: {customerId}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private async void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    await conn.OpenAsync();

                    // Check if user exists first
                    if (await UserExists(conn))
                    {
                        return;
                    }

                    // Create customer
                    int customerId = await CreateCustomer(conn);

                    // Create and link membership
                    int memberShipId = await CreateAndLinkMembership(conn, customerId);

                    ShowSuccessMessage(customerId);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Registration failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}