/*
using SMS.implementation;
using SMS.interfaces;
using SMS.model;
namespace SMS.menu
{
    public class CustomerMenu
    {
        ICustomerManager iCustomerManager = new CustomerManager();
        MainMenu mainMenu = new MainMenu();
        public void RegisterCustomerPage()
        {
            Console.WriteLine("Welcome...");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("pin: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Initial Deposit: ");
            double wallet = Convert.ToDouble(Console.ReadLine());
            iCustomerManager.CreateCustomer(firstName, lastName, email, phoneNumber, pin, address, wallet);
            // LoginAdminMenu();
            mainMenu.LoginMenu();
        }


        public void LoginCUstomerMenu()
        {
            Console.WriteLine("\nWelcome.\nEnter your Staff ID and Password to login ");
            Console.Write("Staff ID: ");
            string email = Console.ReadLine();
            Console.Write("Pin: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            // iAdminManager.Login(staffId,pin); waht is this doing not part of the code
            Customer customer = iCustomerManager.Login(email, pin);
            if (customer != null)
            {
                Console.WriteLine($"Welcome {customer.FirstName}, you've successfully Logged in!");
                CustomerSubMenu();
            }
            else
            {
                Console.WriteLine($"Wrong Staff ID or Password!.");
            }
        }




        public void CustomerSubMenu()
        {
            int choice;
            do
            {
                // Console.Clear();
                Console.WriteLine("...>> Customer >> SubMenue >>");
                Console.WriteLine("Welcome..\nSemicolon Sales Management System. \nEnter valid option.");
                Console.WriteLine("Enter 1 to Manage Attendant.\nEnter 2 to Update My Details. \n3View sales Records.\n4 to Logout.\n0 to Close.");
                // int choice = Convert.ToInt32(Console.ReadLine());
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    // Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                    CustomerSubMenu();
                }
                if (choice == 1)
                {
                    // Customer 
                }
                else if (choice == 2)
                {
                    // Update detail
                }
                else if (choice == 3)
                {
                    // View Sales Records
                }
                else if (choice == 4)
                {
                    // logout
                    mainMenu.LoginMenu();
                }
            } while (choice != 0);
        }
    }
}
*/