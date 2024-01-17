using PRG_Assignment;

namespace PRG_Assignment
{
    internal class PointCard
    {
        public int Points { get; set; }
        public int PunchCard { get; set; }
        public string Tier { get; set; }

        public PointCard()
        {
            Tier = "Ordinary"; // Assuming default tier is "Ordinary"
        }

        public PointCard(int points, int punchCard)
        {
            this.Points = points;
            this.PunchCard = punchCard;
            this.Tier = DetermineTier(); // Set tier based on points
        }

        public void AddPoints(int paymentAmount)
        {
            // Convert the payment amount to points (72% of payment, rounded down)
            int pointsToAdd = (int)Math.Floor(paymentAmount * 0.72);
            this.Points += pointsToAdd;
            this.Tier = DetermineTier(); // Update tier after adding points
        }

        public void RedeemPoints(int pointsToRedeem)
        {
            // Ensure there are enough points to redeem or that tier is not "Ordinary"
            if (this.Tier == "Ordinary" || this.Points < pointsToRedeem)
            {
                throw new InvalidOperationException("Insufficient points or tier to redeem points.");
            }
            this.Points -= pointsToRedeem;
        }

        public void Punch()
        {
            this.PunchCard++;
            // Reset punch card after the 11th ice cream
            if (this.PunchCard >= 11)
            {
                this.PunchCard = 0;
            }
        }

        private string DetermineTier()
        {
            // Determine the tier based on the number of points
            if (this.Points >= 100)
            {
                return "Gold";
            }
            else if (this.Points >= 50)
            {
                return "Silver";
            }
            return "Ordinary";
        }

        public override string ToString()
        {
            return $"Points: {this.Points} | Punch Card: {this.PunchCard} | Tier: {this.Tier}";
        }
    }
}
