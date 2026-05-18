using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;

namespace MovieRentalTest
{
    partial class MovieSupplyForm
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
            dgvMovieSupplies = new DataGridView();
            colMovieID = new DataGridViewTextBoxColumn();
            colMovieTitle = new DataGridViewTextBoxColumn();
            colSupplierName = new DataGridViewTextBoxColumn();
            colSupplyDate = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnDelete = new Button();
            cmbSuppliers = new ComboBox();
            lblSupplier = new Label();
            cmbMovies = new ComboBox();
            lblMovie = new Label();
            dtpSupplyDate = new DateTimePicker();
            lblDate = new Label();
            lblManageSupply = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMovieSupplies).BeginInit();
            SuspendLayout();
            // 
            // dgvMovieSupplies
            // 
            dgvMovieSupplies.AllowUserToAddRows = false;
            dgvMovieSupplies.AllowUserToDeleteRows = false;
            dgvMovieSupplies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovieSupplies.Columns.AddRange(new DataGridViewColumn[] { colMovieID, colMovieTitle, colSupplierName, colSupplyDate });
            dgvMovieSupplies.Location = new Point(15, 276);
            dgvMovieSupplies.Name = "dgvMovieSupplies";
            dgvMovieSupplies.ReadOnly = true;
            dgvMovieSupplies.RowHeadersVisible = false;
            dgvMovieSupplies.RowHeadersWidth = 62;
            dgvMovieSupplies.Size = new Size(660, 300);
            dgvMovieSupplies.TabIndex = 0;
            // 
            // colMovieID
            // 
            colMovieID.DataPropertyName = "MovieID";
            colMovieID.HeaderText = "Movie ID";
            colMovieID.MinimumWidth = 8;
            colMovieID.Name = "colMovieID";
            colMovieID.ReadOnly = true;
            colMovieID.Width = 80;
            // 
            // colMovieTitle
            // 
            colMovieTitle.DataPropertyName = "Title";
            colMovieTitle.HeaderText = "Movie Title";
            colMovieTitle.MinimumWidth = 8;
            colMovieTitle.Name = "colMovieTitle";
            colMovieTitle.ReadOnly = true;
            colMovieTitle.Width = 150;
            // 
            // colSupplierName
            // 
            colSupplierName.DataPropertyName = "SupplierName";
            colSupplierName.HeaderText = "Supplier";
            colSupplierName.MinimumWidth = 8;
            colSupplierName.Name = "colSupplierName";
            colSupplierName.ReadOnly = true;
            colSupplierName.Width = 150;
            // 
            // colSupplyDate
            // 
            colSupplyDate.DataPropertyName = "SupplyDate";
            colSupplyDate.HeaderText = "Supply Date";
            colSupplyDate.MinimumWidth = 8;
            colSupplyDate.Name = "colSupplyDate";
            colSupplyDate.ReadOnly = true;
            colSupplyDate.Width = 120;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(422, 197);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 59);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(565, 197);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 59);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(15, 152);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(253, 33);
            cmbSuppliers.TabIndex = 3;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(15, 124);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(88, 25);
            lblSupplier.TabIndex = 4;
            lblSupplier.Text = "Supplier:";
            // 
            // cmbMovies
            // 
            cmbMovies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovies.FormattingEnabled = true;
            cmbMovies.Location = new Point(289, 152);
            cmbMovies.Name = "cmbMovies";
            cmbMovies.Size = new Size(386, 33);
            cmbMovies.TabIndex = 5;
            // 
            // lblMovie
            // 
            lblMovie.AutoSize = true;
            lblMovie.Location = new Point(289, 124);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(70, 25);
            lblMovie.TabIndex = 6;
            lblMovie.Text = "Movie:";
            // 
            // dtpSupplyDate
            // 
            dtpSupplyDate.Location = new Point(15, 225);
            dtpSupplyDate.Name = "dtpSupplyDate";
            dtpSupplyDate.Size = new Size(377, 31);
            dtpSupplyDate.TabIndex = 7;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(15, 197);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(57, 25);
            lblDate.TabIndex = 8;
            lblDate.Text = "Date:";
            // 
            // lblManageSupply
            // 
            lblManageSupply.AutoSize = true;
            lblManageSupply.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblManageSupply.Location = new Point(188, 39);
            lblManageSupply.Name = "lblManageSupply";
            lblManageSupply.Size = new Size(253, 45);
            lblManageSupply.TabIndex = 9;
            lblManageSupply.Text = "Manage Supply";
            // 
            // MovieSupplyForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 591);
            Controls.Add(lblManageSupply);
            Controls.Add(lblDate);
            Controls.Add(dtpSupplyDate);
            Controls.Add(lblMovie);
            Controls.Add(cmbMovies);
            Controls.Add(lblSupplier);
            Controls.Add(cmbSuppliers);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvMovieSupplies);
            Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "MovieSupplyForm";
            Text = "Manage Movie Supplies - Movie Rental System";
            Load += MovieSupplyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovieSupplies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovieSupplies;
        private Button btnAdd;
        private Button btnDelete;
        private ComboBox cmbSuppliers;
        private Label lblSupplier;
        private ComboBox cmbMovies;
        private Label lblMovie;
        private DateTimePicker dtpSupplyDate;
        private Label lblDate;
        private DataGridViewTextBoxColumn colMovieID;
        private DataGridViewTextBoxColumn colMovieTitle;
        private DataGridViewTextBoxColumn colSupplierName;
        private DataGridViewTextBoxColumn colSupplyDate;
        private Label lblManageSupply;
    }
}