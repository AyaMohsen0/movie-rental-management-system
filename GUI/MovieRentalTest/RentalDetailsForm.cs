using System;
using System.Windows.Forms;

namespace MovieRentalTest
{
    public partial class RentalDetailsForm : Form
    {
        public int MovieID { get; }
        public decimal PricePerDay { get; }
        public int Quantity => (int)numQuantity.Value;
        public int Duration => (int)numDuration.Value;
        public decimal TotalCost => PricePerDay * Quantity * Duration;

        public RentalDetailsForm(int movieId, decimal pricePerDay)
        {
            InitializeComponent();
            MovieID = movieId;
            PricePerDay = pricePerDay;
            lblPrice.Text = $"Price per day: ${pricePerDay:0.00}";
            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            lblTotalCost.Text = $"Total: ${TotalCost:0.00}";
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e) => UpdateTotalCost();
        private void numDuration_ValueChanged(object sender, EventArgs e) => UpdateTotalCost();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RentalHelper.HasActiveMembership(UserSession.CustomerID))
                {
                    MessageBox.Show("Membership expired. Please renew.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Quantity <= 0 || Duration <= 0)
                {
                    MessageBox.Show("Please enter valid quantity and duration", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RentalHelper.RentMovie(UserSession.CustomerID, MovieID, Quantity, Duration);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing rental: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}