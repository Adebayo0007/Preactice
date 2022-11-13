/*
using SMS.model;
using SMS.interfaces;

namespace SMS.implementation
{


    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> listOfCustomer = new List<Customer>();
        public void CreateCustomer(string firstName, string lastName, string email, string phoneNumber, int pin, string address, double wallet)
        {
            int id = listOfCustomer.Count() + 1;
            string customerId = new Random(id).Next(100000).ToString();
            Customer customer = new Customer(id, firstName, lastName, email, customerId, phoneNumber, pin, address, wallet);
            listOfCustomer.Add(customer);
            Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {customerId}, \nKeep it Safe.");

        }

        public void DeleteCustomer(string customerId)
        {
            Customer customer = GetCustomer(customerId);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} Successfully deleted. ");
                listOfCustomer.Remove(customer);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public Customer GetCustomer(string customerId)
        {
            foreach (var item in listOfCustomer)
            {
                if (item.CustomerId == customerId)
                {
                    return item;
                }
            }
            return null;

        }

        public Customer Login(string customerId, int pin)
        {
            foreach (var item in listOfCustomer)
            {
                if (item.CustomerId == customerId && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;

        }



        public void UpdateCustomer(string customerId, string firstName, string lastName, string phoneNumber)
        {
            Customer customer = GetCustomer(customerId);
            if (customer != null)
            {
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.PhoneNumber = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
*/