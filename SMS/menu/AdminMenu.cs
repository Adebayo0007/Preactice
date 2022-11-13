using System;
using SMS.implementation;
using SMS.interfaces;

namespace SMS.menu
{
    public class AdminMenu
    {
        IAdminManager _iAdminManager = new AdminManager();
        IAttendantManager _iAttendantManager = new AttendantManager();
        IProductManager _iProductManager = new ProductManager();
        ITransactionManager _iTransactionManager = new TransactionManager();
        private int _choice;
        public void RegisterAdminPage()
        {
            Console.WriteLine("\n\tHome >> Register >> Admin");
            // Console.WriteLine("Welcome...");
            Console.Write("\tFirst name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tLast name: ");
            var lastName = Console.ReadLine();
            Console.Write("\tEmail: ");
            var email = Console.ReadLine();
            Console.Write("\tPhone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("\tpin: ");
            var pin = Console.ReadLine();
            Console.Write("\tPost: ");
            var post = Console.ReadLine();
            _iAdminManager.CreateAdmin(firstName, lastName, email, phoneNumber, pin, post);
            var mainMenu = new MainMenu();
            mainMenu.LoginMenu();
        }
        public void DeleteAttendantMenu()
        {
            Console.Write("Enter Staff ID of the Attendant.");
            var staffId = Console.ReadLine();
            _iAttendantManager.DeleteAttendant(staffId);
        }
        public void LoginAdminMenu()
        {
            Console.WriteLine("\tWelcome.\n\tEnter your Staff ID and Password to login ");
            Console.Write("\tStaff ID: ");
            var staffId = Console.ReadLine();
            Console.Write("\tPin: ");
            var pin = Console.ReadLine();
            // iAdminManager.Login(staffId,pin); waht is this doing not part of the code
            var admin = _iAdminManager.Login(staffId, pin);
            if (admin != null)
            {
                Console.WriteLine($"Welcome {admin.FirstName}, you've successfully Logged in!");
                AdminSubMenu();
            }
            else
            {
                Console.WriteLine("Wrong Staff ID or Password!.");
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
        }
        public void AdminSubMenu()
        {
            // int choice;
            // Console.Clear();
            Console.WriteLine(@"

################################################################################
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
####________________________________________________________________________####
####    Welcome to AZ Sales Management System. Enter valid option.          ####
####------------------------------------------------------------------------####
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
################################################################################");
            Console.WriteLine("\nHome >> Login >> Admin >>");
            // Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Manage Attendant.\n\tEnter 2 to Manage Products \n\tEnter 3 to Update My Details. \n\tEnter 4 to View sales Records.\n\tEnter 5 to check Wallet. \n\tEnter 6 to Logout.\n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");

            } while (!chk);
            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    break;
                case 1:
                    // Manage Attendant
                    ManageAttendantSubMenu();

                    break;
                case 2:
                    // Manage Products 
                    ManageProductSubMenu();

                    break;
                case 3:
                    // Update detail
                    break;
                case 4:
                    // View Sales Records
                    Console.WriteLine("\nID\t TRANS. DATE \tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");

                    Console.WriteLine($"Current Wallet Balance: {_iTransactionManager.GetAllTransactionsAdmin()}");
                    // iTransactionManager.GetAllTransactionsAdmin();
                    AdminSubMenu();
                    break;
                case 5:
                    //Check Balance

                    Console.WriteLine($"Booked Balance: {_iTransactionManager.CalculateTotalSales()}");
                    AdminSubMenu();
                    break;
                case 6:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    AdminSubMenu();
                    break;
            }
        }
        public void ManageAttendantSubMenu()
        {
            Console.WriteLine("\n...>> Admin >> Manage Attendants >>");
            // Console.WriteLine("\nAZn Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Create Attendant.\n\tEnter 2 to View all attendants. \n\tEnter 3 to Delete Attendant.\n\tEnter 4 to Logout.\n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);
            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    return;
                // break;
                case 1:
                    // Create Attendant
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.RegisterAttendantPage();
                    AdminSubMenu();
                    break;
                case 2:
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                    _iAttendantManager.ViewAllAttendants();
                    AdminSubMenu();
                    break;
                case 3:
                    // Delete Attendants
                    DeleteAttendantMenu();
                    break;
                case 4:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    ManageAttendantSubMenu();
                    break;
            }
        }
        public void DeleteProductMenu()
        {
            Console.Write("Enter Product BarCode: ");
            var barCode = Console.ReadLine();
            _iProductManager.DeleteProduct(barCode);
        }
        public void AddProduct()
        {
            Console.Write("Product Name: ");
            var productName = Console.ReadLine();
            Console.Write("Barcode(Product ID): ");
            var barCode = Console.ReadLine();
            Console.Write("Price: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("wrong input.. Try again.");
            }
            Console.Write("Quantity: ");

            int productQuantity;
            while (!int.TryParse(Console.ReadLine(), out productQuantity))
            {
                Console.WriteLine("wrong input.. Try again.");
            }
            _iProductManager.CreateProduct(barCode, productName, price, productQuantity);
        }
        public void ManageProductSubMenu()
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Product >>");
            Console.WriteLine("Enter 1 to Add a product1. \nEnter 3  to View all Products. \nEnter 4 to Delete Product.\nEnter 5 to Go Back to Admin Menu\nEnter 6 to Logout.\nEnter 0 to Close.");

            bool chk;
            do
            {
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");

            } while (!chk);

            // int choice;
            // while (!int.TryParse(Console.ReadLine(), out choice))
            // {
            //     // Console.Clear();
            //     Console.WriteLine("Invalid Input\n");
            //     ManageProductSubMenu();
            // }
            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    return;
                // break;
                case 1:
                    // Add Product
                    AddProduct();
                    ManageProductSubMenu();
                    break;
                // case 2:
                // Modify product
                //  Console.WriteLine("Attendant Details.");
                // AttendantManager attendantManager = new AttendantManager();
                // attendantManager.ViewAttendant(attendant.StaffId);

                // break;
                case 3:
                    // View All products
                    // iAdminManager.DeleteAdmin();
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                    _iProductManager.ViewAllProduct();
                    ManageProductSubMenu();

                    break;
                case 4:
                    DeleteProductMenu();
                    ManageProductSubMenu();
                    break;
                case 5:
                    AdminSubMenu();

                    break;
                case 6:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    ManageProductSubMenu();
                    break;
            }
        }
    }
}
