namespace MovieRentalTest
{
    partial class UserDashBoard
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
            btnMemberShip = new Button();
            btnUpdateProfile = new Button();
            btnRentMovie = new Button();
            btnLogOut = new Button();
            lblWelcomeUser = new Label();
            SuspendLayout();
            // 
            // btnMemberShip
            // 
            btnMemberShip.Location = new Point(254, 102);
            btnMemberShip.Name = "btnMemberShip";
            btnMemberShip.Size = new Size(234, 60);
            btnMemberShip.TabIndex = 7;
            btnMemberShip.Text = "View Membership";
            btnMemberShip.Click += btnMemberShip_Click;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.Location = new Point(495, 102);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(234, 60);
            btnUpdateProfile.TabIndex = 8;
            btnUpdateProfile.Text = "Update Profile";
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // btnRentMovie
            // 
            btnRentMovie.Location = new Point(12, 102);
            btnRentMovie.Name = "btnRentMovie";
            btnRentMovie.Size = new Size(234, 60);
            btnRentMovie.TabIndex = 10;
            btnRentMovie.Text = "Rent Movies";
            btnRentMovie.Click += btnRentMovie_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(271, 193);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(197, 47);
            btnLogOut.TabIndex = 11;
            btnLogOut.Text = "Log Out";
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcomeUser.Location = new Point(149, 29);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(339, 45);
            lblWelcomeUser.TabIndex = 5;
            lblWelcomeUser.Text = "Welcome, Customer !";
            // 
            // UserDashBoard
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 252);
            Controls.Add(btnLogOut);
            Controls.Add(btnRentMovie);
            Controls.Add(lblWelcomeUser);
            Controls.Add(btnMemberShip);
            Controls.Add(btnUpdateProfile);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "UserDashBoard";
            Text = "UserDashBoard";
            Load += UserDashBoard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMemberShip;
        private Button btnUpdateProfile;
        private Button btnRentMovie;
        private Button btnLogOut;
        private Label lblWelcomeUser;
    }
}