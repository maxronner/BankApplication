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
            new Customer(8409039567, "Anders"),
            new Customer(7812230654, "Olle"),
            new Customer(0111161209, "Eddy"),
            new Customer(9204021234, "Robin"),
            new Customer(2106228532, "Gunborg")

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
        public static List<string> GetCustomer(long ssn) //incomplete
        {
            List<string> customerInfo = new List<string>();

            foreach (var item in Customers)
            {
                if (item.SSN == ssn)
                {
                    customerInfo.Add(item.Name);
                    customerInfo.Add(item.SSN.ToString());
                    foreach (var account in item.Accounts)
                    {
                        customerInfo.Add(account.AccountID.ToString());
                        customerInfo.Add(account.Balance.ToString());
                        customerInfo.Add(account.Interest.ToString());
                        if (account is CreditAccount tempCredit)
                        {
                            customerInfo.Add(tempCredit.CreditLimit.ToString());
                            customerInfo.Add(tempCredit.DebtInterest.ToString());
                        }
                        else if (account is SavingsAccount tempSavings)
                        {
                            customerInfo.Add(tempSavings.FreeWithdraw.ToString());
                            customerInfo.Add(tempSavings.WithdrawFee.ToString());
                        }
                    }
                }
            }
            return customerInfo;
        }
        public static bool ChangeCustomerName(string name, long ssn)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].SSN == ssn)
                {
                    Customers[i].Name = name;
                    return true;
                }
            }
            return false;
        }
        public static List<string> RemoveCustomer(Customer customer)
        {
            //List<string> removedCustomer = new List<string>();
            //for (int i = 0; i < Customers.Count; i++)
            //{
            //    if (Customers[i].SSN == ssn)
            //    {
            //        foreach (var item in Customers[i].Accounts)
            //        {
            //            removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");

            //        }
            //    }
            //}
            //return removedCustomer;
            List<string> removedCustomer = new List<string>();

            if (customer.Accounts != null)
            {
                foreach (var item in customer.Accounts)
                {
                    removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");
                }
            }
            CustomerLogic.Customers.Remove(customer);
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