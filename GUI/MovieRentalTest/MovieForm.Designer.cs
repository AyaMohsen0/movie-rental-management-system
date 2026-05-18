using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovieRentalTest
{
    partial class MovieForm
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
            txtTitle = new TextBox();
            txtLeadActor = new TextBox();
            numYear = new NumericUpDown();
            numCopies = new NumericUpDown();
            numPrice = new NumericUpDown();
            clbGenres = new CheckedListBox();
            btnAdd = new Button();
            btnManageGenres = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvMovies = new DataGridView();
            lblTitle = new Label();
            lblActor = new Label();
            lblYear = new Label();
            lblCopies = new Label();
            lblPrice = new Label();
            lblGenres = new Label();
            lblHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(148, 86);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(406, 31);
            txtTitle.TabIndex = 2;
            // 
            // txtLeadActor
            // 
            txtLeadActor.Location = new Point(148, 123);
            txtLeadActor.Name = "txtLeadActor";
            txtLeadActor.Size = new Size(406, 31);
            txtLeadActor.TabIndex = 4;
            // 
            // numYear
            // 
            numYear.Location = new Point(148, 160);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(120, 31);
            numYear.TabIndex = 6;
            numYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // numCopies
            // 
            numCopies.Location = new Point(148, 197);
            numCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCopies.Name = "numCopies";
            numCopies.Size = new Size(120, 31);
            numCopies.TabIndex = 8;
            numCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(148, 234);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 31);
            numPrice.TabIndex = 10;
            // 
            // clbGenres
            // 
            clbGenres.CheckOnClick = true;
            clbGenres.Items.AddRange(new object[] { "Comedy", "Action", "Romance", "SCI-FI", "Horror", "Thriller" });
            clbGenres.Location = new Point(389, 162);
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(165, 116);
            clbGenres.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(86, 290);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(207, 45);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add Movie";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnManageGenres
            // 
            btnManageGenres.Location = new Point(350, 290);
            btnManageGenres.Name = "btnManageGenres";
            btnManageGenres.Size = new Size(204, 45);
            btnManageGenres.TabIndex = 14;
            btnManageGenres.Text = "Manage Genres";
            btnManageGenres.Click += btnManageGenres_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(23, 353);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(357, 31);
            txtSearch.TabIndex = 15;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(399, 341);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 55);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(538, 341);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 55);
            btnRefresh.TabIndex = 17;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToAddRows = false;
            dgvMovies.AllowUserToDeleteRows = false;
            dgvMovies.ColumnHeadersHeight = 34;
            dgvMovies.Location = new Point(23, 402);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.ReadOnly = true;
            dgvMovies.RowHeadersWidth = 62;
            dgvMovies.Size = new Size(641, 217);
            dgvMovies.TabIndex = 18;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(86, 89);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(60, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title :";
            // 
            // lblActor
            // 
            lblActor.AutoSize = true;
            lblActor.Location = new Point(33, 126);
            lblActor.Name = "lblActor";
            lblActor.Size = new Size(114, 25);
            lblActor.TabIndex = 3;
            lblActor.Text = "Lead Actor :";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(23, 162);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(128, 25);
            lblYear.TabIndex = 5;
            lblYear.Text = "Release Year :";
            // 
            // lblCopies
            // 
            lblCopies.AutoSize = true;
            lblCopies.Location = new Point(26, 199);
            lblCopies.Name = "lblCopies";
            lblCopies.Size = new Size(117, 25);
            lblCopies.TabIndex = 7;
            lblCopies.Text = "# of Copies :";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(81, 236);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(64, 25);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price :";
            // 
            // lblGenres
            // 
            lblGenres.AutoSize = true;
            lblGenres.Location = new Point(316, 162);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(73, 25);
            lblGenres.TabIndex = 11;
            lblGenres.Text = "Genre :";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.Location = new Point(227, 25);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(193, 45);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "MovieForm";
            // 
            // MovieForm
            // 
            ClientSize = new Size(687, 640);
            Controls.Add(lblHeader);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblActor);
            Controls.Add(txtLeadActor);
            Controls.Add(lblYear);
            Controls.Add(numYear);
            Controls.Add(lblCopies);
            Controls.Add(numCopies);
            Controls.Add(lblPrice);
            Controls.Add(numPrice);
            Controls.Add(lblGenres);
            Controls.Add(clbGenres);
            Controls.Add(btnAdd);
            Controls.Add(btnManageGenres);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnRefresh);
            Controls.Add(dgvMovies);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "MovieForm";
            Text = "MovieForm - Movie Rental System";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtLeadActor;
        private NumericUpDown numYear;
        private NumericUpDown numCopies;
        private NumericUpDown numPrice;
        private CheckedListBox clbGenres;
        private Button btnAdd;
        private Button btnManageGenres;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvMovies;
        private Label lblTitle;
        private Label lblActor;
        private Label lblYear;
        private Label lblCopies;
        private Label lblPrice;
        private Label lblGenres;
        private Label lblHeader;
    }
}
