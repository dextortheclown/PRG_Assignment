using PRG_Assignment;
namespace PRG_Assignment
{
    internal class Cup : IceCream
    {
        public Cup():base() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) :base(option, scoops, flavours, toppings)
        {
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
            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
