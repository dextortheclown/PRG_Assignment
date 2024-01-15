namespace PRG_Assignment
{
    internal class Order
    {
        public int id {  get; set; }
        public DateTime timeReceived { get; set; }
        public DateTime? timeFulfilled { get; set; }
        public List<IceCream> iceCreamList { get; set; }
        public Order() { }
        public Order(int id, DateTime timeReceived)
        {
            this.id = id;
            this.timeReceived = timeReceived;
        }
        public void ModifyIceCream(int id, IceCream NewiceCream)
        {
            iceCreamList[id] = NewiceCream;
        }
        public void AddIceCream(IceCream iceCream)
        {
            iceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int id)
        {
            iceCreamList.Remove(id);
        }
        public double CalculateTotal()
        {
            // Dexter edit here according to qn 6
        }
        public override string ToString()
        {
            string iceCreamListString = "";
            foreach (IceCream iceCream in IceCreamList)
            {
                iceCreamListString += iceCream.ToString() + "\n";
            }

            return $"Order ID: {Id}" + $"Time Received: {TimeReceived:d}" + (TimeFulfilled.HasValue ? "\n" + $"Time Fulfilled: {TimeFulfilled:d}" : "") + $"Items:" + iceCreamListString;
        }

    }
}
