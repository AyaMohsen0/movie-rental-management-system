namespace MovieRentalTest
{
    partial class SupplierForm
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
            lblSupplierName = new Label();
            txtSupplierName = new TextBox();
            lblSupplierEmail = new Label();
            txtSupplierEmail = new TextBox();
            lblSupplierPhone = new Label();
            txtSupplierPhone = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            dgvSuppliers = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // lblSupplierName
            // 
            lblSupplierName.AutoSize = true;
            lblSupplierName.Location = new Point(13, 15);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(67, 25);
            lblSupplierName.TabIndex = 0;
            lblSupplierName.Text = "Name:";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(165, 12);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(330, 31);
            txtSupplierName.TabIndex = 1;
            // 
            // lblSupplierEmail
            // 
            lblSupplierEmail.AutoSize = true;
            lblSupplierEmail.Location = new Point(13, 52);
            lblSupplierEmail.Name = "lblSupplierEmail";
            lblSupplierEmail.Size = new Size(63, 25);
            lblSupplierEmail.TabIndex = 2;
            lblSupplierEmail.Text = "Email:";
            // 
            // txtSupplierEmail
            // 
            txtSupplierEmail.Location = new Point(165, 49);
            txtSupplierEmail.Name = "txtSupplierEmail";
            txtSupplierEmail.Size = new Size(330, 31);
            txtSupplierEmail.TabIndex = 3;
            // 
            // lblSupplierPhone
            // 
            lblSupplierPhone.AutoSize = true;
            lblSupplierPhone.Location = new Point(13, 89);
            lblSupplierPhone.Name = "lblSupplierPhone";
            lblSupplierPhone.Size = new Size(71, 25);
            lblSupplierPhone.TabIndex = 4;
            lblSupplierPhone.Text = "Phone:";
            // 
            // txtSupplierPhone
            // 
            txtSupplierPhone.Location = new Point(165, 86);
            txtSupplierPhone.Name = "txtSupplierPhone";
            txtSupplierPhone.Size = new Size(330, 31);
            txtSupplierPhone.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(165, 130);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(132, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(308, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(132, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] { colName, colEmail, colPhone });
            dgvSuppliers.Location = new Point(13, 190);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.RowHeadersWidth = 62;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.Size = new Size(482, 200);
            dgvSuppliers.TabIndex = 8;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // colName
            // 
            colName.DataPropertyName = "SupplierName";
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "SupplierEmail";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 150;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "SupplierPhone";
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 8;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            colPhone.Width = 150;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(363, 400);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 450);
            Controls.Add(btnDelete);
            Controls.Add(dgvSuppliers);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSupplierPhone);
            Controls.Add(lblSupplierPhone);
            Controls.Add(txtSupplierEmail);
            Controls.Add(lblSupplierEmail);
            Controls.Add(txtSupplierName);
            Controls.Add(lblSupplierName);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "SupplierForm";
            Text = "Manage Suppliers - Movie Rental System";
            Load += SupplierForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSupplierName;
        private TextBox txtSupplierName;
        private Label lblSupplierEmail;
        private TextBox txtSupplierEmail;
        private Label lblSupplierPhone;
        private TextBox txtSupplierPhone;
        private Button btnSave;
        private Button btnCancel;
        private DataGridView dgvSuppliers;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private Button btnDelete;
    }
}