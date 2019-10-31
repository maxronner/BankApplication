using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class CustomerLogic
    {
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> ListOfCustomers()
        {
            Customers.Add(new Customer(2110319901, "GunBorg"));

            return Customers;
        }
        public List<string> GetCustomers()
        {
            List<string> customerInformation = new List<string>();
            foreach (var item in Customers)
            {
                customerInformation.Add($"Name: {item.Name}, SSN: {item.SSN}");
            }
            return customerInformation;
        }
        public bool AddCustomer(string name, long ssn)
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
        public List<string> GetCustomer(long ssn) //incomplete
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
        public bool ChangeCustomerName(string name, long ssn)
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
        public List<string> RemoveCustomer(long ssn)
        {
            List<string> removedCustomer = new List<string>();
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].SSN == ssn)
                {
                    foreach (var item in Customers[i].Accounts)
                    {
                        removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");
                        
                    }
                }
            }
            return removedCustomer;
        }
        public void SortCustomers()
        {
            object temp = Customers;
            List<Customer> customers = temp as List<Customer>;
            customers.Sort();
            temp = customers;
            Customers = temp as ObservableCollection<Customer>;
        }
    }
}