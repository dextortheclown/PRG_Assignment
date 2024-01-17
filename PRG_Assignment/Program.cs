// IT04 Dexter Wong Jun Han(Qn 2,5,6) and Chua Qi An(Qn 1,3,4)

//Display menu

while (true)
{
    DisplayMenu();
    string option = Console.ReadLine();
    if (option == "1")
    {
        Option1();
    }
    else if (option == "0")
    {
        break;
    }
}
void DisplayMenu()
{
    Console.Write("------------- MENU --------------\r\n[1] List all customers\r\n[2] List all current orders\r\n[3] Register a new customer\r\n[4] Create a customer's order\r\n[5] Display order details of a customer\r\n[6] Modify order details\r\n[0] Exit\r\n---------------------------------\r\nEnter your option : ");

}

// Basic Feature Question 1 ------------------ Display the information of all the customers

void Option1()
{
    string[] CustomerCSVFile = File.ReadAllLines("customers.csv");
    string[] Heading = CustomerCSVFile[0].Split(',');
    Console.WriteLine($"{Heading[0],-15}{Heading[1],-15}{Heading[2],-15}{Heading[3],-20}{Heading[4],-20}{Heading[5],-15}");
    for (int i = 1; i < CustomerCSVFile.Length; i++)
    {
        string[] info = CustomerCSVFile[i].Split(",");
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