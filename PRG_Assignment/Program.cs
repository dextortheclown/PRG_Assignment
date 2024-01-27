//==========================================================
// Student Number : S10261312
// Student Name : Dexter Wong Jun Han// Parter Number : S10258309
// Partner Name : Chua Qi An//
// ==========================================================

// IT04 Dexter Wong Jun Han(Qn 2,5,6) and Chua Qi An(Qn 1,3,4)

using PRG_Assignment;


// initialising all objects
// Order Objects
string[] order = File.ReadAllLines("orders.csv");
List<Order> orderList = new List<Order>();
for (int i = 1; i < order.Length; i++)
{
    string[] ordinfo = order[i].Split(',');
    orderList.Add(new Order(int.Parse(ordinfo[1]), DateTime.Parse(ordinfo[3])));
}

// Customer Objects
string[] customer = File.ReadAllLines("customers.csv");
List<Customer> customerList = new List<Customer>();
for (int i = 1; i < customer.Length; i++)
{
    string[] cusinfo = customer[i].Split(",");
    customerList.Add(new Customer(cusinfo[0], int.Parse(cusinfo[1]), DateTime.Parse(cusinfo[2])));
}

// Adding Orders to History for each customer
foreach (Customer customers in customerList)
{
    for (int j = 1; j < order.Length; j++)
    {
        string[] ordinfo = order[j].Split(",");
        if (customers.memberId == int.Parse(ordinfo[1]))
        {
            customers.MakeOrder(new Order(ordinfo[]));
        }
    }
}
// Creating Gold Customer Queue 
Queue<Order> GoldQueue = new Queue<Order>();
Queue<Order> RegularOrderQueue = new Queue<Order>();



// Display menu
while (true)
{
    DisplayMenu();
    string option = Console.ReadLine();
    if (option == "1")
    {
        Option1();
    }
    else if (option == "2")
    {
        Option2();
    }
    else if (option == "3")
    {
        Option3();
    }
    else if (option == "4")
    {
        Option4();
    }
    else if (option == "5")
    {
        Option5();
    }
    else if (option == "6")
    {

    }
    else if (option == "7")
    {

    }
    else if (option == "8")
    {

    }
    else if (option == "0")
    {
        Console.WriteLine("Terminating system (╥_╥) ");
        break;
    }
    else
    {
        Console.WriteLine("Please select a valid option!");
    }
}
void DisplayMenu()
{
    Console.Write("------------- MENU --------------\r\n[1] List all customers\r\n[2] List all current orders\r\n[3] Register a new customer\r\n[4] Create a customer's order\r\n[5] Display order details of a customer\r\n[6] Modify order details\r\n[7] Process an order and checkout\r\n[8] Display monthly charged amounts breakdown & total charged amounts for the year\r\n[0] Exit\r\n---------------------------------\r\nEnter your option : ");

}

// Basic Feature Question 1 ------------------ Display the information of all the customers

void Option1()
{

    string[] Heading = customer[0].Split(',');
    Console.WriteLine($"{Heading[0],-15}{Heading[1],-15}{Heading[2],-15}{Heading[3],-20}{Heading[4],-20}{Heading[5],-15}");
    for (int i = 1; i < customer.Length; i++)
    {
        string[] info = customer[i].Split(",");
        if (info.Length >= 6)
        {
            string Names = info[0];
            string MemberID = info[1];
            DateOnly DOB = DateOnly.Parse(info[2]);
            string MemberStatus = info[3];
            int MembershipPoints = int.Parse(info[4]);
            int PunchCard = int.Parse(info[5]);
            Console.WriteLine($"{Names,-15}{MemberID,-15}{DOB,-15}{MemberStatus,-20}{MembershipPoints,-20}{PunchCard,-15}");
        }
    }
}

