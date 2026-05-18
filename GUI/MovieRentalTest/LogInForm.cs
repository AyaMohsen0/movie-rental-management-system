using System;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MovieRentalTest
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.AcceptButton = btnLogIn;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtPassword.UseSystemPasswordChar = true;
            UpdateStatus("Enter your credentials", Color.Blue);
        }

        private void UpdateStatus(string message, Color color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            string input = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(password))
            {
                UpdateStatus("Please enter both ID and password", Color.Red);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btnLogIn.Enabled = false;

                if (await TryAdminLogin(input, password) || await TryCustomerLogin(input, password))
                    return;

                UpdateStatus("Invalid credentials", Color.Red);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnLogIn.Enabled = true;
            }
        }

        private async Task<bool> TryAdminLogin(string input, string password)
        {
            if (!input.StartsWith("A", StringComparison.OrdinalIgnoreCase) && !input.Contains("@admin.com"))
                return false;

            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("SELECT AdminID, Password FROM Admin WHERE AdminID = @id OR Email = @id", conn);
                cmd.Parameters.AddWithValue("@id", input);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string storedPassword = reader["Password"].ToString();
                        if (password == storedPassword)
                        {
                            UserSession.Login(0, 0, reader["AdminID"].ToString(), true);
                            new AdminDashBoard().Show();
                            this.Hide();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> TryCustomerLogin(string input, string password)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd;

                if (int.TryParse(input, out int customerId))
                {
                    cmd = new SqlCommand(@"
                        SELECT c.CustomerID, c.Password, c.UserName,
                        ISNULL((SELECT TOP 1 MemberShipID FROM SubscribesTo WHERE CustomerID = c.CustomerID), 0) AS MemberShipID
                        FROM Customer c WHERE c.CustomerID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                }
                else
                {
                    cmd = new SqlCommand(@"
                        SELECT c.CustomerID, c.Password, c.UserName,
                        ISNULL((SELECT TOP 1 MemberShipID FROM SubscribesTo WHERE CustomerID = c.CustomerID), 0) AS MemberShipID
                        FROM Customer c WHERE c.UserName = @input OR c.Email = @input", conn);
                    cmd.Parameters.AddWithValue("@input", input);
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string storedPassword = reader["Password"].ToString();
                        if (password == storedPassword)
                        {
                            UserSession.Login(
                                reader.GetInt32(0),
                                reader.GetInt32(3),
                                reader.GetString(2),
                                false);

                            new UserDashBoard().Show();
                            this.Hide();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            if (id.Length > 0)
            {
                bool looksLikeAdmin = id.StartsWith("A", StringComparison.OrdinalIgnoreCase) || id.Contains("@admin.com");
                UpdateStatus(
                    looksLikeAdmin ? "Logging in as admin" : "Logging in as customer",
                    looksLikeAdmin ? Color.Blue : Color.Green);
            }
        }
    }
}