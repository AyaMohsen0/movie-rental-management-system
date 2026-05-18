namespace FinalMovieSystemReport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxReportType = new ComboBox();
            buttonReport = new Button();
            dataGridViewReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // comboBoxReportType
            // 
            comboBoxReportType.FormattingEnabled = true;
            comboBoxReportType.Location = new Point(335, 12);
            comboBoxReportType.Name = "comboBoxReportType";
            comboBoxReportType.Size = new Size(121, 23);
            comboBoxReportType.TabIndex = 0;
            // 
            // buttonReport
            // 
            buttonReport.Location = new Point(335, 41);
            buttonReport.Name = "buttonReport";
            buttonReport.Size = new Size(125, 25);
            buttonReport.TabIndex = 1;
            buttonReport.Text = "Generate Report";
            buttonReport.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(28, 86);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.Size = new Size(750, 332);
            dataGridViewReport.TabIndex = 2;
            dataGridViewReport.CellContentClick += dataGridViewReport_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewReport);
            Controls.Add(buttonReport);
            Controls.Add(comboBoxReportType);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxReportType;
        private Button buttonReport;
        private DataGridView dataGridViewReport;

    }
}
