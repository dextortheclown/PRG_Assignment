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
for (int i = 1;i < customer.Length; i++)
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
    for (int i = 1;i < customer.Length; i++)
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
        try
        {
            // Customer found, proceed with order
            Console.WriteLine($"Customer Found: {foundCustomer.name} - {foundCustomer.memberId}");
            Console.Write("Select an option (Cup, Cone, Waffle): ");
            string option = Console.ReadLine().ToUpper();
            Console.Write("Select the number of scoops: ");
            int scoops = Convert.ToInt32(Console.ReadLine());
            Console.Write("Select an ice cream order option (Basic Flavours: Vanilla, Chocolate, Strawberry | Premium Flavours(+$2 per scoop): Durian, Ube, Sea salt ): ");
            string flavours = Console.ReadLine().ToUpper();
            Console.Write("Select topping(s) (Sprinkles, Mochi, Sago, Oreos): ");
            string toppings = Console.ReadLine().ToUpper();
            //Creating order object
            Order order = new Order();


            // Update the customer's current order and order history
            foundCustomer.currentOrder = order;
            foundCustomer.orderHistory.Add(order);

            // Display confirmation message
            Console.WriteLine($"Order for {foundCustomer.name} - {foundCustomer.memberId} has been logged : Option: {option} | No. of scoops: {scoops} | Flavour: {flavours} | Topping: {toppings}");
            Console.WriteLine("Order placed successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid input.");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

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
            // Assuming PointCard constructor and relevant methods are defined
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