using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public static class CustomerLogic
    {
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer> 
            {
            new Customer(1231231231, "HWJ"),
            new Customer(1231231231, "UWE"),
            new Customer(1231231231, "HWJ"),
            new Customer(1231231231, "HWJ"),
            new Customer(1231231231, "HWJ")
            };
       
        public static bool AddCustomer(string name, long ssn)
        {
            if (Customers.Contains(new Customer(ssn, name)))
            {
                return false;
            }
            else
            {
                Customers.Add(new Customer(ssn, name));
                return true;
            }
        }
        public static bool ChangeCustomerName(Customer customer, string name)
        {
            try
            {
                customer.Name = name;
            }
            catch (Exception)
            {
                return false;
            }            
            return true;
        }
        public static List<string> RemoveCustomer(Customer customer)
        {
            List<string> removedCustomer = new List<string>();

            if (customer.Accounts != null)
            {
                foreach (var item in customer.Accounts)
                {
                    removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");
                }
            }
            Customers.Remove(customer);
            return removedCustomer;
        }
        public static void SortCustomers()
        {
            object temp = Customers;
            List<Customer> customers = temp as List<Customer>;
            customers.Sort();
            temp = customers;
            Customers = temp as ObservableCollection<Customer>;
        }
        
    }
}