using System;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class UserDashBoard : Form
    {
        public UserDashBoard()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            if (!UserSession.IsLoggedIn || UserSession.IsAdmin)
            {
                MessageBox.Show("Access denied. Please login as customer.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblWelcomeUser.Text = $"Welcome, {UserSession.UserName}!";
            btnRentMovie.Enabled = UserSession.MemberShipID > 0;

            if (!btnRentMovie.Enabled)
            {
                btnRentMovie.Text += " (Requires Membership)";
            }
        }

        private void btnRentMovie_Click(object sender, EventArgs e)
        {
            if (UserSession.MemberShipID <= 0)
            {
                if (MessageBox.Show("Membership required. View memberships?",
                    "Rental Failed",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new MemberShipForm().ShowDialog();
                }
                return;
            }

            new MovieListForm().ShowDialog();
            btnRentMovie.Enabled = UserSession.MemberShipID > 0; // Refresh status
        }

        private void btnMemberShip_Click(object sender, EventArgs e)
        {
            new MemberShipForm().ShowDialog();
            btnRentMovie.Enabled = UserSession.MemberShipID > 0;
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            new ProfileUpdateForm().ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Close();
            new LogInForm().Show();
        }

        private void UserDashBoard_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn || UserSession.IsAdmin)
            {
                MessageBox.Show("Invalid access");
                this.Close();
            }
        }
    }
}