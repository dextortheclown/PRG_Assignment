//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================
namespace PRG_Assignment
{
    internal class Topping
    {
        public string type { get; set; }
        public Topping() { }
        public Topping(string type)
        {
            this.type = type;
        }
        public override string ToString()
        {
            return $"Type: {type}";
        }
    }
}
