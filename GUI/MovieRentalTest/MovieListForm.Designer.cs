using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovieRentalTest
{
    partial class MovieListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtSearchTitle = new TextBox();
            lblSearchTitle = new Label();
            cmbGenre = new ComboBox();
            lblGenre = new Label();
            numYear = new NumericUpDown();
            lblYear = new Label();
            txtLeadActor = new TextBox();
            lblLeadActor = new Label();
            btnSearch = new Button();
            dgvMovies = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            colYear = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colAvailable = new DataGridViewTextBoxColumn();
            colRent = new DataGridViewButtonColumn();
            lblSearchMovie = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(75, 119);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(200, 31);
            txtSearchTitle.TabIndex = 1;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Location = new Point(12, 122);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(55, 25);
            lblSearchTitle.TabIndex = 0;
            lblSearchTitle.Text = "Title:";
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Location = new Point(349, 118);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(120, 33);
            cmbGenre.TabIndex = 3;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(281, 122);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(68, 25);
            lblGenre.TabIndex = 2;
            lblGenre.Text = "Genre:";
            // 
            // numYear
            // 
            numYear.Location = new Point(529, 119);
            numYear.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(70, 31);
            numYear.TabIndex = 5;
            numYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(475, 122);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(54, 25);
            lblYear.TabIndex = 4;
            lblYear.Text = "Year:";
            // 
            // txtLeadActor
            // 
            txtLeadActor.Location = new Point(712, 118);
            txtLeadActor.Name = "txtLeadActor";
            txtLeadActor.Size = new Size(150, 31);
            txtLeadActor.TabIndex = 7;
            // 
            // lblLeadActor
            // 
            lblLeadActor.AutoSize = true;
            lblLeadActor.Location = new Point(605, 121);
            lblLeadActor.Name = "lblLeadActor";
            lblLeadActor.Size = new Size(110, 25);
            lblLeadActor.TabIndex = 6;
            lblLeadActor.Text = "Lead Actor:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(868, 109);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(83, 50);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click_1;
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToAddRows = false;
            dgvMovies.AllowUserToDeleteRows = false;
            dgvMovies.ColumnHeadersHeight = 34;
            dgvMovies.Columns.AddRange(new DataGridViewColumn[] { colTitle, colGenre, colYear, colPrice, colAvailable, colRent });
            dgvMovies.Location = new Point(21, 174);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.ReadOnly = true;
            dgvMovies.RowHeadersWidth = 62;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(930, 350);
            dgvMovies.TabIndex = 9;
            dgvMovies.CellContentClick += dgvMovies_CellContentClick;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 8;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 150;
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Genre";
            colGenre.MinimumWidth = 8;
            colGenre.Name = "colGenre";
            colGenre.ReadOnly = true;
            colGenre.Width = 150;
            // 
            // colYear
            // 
            colYear.HeaderText = "Year";
            colYear.MinimumWidth = 8;
            colYear.Name = "colYear";
            colYear.ReadOnly = true;
            colYear.Width = 150;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price Per Day";
            colPrice.MinimumWidth = 8;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 150;
            // 
            // colAvailable
            // 
            colAvailable.HeaderText = "Available";
            colAvailable.MinimumWidth = 8;
            colAvailable.Name = "colAvailable";
            colAvailable.ReadOnly = true;
            colAvailable.Width = 150;
            // 
            // colRent
            // 
            colRent.HeaderText = "Rent";
            colRent.MinimumWidth = 8;
            colRent.Name = "colRent";
            colRent.ReadOnly = true;
            colRent.Width = 150;
            // 
            // lblSearchMovie
            // 
            lblSearchMovie.AutoSize = true;
            lblSearchMovie.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSearchMovie.Location = new Point(349, 41);
            lblSearchMovie.Name = "lblSearchMovie";
            lblSearchMovie.Size = new Size(236, 45);
            lblSearchMovie.TabIndex = 10;
            lblSearchMovie.Text = "Search Movies";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(853, 48);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(98, 42);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // MovieListForm
            // 
            ClientSize = new Size(969, 543);
            Controls.Add(btnRefresh);
            Controls.Add(lblSearchMovie);
            Controls.Add(lblSearchTitle);
            Controls.Add(txtSearchTitle);
            Controls.Add(lblGenre);
            Controls.Add(cmbGenre);
            Controls.Add(lblYear);
            Controls.Add(numYear);
            Controls.Add(lblLeadActor);
            Controls.Add(txtLeadActor);
            Controls.Add(btnSearch);
            Controls.Add(dgvMovies);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "MovieListForm";
            Text = "Select Movie to Rent - Movie Rental System";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchTitle;
        private Label lblSearchTitle;
        private ComboBox cmbGenre;
        private Label lblGenre;
        private NumericUpDown numYear;
        private Label lblYear;
        private TextBox txtLeadActor;
        private Label lblLeadActor;
        private Button btnSearch;
        private DataGridView dgvMovies;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colGenre;
        private DataGridViewTextBoxColumn colYear;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colAvailable;
        private DataGridViewButtonColumn colRent;
        private Label lblSearchMovie;
        private Button btnRefresh;
    }
}