// Basic Feature Question 2 ------------------ List all current orders
void Option2()
{
    // gold queue
    Console.WriteLine("----Gold Queue----");
    Console.WriteLine($"{"Name",-10}{"Option",-8}{"Scoops",-8}{"Dipped",-8}{"Waffle Flavour",-15}{"Flavour1",-12}{"Flavour2",-12}{"Flavour3",-12}{"Topping1",-11}{"Topping2",-11}{"Topping3",-11}{"Topping4",-11}");
    for (int i = 1; i < customer.Length; i++)
    {
        string[] cusinfo = customer[i].Split(",");
        for (int j = 1; j < order.Length; j++)
        {
            string[] ordinfo = order[j].Split(",");
            if (cusinfo[3] == "Gold" && cusinfo[1] == ordinfo[1])
            {
                Console.WriteLine($"{cusinfo[0],-10}{ordinfo[4],-8}{ordinfo[5],-8}{ordinfo[6],-8}{ordinfo[7],-15}{ordinfo[8],-12}{ordinfo[9],-12}{ordinfo[10],-12}{ordinfo[11],-11}{ordinfo[12],-11}{ordinfo[13],-11}{ordinfo[14],-11}");
            }
        }
    }
    // normal queue
    Console.WriteLine("----Normal Queue----");
    Console.WriteLine($"{"Name",-10}{"Option",-8}{"Scoops",-8}{"Dipped",-8}{"Waffle Flavour",-15}{"Flavour1",-12}{"Flavour2",-12}{"Flavour3",-12}{"Topping1",-11}{"Topping2",-11}{"Topping3",-11}{"Topping4",-11}");
    for (int i = 1; i < customer.Length; i++)
    {
        string[] cusinfo = customer[i].Split(",");
        for (int j = 1; j < order.Length; j++)
        {
            string[] ordinfo = order[j].Split(",");
            if (cusinfo[3] != "Gold" && cusinfo[1] == ordinfo[1])
            {
                Console.WriteLine($"{cusinfo[0],-10}{ordinfo[4],-8}{ordinfo[5],-8}{ordinfo[6],-8}{ordinfo[7],-15}{ordinfo[8],-12}{ordinfo[9],-12}{ordinfo[10],-12}{ordinfo[11],-11}{ordinfo[12],-11}{ordinfo[13],-11}{ordinfo[14],-11}");
            }
        }
    }
}


// Basic Feature Question 3 ------------------ Register a new customer
void Option3()
{
    try
    {
        Console.Write("Customers name: ");
        string name = Console.ReadLine();
        Console.Write("Customers ID number: ");
        int memberId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Customers date of birth (dd-MM-yyyy): ");
        DateTime dob = Convert.ToDateTime(Console.ReadLine());
        Customer newCustomer = new Customer(name, memberId, dob);
        PointCard newPointCard = new PointCard(0, 0);
        newCustomer.rewards = newPointCard;

        AppendCustomerToFile(newCustomer);
        Console.WriteLine("Customer registration successful!");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
    }


}

void AppendCustomerToFile(Customer customer) // To append customer into CSV file for option 3
{
    string customerData = $"{customer.name},{customer.memberId},{customer.dob:dd-MM-yyyy},{customer.rewards.tier},{customer.rewards.points},{customer.rewards.punchCard}";
    File.AppendAllText("customers.csv", customerData + Environment.NewLine);
}

