namespace PRG_Assignment
{
    internal class PointCard
    {
        public int points {  get; set; }
        public int punchCard {  get; set; }
        public string tier { get; set; }
        public PointCard() { }
        public PointCard(int points, int punchCard)
        {
            this.points = points;
            this.punchCard = punchCard;
        }
        public void AddPoints(int amt)
        {
            points += amt;
        }
        public void RedeemPoints(int amt)
        {
            points -= amt;
        }
        public void Punch(IceCream iceCream)
        {
            if (punchCard % 11 == 0)
            {
                iceCream[10].cost = 0;
                punchCard = 0;
            }
        }
        public override string ToString()
        {
            return$"Points: {points} | Punch Card: {punchCard} | Tier: {tier}";
        }
    }
}
