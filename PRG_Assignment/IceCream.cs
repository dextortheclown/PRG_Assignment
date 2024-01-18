//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================s

namespace PRG_Assignment
{
    abstract class IceCream
    {
        public string option { get; set; }
        public int scoops { get; set; }
        public List<Flavour> flavours { get; set; }
        public List<Topping> toppings { get; set; }
        public IceCream() { }
        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            this.option = option;
            this.scoops = scoops;
            this.flavours = flavours ?? new List<Flavour>();
            this.toppings = toppings ?? new List<Topping>();
        }
        public abstract double CalculatePrice();

        public override string ToString()
        {
            return $"Option: {option} Scoops: {scoops} Flavours: {flavours} Toppings: {toppings}";
        }
    }
}