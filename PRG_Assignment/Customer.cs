//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================
namespace PRG_Assignment
{
    internal class Customer
    {
        public string name { get; set; }
        public int memberId { get; set; }
        public DateTime dob { get; set; }
        public Order currentOrder { get; set; }
        public List<Order> orderHistory { get; set; }
        public PointCard rewards { get; set; }

        public Customer()
        {
            orderHistory = new List<Order>();
        }

        public Customer(string name, int memberId, DateTime dob) : this()
        {
            this.name = name;
            this.memberId = memberId;
            this.dob = dob;
        }

        public void MakeOrder(Order item)
        {
            // Add the new order to the order history
            orderHistory.Add(item);
            // Set the current order to the new order
            currentOrder = item;
        }

        public bool IsBirthday()
        {
            // Check if today is the customer's birthday
            return dob.Day == DateTime.Today.Day && dob.Month == DateTime.Today.Month;
        }

        public override string ToString()
        {
            string orderHistoryString = "";
            foreach (Order order in orderHistory)
            {
                orderHistoryString += order.ToString() + "\n";
            }

            return $"Name: {name} | Member ID: {memberId} | Date of Birth: {dob.ToShortDateString()} | Order History: {orderHistoryString}";
        }
    }
}
