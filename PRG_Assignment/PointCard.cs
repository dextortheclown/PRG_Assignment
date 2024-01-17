using PRG_Assignment;

namespace PRG_Assignment
{
    internal class PointCard
    {
        public int points { get; set; }
        public int punchCard { get; set; }
        public string tier { get; set; }

        public PointCard()
        {
            tier = "Ordinary"; // Assuming default tier is "Ordinary"
        }

        public PointCard(int points, int punchCard)
        {
            this.points = points;
            this.punchCard = punchCard;
            this.tier = DetermineTier(); // Set tier based on points
        }

        public void AddPoints(int paymentAmount)
        {
            // Convert the payment amount to points (72% of payment, rounded down)
            int pointsToAdd = (int)Math.Floor(paymentAmount * 0.72);
            this.points += pointsToAdd;
            this.tier = DetermineTier(); // Update tier after adding points
        }

        public void RedeemPoints(int pointsToRedeem)
        {
            // Ensure there are enough points to redeem and tier is not "Ordinary"
            if (this.tier == "Ordinary" || this.points < pointsToRedeem)
            {
                throw new InvalidOperationException("Insufficient points or tier to redeem points.");
            }
            this.points -= pointsToRedeem;
        }

        public void Punch()
        {
            this.punchCard++;
            // Reset punch card after the 11th ice cream
            if (this.punchCard >= 11)
            {
                this.punchCard = 0;
            }
        }

        private string DetermineTier()
        {
            // Determine the tier based on the number of points
            if (this.points >= 100)
            {
                return "Gold";
            }
            else if (this.points >= 50)
            {
                return "Silver";
            }
            return "Ordinary";
        }

        public override string ToString()
        {
            return $"Points: {this.points} | Punch Card: {this.punchCard} | Tier: {this.tier}";
        }
    }
}
