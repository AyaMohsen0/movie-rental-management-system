namespace MovieRentalTest
{
    partial class ProfileUpdateForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            chkShowPassword = new CheckBox();
            lblBusinessAdd = new Label();
            lblResidenceAdd = new Label();
            lblCreditCardNum = new Label();
            lblPhoneNumber = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            txtBusinessAdd = new TextBox();
            txtResidenceAdd = new TextBox();
            txtCreditCard = new TextBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtLName = new TextBox();
            lblLName = new Label();
            LblFName = new Label();
            txtFName = new TextBox();
            txtUserName = new TextBox();
            lblUserName = new Label();
            lblUserNameWarning = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(207, 474);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(132, 40);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(386, 474);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(132, 40);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(227, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Update Profile";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(525, 280);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(169, 29);
            chkShowPassword.TabIndex = 52;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // lblBusinessAdd
            // 
            lblBusinessAdd.AutoSize = true;
            lblBusinessAdd.Location = new Point(29, 428);
            lblBusinessAdd.Name = "lblBusinessAdd";
            lblBusinessAdd.Size = new Size(168, 25);
            lblBusinessAdd.TabIndex = 51;
            lblBusinessAdd.Text = "Business Address :";
            // 
            // lblResidenceAdd
            // 
            lblResidenceAdd.AutoSize = true;
            lblResidenceAdd.Location = new Point(15, 391);
            lblResidenceAdd.Name = "lblResidenceAdd";
            lblResidenceAdd.Size = new Size(181, 25);
            lblResidenceAdd.TabIndex = 50;
            lblResidenceAdd.Text = "Residence Address :";
            // 
            // lblCreditCardNum
            // 
            lblCreditCardNum.AutoSize = true;
            lblCreditCardNum.Location = new Point(64, 354);
            lblCreditCardNum.Name = "lblCreditCardNum";
            lblCreditCardNum.Size = new Size(133, 25);
            lblCreditCardNum.TabIndex = 48;
            lblCreditCardNum.Text = "Credit Card # :";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(47, 317);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(150, 25);
            lblPhoneNumber.TabIndex = 47;
            lblPhoneNumber.Text = "Phone Number :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(94, 280);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(102, 25);
            lblPassword.TabIndex = 46;
            lblPassword.Text = "Password :";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(129, 243);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(68, 25);
            lblEmail.TabIndex = 45;
            lblEmail.Text = "Email :";
            // 
            // txtBusinessAdd
            // 
            txtBusinessAdd.Location = new Point(206, 425);
            txtBusinessAdd.Name = "txtBusinessAdd";
            txtBusinessAdd.Size = new Size(312, 31);
            txtBusinessAdd.TabIndex = 44;
            // 
            // txtResidenceAdd
            // 
            txtResidenceAdd.Location = new Point(206, 388);
            txtResidenceAdd.Name = "txtResidenceAdd";
            txtResidenceAdd.Size = new Size(312, 31);
            txtResidenceAdd.TabIndex = 43;
            // 
            // txtCreditCard
            // 
            txtCreditCard.Location = new Point(206, 351);
            txtCreditCard.Name = "txtCreditCard";
            txtCreditCard.Size = new Size(312, 31);
            txtCreditCard.TabIndex = 41;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(206, 314);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(312, 31);
            txtPhoneNumber.TabIndex = 40;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(206, 277);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(312, 31);
            txtPassword.TabIndex = 39;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(206, 240);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(312, 31);
            txtEmail.TabIndex = 38;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(206, 163);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(312, 31);
            txtLName.TabIndex = 37;
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Location = new Point(85, 166);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(111, 25);
            lblLName.TabIndex = 36;
            lblLName.Text = "Last Name :";
            // 
            // LblFName
            // 
            LblFName.AutoSize = true;
            LblFName.Location = new Point(82, 129);
            LblFName.Name = "LblFName";
            LblFName.Size = new Size(113, 25);
            LblFName.TabIndex = 35;
            LblFName.Text = "First Name :";
            // 
            // txtFName
            // 
            txtFName.Location = new Point(206, 126);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(312, 31);
            txtFName.TabIndex = 34;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(206, 203);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(312, 31);
            txtUserName.TabIndex = 54;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(82, 206);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(115, 25);
            lblUserName.TabIndex = 53;
            lblUserName.Text = "User Name :";
            // 
            // lblUserNameWarning
            // 
            lblUserNameWarning.AutoSize = true;
            lblUserNameWarning.Location = new Point(525, 206);
            lblUserNameWarning.Name = "lblUserNameWarning";
            lblUserNameWarning.Size = new Size(0, 25);
            lblUserNameWarning.TabIndex = 55;
            // 
            // ProfileUpdateForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 535);
            Controls.Add(lblUserNameWarning);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(chkShowPassword);
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
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "ProfileUpdateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Your Profile - Movie Rental System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSave;
        private Button btnCancel;
        private Label lblTitle;
        private CheckBox chkShowPassword;
        private Label lblBusinessAdd;
        private Label lblResidenceAdd;
        private Label lblCreditCardNum;
        private Label lblPhoneNumber;
        private Label lblPassword;
        private Label lblEmail;
        private TextBox txtBusinessAdd;
        private TextBox txtResidenceAdd;
        private TextBox txtCreditCard;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtLName;
        private Label lblLName;
        private Label LblFName;
        private TextBox txtFName;
        private TextBox txtUserName;
        private Label lblUserName;
        private Label lblUserNameWarning;
    }
}