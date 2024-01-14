namespace PRG_Assignment
{
    internal class Order
    {
        public int id {  get; set; }
        public DateTime timeReceived { get; set; }
        public DateTime? timeFufilled { get; set; }
        public List<IceCream> iceCreamList { get; set; }
        public Order() { }
        public Order(int id, DateTime timeReceived)
        {
            this.id = id;
            this.timeReceived = timeReceived;
        }
    }
}