// Basic Feature Question 4 ------------------ Create a customer's order
void Option4()
{

    //Printing of list of customers

    string[] Heading = customer[0].Split(',');
    Console.WriteLine($"{Heading[0],-15}{Heading[1],-15}{Heading[2],-15}{Heading[3],-20}{Heading[4],-20}{Heading[5],-15}");
    for (int i = 1; i < customer.Length; i++)
    {
        string[] info = customer[i].Split(",");
        if (info.Length >= 6)
        {
            string Names = info[0];
            string MemberID = info[1];
            DateOnly DOB = DateOnly.Parse(info[2]);
            string MemberStatus = info[3];
            int MembershipPoints = int.Parse(info[4]);
            int PunchCard = int.Parse(info[5]);
            Console.WriteLine($"{Names,-15}{MemberID,-15}{DOB,-15}{MemberStatus,-20}{MembershipPoints,-20}{PunchCard,-15}");
        }
    }

    // Load customers from CSV file
    List<Customer> customers = LoadCustomersFromFile("customers.csv");


    // Prompt the user to select a customer by Member ID
    Console.Write("Select a customer by Member ID (E.G 685582): ");
    string memberID = Console.ReadLine();

    // Search for the customer with the specified Member ID
    Customer foundCustomer = customers.Find(customer => customer.memberId.ToString() == memberID);
    if (foundCustomer != null)
    {
        bool addMoreIceCream = true;
        while (addMoreIceCream)
        {
            try
            {
                bool premium;
                Order newOrder = new Order();



                // Flavour list
                List<Flavour> flavours = new List<Flavour>();
                // Toppings list
                List<Topping> toppings = new List<Topping>();
                // Waffle list
                List<Waffle> waffles = new List<Waffle>();
                // Customer found, proceed with order

                Console.WriteLine($"Customer Found: {foundCustomer.name} - {foundCustomer.memberId}");

                bool OptionsLoop = true;
                string option = "";
                while (OptionsLoop)
                {
                    Console.Write("Select an option (Cup, Cone, Waffle): ");
                    option = Console.ReadLine().ToLower().Trim();
                    if (option != "cup" && option != "cone" && option != "waffle")
                    {
                        Console.WriteLine("Please enter a valid option!");
                        OptionsLoop = true;
                    }
                    else
                    {
                        break;
                    }


                }
                bool optionloop = true;
                // Loop to ensure 3 scoops or below
                int scoops = 0;
                while (optionloop)
                {

                    Console.Write("Please enter the number of scoops (1-3) : ");
                    scoops = Convert.ToInt32(Console.ReadLine());
                    if (scoops > 3)
                    {
                        Console.WriteLine("Please enter numbers between 1 to 3");
                        optionloop = true;
                    }
                    else if (scoops > 0 && scoops <= 3)
                    {
                        optionloop = false; // Break out of the loop for valid input
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input");
                        optionloop = true;
                    }
                }
                string type = "";
                while (scoops > 0)
                {
                    // flavour loop
                    bool flavourloop = true;
                    while (flavourloop)
                    {
                        Console.Write("Select an ice cream order option\n---FLAVOUR LIST---\nBasic Flavours: Vanilla, Chocolate, Strawberry\nPremium Flavours(+$2 per scoop): Durian, Ube, Sea salt\nOption: ");
                        type = Console.ReadLine().ToLower();
                        if (type != "vanilla" && type != "chocolate" && type != "strawberry" && type != "durian" && type != "ube" && type != "sea salt")
                        {
                            Console.WriteLine("Please enter a valid flavour!");
                            flavourloop = true;
                        }
                        else
                        {
                            break;

                        }
                    }
                    // Flavour list
                    if (type == "durian" || type == "ube" || type == "sea salt")
                    {
                        premium = true;
                    }
                    else
                    {
                        premium = false;
                    }
                    // Scoops

                    bool scooploop = true;
                    while (scooploop)
                    {
                        Console.Write($"Please enter quantity of scoops, enter 0 if you don't want any scoops. (Remaining scoops: {scoops})\nOption: ");
                        int AmtScoops = Convert.ToInt32(Console.ReadLine());
                        if (AmtScoops == 0)
                        {
                            Console.WriteLine($"No scoops taken, you have {scoops} scoops left");
                            scooploop = false; // break out of scoop loop
                        }
                        else if (AmtScoops > scoops)
                        {
                            Console.WriteLine($"You only have {scoops} scoops! Please enter a valid amount!");
                            scooploop = true;
                        }
                        else if (scoops >= AmtScoops)
                        {
                            scoops = scoops - AmtScoops;
                            Console.WriteLine($"{AmtScoops} scoop(s) of {type} added.");
                            Flavour flavour1 = new Flavour(type, premium, AmtScoops);
                            flavours.Add(flavour1);
                            scooploop = false;
                        }

                    }

                }
                // TOPPINGS
                if (option == "cup")
                {
                    bool cuploop = true;
                    while (cuploop)
                    {
                        Console.Write("Select topping(s), (Sprinkles, Mochi, Sago, Oreos) (Enter X when done, max 4 toppings)\nOption: ");
                        string topping = Console.ReadLine().ToLower();
                        if (topping != "sprinkles" && topping != "mochi" && topping != "sago" && topping != "oreos" && topping != "x")
                        {
                            Console.WriteLine("Please enter a valid option!");
                            cuploop = true;
                        }
                        else if (topping == "x")
                        {
                            cuploop = false;
                            IceCream iceCream = new Cup(option, scoops, flavours, toppings);
                            newOrder.iceCreamList.Add(iceCream);

                        }
                        else
                        {
                            Console.WriteLine($"{topping} added!");
                            Topping topping1 = new Topping(topping);
                            toppings.Add(topping1);
                            IceCream iceCream = new Cup(option, scoops, flavours, toppings);
                            newOrder.iceCreamList.Add(iceCream);
                        }
                    }

                }
                else if (option == "cone")
                {
                    bool coneloop = true;
                    while (coneloop)
                    {
                        Console.Write("Select topping(s), (Sprinkles, Mochi, Sago, Oreos) (Enter X when done, max 4 toppings)\nOption: ");
                        string topping = Console.ReadLine().ToLower();
                        if (topping != "sprinkles" && topping != "mochi" && topping != "sago" && topping != "oreos" && topping != "x")
                        {
                            Console.WriteLine("Please enter a valid option!");
                            coneloop = true;
                        }
                        else if (topping == "x")
                        {
                            coneloop = false;

                        }
                        else
                        {
                            Console.WriteLine($"{topping} added!");
                            Topping topping1 = new Topping(topping);
                            toppings.Add(topping1);

                        }
                    }
                    bool chococoneloop = true;

                    while (chococoneloop)
                    {
                        Console.Write("Upgrade cone to chocolate-dipped cone for $2 more? (Y/N) ");
                        string chococone = Console.ReadLine().ToLower();
                        if (chococone == "y")
                        {
                            Console.WriteLine("Cone upgraded to chocolate-dipped cone!");
                            IceCream iceCream = new Cone(option, scoops, flavours, toppings, true);
                            newOrder.iceCreamList.Add(iceCream);
                            chococoneloop = false;
                        }
                        else if (chococone == "n")
                        {

                            IceCream iceCream = new Cone(option, scoops, flavours, toppings, false);
                            newOrder.iceCreamList.Add(iceCream);
                            chococoneloop = false;

                        }
                        else
                        {
                            Console.WriteLine("Please enter either Y or N");
                            chococoneloop = true;
                        }
                    }

                }

                else if (option == "waffle")
                {
                    bool waffleloop = true;
                    while (waffleloop)
                    {
                        Console.Write("Select topping(s), (Sprinkles, Mochi, Sago, Oreos) (Enter X when done, max 4 toppings)\nOption: ");
                        string topping = Console.ReadLine().ToLower();
                        if (topping != "sprinkles" && topping != "mochi" && topping != "sago" && topping != "oreos" && topping != "x")
                        {
                            Console.WriteLine("Please enter a valid option!");
                            waffleloop = true;
                        }
                        else if (topping == "x")
                        {
                            waffleloop = false;

                        }
                        else
                        {
                            Console.WriteLine($"{topping} added!");
                            Topping topping1 = new Topping(topping);
                            toppings.Add(topping1);
                        }
                    }
                    bool waffleflavour = true;
                    while (waffleflavour)
                    {
                        Console.Write("Change waffle flavour for additional $3? (Red velvet, charcoal, pandan\nOption (Original to exit): ");
                        string FlavourChoice = Console.ReadLine().ToLower();
                        if (FlavourChoice != "red velvet" && FlavourChoice != "charcoal" && FlavourChoice != "pandan" && FlavourChoice != "original")
                        {
                            Console.WriteLine("Please enter a valid waffle flavour choice!");
                            waffleflavour = true;
                        }
                        else if (FlavourChoice == "original")
                        {

                            IceCream iceCream = new Waffle(option, scoops, flavours, toppings, FlavourChoice);
                            newOrder.iceCreamList.Add(iceCream);
                            waffleflavour = false;

                        }
                        else
                        {
                            Console.WriteLine($"Waffle flavour has been changed to {FlavourChoice}!");
                            Topping topping2 = new Topping(FlavourChoice);
                            IceCream iceCream = new Waffle(option, scoops, flavours, toppings, FlavourChoice);

                            newOrder.iceCreamList.Add(iceCream);
                            waffleflavour = false;

                        }
                    }
                }

                Console.Write("Would you like to create another ice cream? (Y/N) ");
                addMoreIceCream = Console.ReadLine().ToLower() == "y";
                if (foundCustomer.rewards.tier == "Gold")
                {
                    GoldQueue.Enqueue(newOrder);
                }
                else
                {
                    RegularOrderQueue.Enqueue(newOrder);
                }
                // Linking the new order to the customer's current order
                foundCustomer.currentOrder = newOrder;
                Console.WriteLine("Order has been successfully created and added to the queue!");

                foundCustomer.currentOrder = newOrder;
                foundCustomer.orderHistory.Add(newOrder);
                Console.WriteLine("Order has been successfully created!");

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    else
    {
        Console.WriteLine("No customer found with the given Member ID, please enter a valid member ID.");
    }
}

static List<Customer> LoadCustomersFromFile(string filePath)
{
    List<Customer> customers = new List<Customer>();
    string[] CustomerCSVFile = File.ReadAllLines(filePath);

    for (int i = 1; i < CustomerCSVFile.Length; i++)
    {
        string[] info = CustomerCSVFile[i].Split(",");
        if (info.Length >= 6)
        {
            Customer customer = new Customer(
                name: info[0],
                memberId: int.Parse(info[1]),
                dob: DateTime.Parse(info[2])
            );

            PointCard rewards = new PointCard(int.Parse(info[4]), int.Parse(info[5]));
            customer.rewards = rewards;
            customers.Add(customer);
        }
    }
    return customers;
}

// Basic Feature Question 5 ------------------ Display order details of a customer
void Option5()
{
    // Displaying customers
    Option1();
    Console.Write("Choose a Customer: ");
    string? custoption = Console.ReadLine();
}


// Basic Feature Question 6 ------------------ Modify order details