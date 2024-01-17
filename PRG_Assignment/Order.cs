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
        public void DeleteIceCream(int id, IceCream iceCream)
        {
            iceCreamList.Remove(iceCream);
        }
        public double CalculateTotal()
        {
            // Dexter edit here according to qn 6
            return 0;
        }
        public override string ToString()
        {
            string iceCreamListString = "";
            foreach (IceCream iceCream in iceCreamList)
            {
                iceCreamListString += iceCream.ToString() + "\n";
            }

            return $"Order ID: {id}" + $"Time Received: {timeReceived:d}" + (timeFulfilled.HasValue ? "\n" + $"Time Fulfilled: {timeFulfilled:d}" : "") + $"Items:" + iceCreamListString;
        }

    }
}
