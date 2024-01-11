namespace PRG_Assignment
{
    internal class Waffle : IceCream
    {
        public string waffleFlavour { get; set; }
        public Waffle():base() { }
        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour) : base(option, scoops, flavours, toppings) 
        {
            this.option = option;
            this.scoops = scoops;
            this.flavours = flavours;
            this.toppings = toppings;
            this.waffleFlavour = waffleFlavour;
        }
        public override double CalculatePrice()
        {
            if (scoops == 1)
            {
                double toppingtotal = 0.0;
                foreach (Topping topping in  toppings)
                {
                    if (topping.type == "Red velvet") ;
                }
                return 7.00 + toppingtotal;
            }
        }
    }
}
