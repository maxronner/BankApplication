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
            new Customer(8409039567, "Lars-Åke Cederlund"),
            new Customer(7812230654, "Florence Liljedahl"),
            new Customer(7112151688, "Henrietta Malmborg"),
            new Customer(9204021234, "Veronica Smedberg-Bolander"),
            new Customer(9301200938, "Maj Sahlén"),
            new Customer(9912020873, "Carl-Johan Sterner"),
            new Customer(0111161209, "Eddy")
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

                //Vad används denna till?
                Regex regexNumbers = new Regex(@"^[0-9]+$");
                MatchCollection matches2 = regexNumbers.Matches(ssn.ToString());
                if (matches.Count > 0 && matches2.Count > 0 && ssn.ToString().Length == 10 && name != "")
                {
                    Customers.Add(new Customer(ssn, name));
                    return true;
                }
                return false;
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
                    return true;
                }
            }
            catch (Exception) { }            
            return false;
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
            catch (Exception) { }
            return removedCustomer;
        }  
    }
}