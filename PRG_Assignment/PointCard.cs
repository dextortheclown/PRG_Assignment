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
        public void Punch()
        {
            if (punchCard < 11)
            {

            }
        }
    }
}
