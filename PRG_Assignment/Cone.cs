//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================
namespace PRG_Assignment
{
    internal class Cone : IceCream
    {
        public bool dipped {  get; set; }
        public Cone() { }
        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings) 
        {
            this.dipped = dipped;
        }
        public override double CalculatePrice()
        {
            double price;
            // base price based on number of scoops
            switch (scoops)
            {
                case 1:
                    price = 4.00;
                    break;
                case 2:
                    price = 5.5;
                    break;
                case 3:
                    price = 6.5;
                    break;
                default:
                    throw new ArgumentException("Please choose 1,2 or 3 scoops");
            }
            // price for premium flavour of icecream
            foreach (var flavour in flavours)
            {
                if (flavour.premium)
                {
                    price += 2.00;
                }
            }
            // price for toppings
            if (toppings != null)
            {
                price += toppings.Count;
            }
            // check if dipped
            if (dipped)
            {
                price += 2;
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString() + $"Dipped: {dipped}";
        }
    }
}
