namespace MovieRentalTest
{
    partial class MemberShipForm
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
            dgvMemberships = new DataGridView();
            colMemberShipID = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colEndDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblType = new Label();
            cmbType = new ComboBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblDuration = new Label();
            numDuration = new NumericUpDown();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMemberships).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // dgvMemberships
            // 
            dgvMemberships.AllowUserToAddRows = false;
            dgvMemberships.AllowUserToDeleteRows = false;
            dgvMemberships.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMemberships.Columns.AddRange(new DataGridViewColumn[] { colMemberShipID, colType, colPrice, colStartDate, colEndDate, colStatus });
            dgvMemberships.Location = new Point(24, 257);
            dgvMemberships.Name = "dgvMemberships";
            dgvMemberships.ReadOnly = true;
            dgvMemberships.RowHeadersVisible = false;
            dgvMemberships.RowHeadersWidth = 62;
            dgvMemberships.Size = new Size(871, 266);
            dgvMemberships.TabIndex = 0;
            dgvMemberships.CellClick += dgvMemberships_CellClick;
            // 
            // colMemberShipID
            // 
            colMemberShipID.DataPropertyName = "MemberShipID";
            colMemberShipID.HeaderText = "ID";
            colMemberShipID.MinimumWidth = 8;
            colMemberShipID.Name = "colMemberShipID";
            colMemberShipID.ReadOnly = true;
            colMemberShipID.Width = 50;
            // 
            // colType
            // 
            colType.DataPropertyName = "Type";
            colType.HeaderText = "Type";
            colType.MinimumWidth = 8;
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 120;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price ($)";
            colPrice.MinimumWidth = 8;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 80;
            // 
            // colStartDate
            // 
            colStartDate.DataPropertyName = "StartDate";
            colStartDate.HeaderText = "Start Date";
            colStartDate.MinimumWidth = 8;
            colStartDate.Name = "colStartDate";
            colStartDate.ReadOnly = true;
            colStartDate.Width = 120;
            // 
            // colEndDate
            // 
            colEndDate.DataPropertyName = "EndDate";
            colEndDate.HeaderText = "End Date";
            colEndDate.MinimumWidth = 8;
            colEndDate.Name = "colEndDate";
            colEndDate.ReadOnly = true;
            colEndDate.Width = 120;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(24, 127);
            lblType.Name = "lblType";
            lblType.Size = new Size(63, 25);
            lblType.TabIndex = 1;
            lblType.Text = "Type :";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Annual", "Monthly" });
            cmbType.Location = new Point(91, 125);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(165, 33);
            cmbType.TabIndex = 2;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(24, 165);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(64, 25);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price :";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(91, 164);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(165, 31);
            numPrice.TabIndex = 4;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(274, 127);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(180, 25);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Duration (months) :";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(463, 125);
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(110, 31);
            numDuration.TabIndex = 6;
            numDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(381, 165);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 25);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status :";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Expired", "Cancelled" });
            cmbStatus.Location = new Point(463, 162);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(165, 33);
            cmbStatus.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(463, 201);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 40);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(610, 201);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(131, 40);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(764, 201);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(131, 40);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(84, 210);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(341, 31);
            dtpStartDate.TabIndex = 12;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(36, 215);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(38, 25);
            lblStartDate.TabIndex = 13;
            lblStartDate.Text = "⏱️";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(256, 40);
            label1.Name = "label1";
            label1.Size = new Size(339, 45);
            label1.TabIndex = 14;
            label1.Text = "Manage Membership";
            // 
            // MemberShipForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 547);
            Controls.Add(label1);
            Controls.Add(lblStartDate);
            Controls.Add(dtpStartDate);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(numDuration);
            Controls.Add(lblDuration);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(dgvMemberships);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "MemberShipForm";
            Text = "Manage Memberships - Movie Rental System";
            Load += MemberShipForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMemberships).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMemberships;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
        private DateTimePicker dtpStartDate;
        private Label lblStartDate;
        private DataGridViewTextBoxColumn colMemberShipID;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStartDate;
        private DataGridViewTextBoxColumn colEndDate;
        private DataGridViewTextBoxColumn colStatus;
        private Label label1;
    }
}