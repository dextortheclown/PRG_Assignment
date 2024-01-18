//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================

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
            tier = DetermineTier(); // Set tier based on points
        }

        public void AddPoints(int paymentAmount)
        {
            // Convert the payment amount to points (72% of payment, rounded down)
            int pointsToAdd = (int)Math.Floor(paymentAmount * 0.72);
            points += pointsToAdd;
            tier = DetermineTier(); // Update tier after adding points
        }

        public void RedeemPoints(int pointsToRedeem)
        {
            // Ensure there are enough points to redeem and tier is not "Ordinary"
            if (tier == "Ordinary" || points < pointsToRedeem)
            {
                throw new InvalidOperationException("Insufficient points or tier to redeem points.");
            }
            points -= pointsToRedeem;
        }

        public void Punch()
        {
            punchCard++;
            // Reset punch card after the 11th ice cream
            if (punchCard >= 11)
            {
                punchCard = 0;
            }
        }

        private string DetermineTier()
        {
            // Determine the tier based on the number of points
            if (points >= 100)
            {
                return "Gold";
            }
            else if (points >= 50)
            {
                return "Silver";
            }
            return "Ordinary";
        }

        public override string ToString()
        {
            return $"Points: {points} | Punch Card: {punchCard} | Tier: {tier}";
        }
    }
}
