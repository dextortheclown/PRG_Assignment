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
        public Order MakeOrder(Order item)
        {
            orderHistory.Add(item);
            dtOrder = dob.Push(DateTime.Now); 
        }
        public bool isBirthday()
        {
            if (dob.Day == DateTime.Today.Day && dob.Month == DateTime.Today.Month) 
            {
                return true;
            }
            else { return false; }
        }
        public override string ToString()
        {
            string OrderHist = "";
            foreach (Order o in orderHistory)
            {
                OrderHist += o.ToString();
            }
            return $"Name: {name} | Member ID: {memberid} | Date of Birth: {dob} | Order History: {OrderHist}";
        }
    }
}
