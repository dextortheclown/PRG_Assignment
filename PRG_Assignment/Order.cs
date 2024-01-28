//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================

namespace PRG_Assignment
{
    internal class Order
    {
        public int id { get; set; }
        public DateTime timeReceived { get; set; }
        public DateTime? timeFulfilled { get; set; }
        public List<IceCream> iceCreamList { get; set; }
        public Order()
        {
            this.timeReceived = DateTime.Now;
            iceCreamList = new List<IceCream>();
        }
        public Order(int id, DateTime timeReceived)
        {
            this.id = id;
            this.timeReceived = DateTime.Now;
            this.iceCreamList = new List<IceCream>();
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
            double total = 0;
            foreach (IceCream iceCream in iceCreamList)
            {
                total += iceCream.CalculatePrice(); // Assuming IceCream class has a CalculatePrice method
            }
            return total;
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
