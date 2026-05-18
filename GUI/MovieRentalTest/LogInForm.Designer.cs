namespace MovieRentalTest
{
    partial class LogInForm
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
            lblTitle = new Label();
            lblID = new Label();
            lblPassword = new Label();
            txtID = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            btnLogIn = new Button();
            lblStatus = new Label();
            chkShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(272, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Movie Rental System";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(83, 199);
            lblID.Name = "lblID";
            lblID.Size = new Size(44, 28);
            lblID.TabIndex = 1;
            lblID.Text = "ID :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(14, 240);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(112, 28);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password :";
            // 
            // txtID
            // 
            txtID.Location = new Point(136, 199);
            txtID.Name = "txtID";
            txtID.Size = new Size(608, 34);
            txtID.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(136, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(608, 34);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(460, 304);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(180, 132);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(201, 304);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(184, 132);
            btnLogIn.TabIndex = 7;
            btnLogIn.Text = "Login";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(136, 148);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(274, 28);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Enter your ID and password";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(750, 242);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(184, 32);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // LogInForm
            // 
            AcceptButton = btnLogIn;
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 473);
            Controls.Add(chkShowPassword);
            Controls.Add(lblStatus);
            Controls.Add(btnLogIn);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtID);
            Controls.Add(lblPassword);
            Controls.Add(lblID);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Movie Rental System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblID;
        private Label lblPassword;
        private TextBox txtID;
        private TextBox txtPassword;
        private Button btnRegister;
        private Button btnLogIn;
        private Label lblStatus;
        private CheckBox chkShowPassword;
    }
}