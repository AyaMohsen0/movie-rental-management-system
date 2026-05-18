namespace MovieRentalTest
{
    partial class RegisterForm
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
            txtFName = new TextBox();
            LblFName = new Label();
            lblLName = new Label();
            txtLName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtPhoneNumber = new TextBox();
            txtCreditCard = new TextBox();
            txtResidenceAdd = new TextBox();
            txtBusinessAdd = new TextBox();
            lblEmail = new Label();
            lblPassword = new Label();
            lblPhoneNumber = new Label();
            lblCreditCardNum = new Label();
            lblResidenceAdd = new Label();
            lblBusinessAdd = new Label();
            lblStatus = new Label();
            btnRegister = new Button();
            chkShowPassword = new CheckBox();
            lblTitle = new Label();
            txtUserName = new TextBox();
            lblUserName = new Label();
            SuspendLayout();
            // 
            // txtFName
            // 
            txtFName.Location = new Point(256, 151);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(284, 34);
            txtFName.TabIndex = 0;
            // 
            // LblFName
            // 
            LblFName.AutoSize = true;
            LblFName.Location = new Point(94, 154);
            LblFName.Name = "LblFName";
            LblFName.Size = new Size(126, 28);
            LblFName.TabIndex = 1;
            LblFName.Text = "First Name :";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Location = new Point(96, 200);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(123, 28);
            lblLName.TabIndex = 2;
            lblLName.Text = "Last Name :";
            // 
            // txtLName
            // 
            txtLName.Location = new Point(256, 197);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(284, 34);
            txtLName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(256, 277);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(284, 34);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(256, 316);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(284, 34);
            txtPassword.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(256, 357);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(284, 34);
            txtPhoneNumber.TabIndex = 6;
            // 
            // txtCreditCard
            // 
            txtCreditCard.Location = new Point(256, 398);
            txtCreditCard.Name = "txtCreditCard";
            txtCreditCard.Size = new Size(284, 34);
            txtCreditCard.TabIndex = 7;
            // 
            // txtResidenceAdd
            // 
            txtResidenceAdd.Location = new Point(256, 438);
            txtResidenceAdd.Name = "txtResidenceAdd";
            txtResidenceAdd.Size = new Size(284, 34);
            txtResidenceAdd.TabIndex = 9;
            // 
            // txtBusinessAdd
            // 
            txtBusinessAdd.Location = new Point(256, 480);
            txtBusinessAdd.Name = "txtBusinessAdd";
            txtBusinessAdd.Size = new Size(284, 34);
            txtBusinessAdd.TabIndex = 10;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(141, 280);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(75, 28);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(106, 319);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(112, 28);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Password :";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(51, 360);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(165, 28);
            lblPhoneNumber.TabIndex = 13;
            lblPhoneNumber.Text = "Phone Number :";
            // 
            // lblCreditCardNum
            // 
            lblCreditCardNum.AutoSize = true;
            lblCreditCardNum.Location = new Point(69, 401);
            lblCreditCardNum.Name = "lblCreditCardNum";
            lblCreditCardNum.Size = new Size(147, 28);
            lblCreditCardNum.TabIndex = 14;
            lblCreditCardNum.Text = "Credit Card # :";
            // 
            // lblResidenceAdd
            // 
            lblResidenceAdd.AutoSize = true;
            lblResidenceAdd.Location = new Point(17, 442);
            lblResidenceAdd.Name = "lblResidenceAdd";
            lblResidenceAdd.Size = new Size(199, 28);
            lblResidenceAdd.TabIndex = 16;
            lblResidenceAdd.Text = "Residence Address :";
            // 
            // lblBusinessAdd
            // 
            lblBusinessAdd.AutoSize = true;
            lblBusinessAdd.Location = new Point(32, 483);
            lblBusinessAdd.Name = "lblBusinessAdd";
            lblBusinessAdd.Size = new Size(185, 28);
            lblBusinessAdd.TabIndex = 17;
            lblBusinessAdd.Text = "Business Address :";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(69, 643);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 28);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "Status :";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(256, 532);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(164, 78);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(546, 319);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(184, 32);
            chkShowPassword.TabIndex = 20;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(155, 52);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(408, 45);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "Movie Rental Registration";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(256, 237);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(284, 34);
            txtUserName.TabIndex = 23;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(89, 240);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(127, 28);
            lblUserName.TabIndex = 22;
            lblUserName.Text = "User Name :";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 723);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(lblTitle);
            Controls.Add(chkShowPassword);
            Controls.Add(btnRegister);
            Controls.Add(lblStatus);
            Controls.Add(lblBusinessAdd);
            Controls.Add(lblResidenceAdd);
            Controls.Add(lblCreditCardNum);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(txtBusinessAdd);
            Controls.Add(txtResidenceAdd);
            Controls.Add(txtCreditCard);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtLName);
            Controls.Add(lblLName);
            Controls.Add(LblFName);
            Controls.Add(txtFName);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Name = "RegisterForm";
            Text = "RegisterForm - Movie Rental System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFName;
        private Label LblFName;
        private Label lblLName;
        private TextBox txtLName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtPhoneNumber;
        private TextBox txtCreditCard;
        private TextBox txtResidenceAdd;
        private TextBox txtBusinessAdd;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblPhoneNumber;
        private Label lblCreditCardNum;
        private Label lblResidenceAdd;
        private Label lblBusinessAdd;
        private Label lblStatus;
        private Button btnRegister;
        private CheckBox chkShowPassword;
        private Label lblTitle;
        private TextBox txtUserName;
        private Label lblUserName;
    }
}