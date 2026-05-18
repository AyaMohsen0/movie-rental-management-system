namespace MovieRentalTest
{
    partial class RentalDetailsForm
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
            lblQuantity = new Label();
            lblDuration = new Label();
            numQuantity = new NumericUpDown();
            numDuration = new NumericUpDown();
            btnConfirm = new Button();
            btnCancel = new Button();
            lblTotalCost = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(82, 41);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(97, 25);
            lblQuantity.TabIndex = 0;
            lblQuantity.Text = "Quantity :";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(24, 78);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(155, 25);
            lblDuration.TabIndex = 1;
            lblDuration.Text = "Duration (days) :";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(187, 39);
            numQuantity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(220, 31);
            numQuantity.TabIndex = 2;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // numDuration
            // 
            numDuration.Location = new Point(187, 76);
            numDuration.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(220, 31);
            numDuration.TabIndex = 3;
            numDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.ValueChanged += numDuration_ValueChanged;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(71, 242);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(153, 60);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(254, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 60);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalCost.Location = new Point(93, 182);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(131, 25);
            lblTotalCost.TabIndex = 6;
            lblTotalCost.Text = "Total Cost : $0";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(93, 137);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(133, 25);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "Price per day :";
            // 
            // RentalDetailsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 314);
            Controls.Add(lblPrice);
            Controls.Add(lblTotalCost);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(numDuration);
            Controls.Add(numQuantity);
            Controls.Add(lblDuration);
            Controls.Add(lblQuantity);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "RentalDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rental Details - Movie Rental System";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuantity;
        private Label lblDuration;
        private NumericUpDown numQuantity;
        private NumericUpDown numDuration;
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblTotalCost;
        private Label lblPrice;
    }
}