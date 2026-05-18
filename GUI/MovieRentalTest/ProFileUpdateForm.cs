using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRentalTest
{
    public partial class ProfileUpdateForm : Form
    {
        private string originalUsername;
        private string originalEmail;

        public ProfileUpdateForm()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if (!UserSession.IsLoggedIn || UserSession.IsAdmin)
            {
                MessageBox.Show("Access denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT Fname, Lname, UserName, Email, PhoneNumber, 
                      CreditCardNumber, BusinessAddress, ResidenceAddress 
                      FROM Customer WHERE CustomerID = @id", conn);

                cmd.Parameters.AddWithValue("@id", UserSession.CustomerID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFName.Text = reader["Fname"].ToString();
                        txtLName.Text = reader["Lname"].ToString();
                        txtUserName.Text = reader["UserName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtCreditCard.Text = reader["CreditCardNumber"].ToString();
                        txtBusinessAdd.Text = reader["BusinessAddress"].ToString();
                        txtResidenceAdd.Text = reader["ResidenceAddress"].ToString();

                        // Store original values for duplicate checking
                        originalUsername = txtUserName.Text.Trim();
                        originalEmail = txtEmail.Text.Trim();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("First name, last name, username and email are required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email format", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
                {
                    conn.Open();

                    // Check for username/email conflicts (only if changed)
                    if (txtUserName.Text.Trim() != originalUsername ||
                        txtEmail.Text.Trim() != originalEmail)
                    {
                        SqlCommand checkCmd = new SqlCommand(
                            @"SELECT COUNT(*) FROM Customer 
                              WHERE (UserName = @username OR Email = @email)
                              AND CustomerID != @id", conn);

                        checkCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@id", UserSession.CustomerID);

                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Username or email already in use by another account", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update profile
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Customer SET 
                          Fname = @fname,
                          Lname = @lname,
                          UserName = @username,
                          Email = @email,
                          PhoneNumber = @phone,
                          CreditCardNumber = @card,
                          BusinessAddress = @businessAddr,
                          ResidenceAddress = @residenceAddr
                          WHERE CustomerID = @id", conn);

                    cmd.Parameters.AddWithValue("@id", UserSession.CustomerID);
                    cmd.Parameters.AddWithValue("@fname", txtFName.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", txtLName.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@card", txtCreditCard.Text.Trim());
                    cmd.Parameters.AddWithValue("@businessAddr", txtBusinessAdd.Text.Trim());
                    cmd.Parameters.AddWithValue("@residenceAddr", txtResidenceAdd.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No changes were made to your profile", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Optional: Add username validation as user types
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            // Example validation - usernames must be 4-20 alphanumeric characters
            if (txtUserName.Text.Length > 0 &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text, "^[a-zA-Z0-9]{4,20}$"))
            {
                lblUserNameWarning.Text = "4-20 alphanumeric characters only";
                lblUserNameWarning.ForeColor = Color.Red;
            }
            else
            {
                lblUserNameWarning.Text = "";
            }
        }
    }
}