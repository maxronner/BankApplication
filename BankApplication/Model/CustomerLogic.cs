using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApplication
{
    public static class CustomerLogic
    {
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer> 
            {
            new Customer(8409039567, "Anders"),
            new Customer(7812230654, "Olle"),
            new Customer(0111161209, "Eddy"),
            new Customer(9204021234, "Robin"),
            new Customer(2106228532, "Gunborg")

            };
        public static bool CustomerExists (long ssn)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool AddCustomer(string name, long ssn)
        {
            if (CustomerExists(ssn))
            {
                return false;
            }
            else
            {
                Regex regexLetters = new Regex(@"^[a-öA-Ö]+$");
                MatchCollection matches = regexLetters.Matches(name);

                Regex regexNumbers = new Regex(@"^[1-9]+$");
                MatchCollection matches2 = regexNumbers.Matches(ssn.ToString());
                if (matches.Count > 0)
                {
                    Customers.Add(new Customer(ssn, name));
                }
              
                if(ssn.ToString().Length != 10 || name == "")
                {
                    return false;
                }
                Customers.Add(new Customer(ssn, name));
                return true;
            }
        }
        public static bool ChangeCustomerName(Customer customer, string name)
        {
            try
            {
                Regex regex = new Regex(@"^[a-öA-Ö]+$");
                MatchCollection matches = regex.Matches(name);
                if (matches.Count > 0)
                {
                    customer.Name = name;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }            
            return true;
        }

        public static bool Login(string username, string password)
        {
            string input = "admin";
            if (username == input && password == input)
            {
                return true;
            }
            return false;
        }


        public static List<string> RemoveCustomer(Customer customer) 
        {
            List<string> removedCustomer = new List<string>();

            try 
            {
                foreach (var item in customer.Accounts)
                {
                    removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");
                }
                Customers.Remove(customer);
            }
            catch (Exception)
            {

            }
            return removedCustomer;
            

          
        }  
    }
}