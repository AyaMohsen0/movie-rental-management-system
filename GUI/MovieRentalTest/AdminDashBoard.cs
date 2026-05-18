namespace MovieRentalTest
{
    public partial class AdminDashBoard : Form
    {
        public AdminDashBoard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, Admin {UserSession.UserName}!";
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            new MovieForm().ShowDialog();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            new GenreForm().ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            new SupplierForm().ShowDialog();
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

            if (!UserSession.IsAdmin)
            {
                MessageBox.Show("Admin access required");
                this.Close();
            }
        }
    }
}