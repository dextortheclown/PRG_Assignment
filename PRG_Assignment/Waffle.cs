//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================
using PRG_Assignment;

namespace PRG_Assignment
{
    internal class Waffle : IceCream
    {
        public string waffleFlavour { get; set; }
        public Waffle() : base() { }
        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour) : base(option, scoops, flavours, toppings)
        {
            this.waffleFlavour = waffleFlavour;
        }
        public override double CalculatePrice()
        {
            double price;
            // base price based on number of scoops
            switch (scoops)
            {
                case 1:
                    price = 7.00;
                    break;
                case 2:
                    price = 8.5;
                    break;
                case 3:
                    price = 9.5;
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
            // check for premium waffle flavour
            if (waffleFlavour == "Red velvet" || waffleFlavour == "Charcoal" || waffleFlavour == "Pandan")
            {
                price += 3.00; // $3 extra for special waffle flavours
            }
            return price;
        }
    }
}
