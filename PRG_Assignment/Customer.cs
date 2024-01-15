namespace PRG_Assignment
{
    internal class Customer
    {
        public string name {  get; set; }
        public int memberid {  get; set; }
        public DateTime dob { get; set; }
        public Order currentOrder { get; set; }
        public List<Order> orderHistory { get; set; }
        public PointCard rewards { get; set; }
        public Customer() { }
        public Customer(string name, int memberid, DateTime dob)
        {
            this.name = name;
            this.memberid = memberid;
            this.dob = dob;
            orderHistory = new List<Order>();
        }
        public Order MakeOrder()
        {

        }
    }
}
