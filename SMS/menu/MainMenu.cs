using System;
using SMS.implementation;
using SMS.interfaces;

namespace SMS.menu
{
    public class MainMenu
    {
        public int Choice;
        public void AllMainMenu()
        {
            IAdminManager adminManager = new AdminManager();
            IAttendantManager attendantManager = new AttendantManager();
            IProductManager productManager = new ProductManager();
            ITransactionManager transactionManager = new TransactionManager();
            adminManager.ReadFromFile();
            attendantManager.ReadFromFile();
            productManager.ReadFromFile();
            transactionManager.ReadFromFile();
            do
            {
                // Console.Clear();
                Console.WriteLine(@"
################################################################################
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
####________________________________________________________________________####
####    Welcome to AZ Sales Management System. Enter valid option.          ####
####------------------------------------------------------------------------####
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
################################################################################");
                Console.WriteLine("\tHome>>");
                Console.WriteLine("\tEnter 1 to Register.\n\tEnter 2 to Login.\n\tEnter 0 to Close.");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out Choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");
                } while (!chk);
                if (Choice == 1)
                {
                    RegistrationMenu();
                }
                else if (Choice == 2)
                {
                    Console.WriteLine("\nMain Menu >> Login >> ");
                    LoginMenu();
                }
                else
                {
                    Console.Write("Invalid Input.");
                }
            } while (Choice != 0);
        }
        public void RegistrationMenu()
        {
            do
            {
                Console.WriteLine("\nHome >> Register >>");
                Console.WriteLine("\tEnter 1 Go back to Go Home. or \n\tEnter Your OneTime Registration Code for  Newly Employed Manager..");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out Choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");

                } while (!chk);
                if (Choice == 2546)
                {
                                        var adminMenu = new AdminMenu();
                    adminMenu.RegisterAdminPage();
                }
                else if (Choice == 1)
                {
                    AllMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Input.\n");
                    RegistrationMenu();
                }

            } while (Choice != 0);
        }
        public void LoginMenu()
        {
            do
            {
                Console.WriteLine("\n\tHome>> Login >> ");
                Console.WriteLine("\tEnter 1 for Admin.\n\tEnter 2 for Attendant. \n\tEnter 3 for Customer. \n\tEnter 4 to go back to Main Menu.\n\tEnter 0 to Close");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out Choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");
                } while (!chk);
                if (Choice == 1)
                {
                    Console.WriteLine("\nHome >> Login >> Admin");
                    var adminMenu = new AdminMenu();
                    adminMenu.LoginAdminMenu();
                }
                else if (Choice == 2)
                {
                    Console.WriteLine("\nMain Menu >> Login >> Attendant");
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.LoginAttendantMenu();
                }
                else if (Choice == 3)
                {
                    /* OUT OFF THE PROGRAM FOR SUSTOMER
                    // Customer
                    Console.WriteLine("\nMain Menu >> Login >> Customer");
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.LoginCUstomerMenu();
                    */
                }
                else if (Choice == 4)
                {
                    AllMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Input.\n");
                    LoginMenu();
                }

            } while (Choice != 0);
            Console.WriteLine();
        }
    }
}
