namespace MovieRentalTest
{
    partial class AdminDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnMovies = new Button();
            btnGenres = new Button();
            btnSuppliers = new Button();
            btnLogOut = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(227, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(286, 45);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Admin!";
            // 
            // btnMovies
            // 
            btnMovies.Location = new Point(12, 100);
            btnMovies.Name = "btnMovies";
            btnMovies.Size = new Size(234, 60);
            btnMovies.TabIndex = 1;
            btnMovies.Text = "Manage Movies";
            btnMovies.Click += btnMovies_Click;
            // 
            // btnGenres
            // 
            btnGenres.Location = new Point(252, 100);
            btnGenres.Name = "btnGenres";
            btnGenres.Size = new Size(234, 60);
            btnGenres.TabIndex = 2;
            btnGenres.Text = "Manage Genres";
            btnGenres.Click += btnGenres_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(494, 100);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(234, 60);
            btnSuppliers.TabIndex = 3;
            btnSuppliers.Text = "Manage Supply";
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(273, 191);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(197, 47);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "Log Out";
            btnLogOut.Click += btnLogOut_Click;
            // 
            // AdminDashBoard
            // 
            ClientSize = new Size(740, 249);
            Controls.Add(lblWelcome);
            Controls.Add(btnMovies);
            Controls.Add(btnGenres);
            Controls.Add(btnSuppliers);
            Controls.Add(btnLogOut);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "AdminDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label lblWelcome;
        private Button btnMovies;
        private Button btnSuppliers;
        private Button btnGenres;
        private Button btnLogOut;
    }
}