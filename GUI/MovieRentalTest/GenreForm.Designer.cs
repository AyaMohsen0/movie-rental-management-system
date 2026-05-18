using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovieRentalTest
{
    partial class GenreForm
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
            txtGenreName = new TextBox();
            txtDescription = new TextBox();
            lblGenreName = new Label();
            lblDescription = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            dgvGenres = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGenres).BeginInit();
            SuspendLayout();
            // 
            // txtGenreName
            // 
            txtGenreName.Location = new Point(145, 87);
            txtGenreName.Name = "txtGenreName";
            txtGenreName.Size = new Size(395, 31);
            txtGenreName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(145, 124);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(395, 31);
            txtDescription.TabIndex = 3;
            // 
            // lblGenreName
            // 
            lblGenreName.AutoSize = true;
            lblGenreName.Location = new Point(20, 90);
            lblGenreName.Name = "lblGenreName";
            lblGenreName.Size = new Size(128, 25);
            lblGenreName.TabIndex = 0;
            lblGenreName.Text = "Genre Name :";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(28, 127);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(119, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description :";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(103, 173);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(177, 65);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Genre";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(363, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 65);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Selected";
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvGenres
            // 
            dgvGenres.AllowUserToAddRows = false;
            dgvGenres.AllowUserToDeleteRows = false;
            dgvGenres.ColumnHeadersHeight = 34;
            dgvGenres.Location = new Point(20, 244);
            dgvGenres.Name = "dgvGenres";
            dgvGenres.ReadOnly = true;
            dgvGenres.RowHeadersWidth = 62;
            dgvGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGenres.Size = new Size(651, 221);
            dgvGenres.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(230, 22);
            label1.Name = "label1";
            label1.Size = new Size(197, 45);
            label1.TabIndex = 7;
            label1.Text = "Genre Form";
            // 
            // GenreForm
            // 
            ClientSize = new Size(696, 487);
            Controls.Add(label1);
            Controls.Add(lblGenreName);
            Controls.Add(txtGenreName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(dgvGenres);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "GenreForm";
            Text = "Manage Genres - Movie Rental System";
            ((System.ComponentModel.ISupportInitialize)dgvGenres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGenreName;
        private TextBox txtDescription;
        private Label lblGenreName;
        private Label lblDescription;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridView dgvGenres;
        private Label label1;
    }
}
