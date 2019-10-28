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
        public ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public List<string> GetCustomers() 
        {
            List<string> customerInformation = new List<string>();
            foreach (var item in customers)
            {
                customerInformation.Add($"Name: {item.Name}, SSN: {item.SSN}");
            }
            return customerInformation;
        }
        public bool AddCustomer(string name, long ssn) 
        {
            if (customers.Contains(new Customer(ssn, name)))
            {
                return false;
            }
            else
            {
                customers.Add(new Customer(ssn, name));
                return true;
            }
        }
        public List<string> GetCustomer(long ssn) //incomplete
        {
            List<string> customerInfo = new List<string>();

            foreach (var item in customers)
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
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].SSN == ssn)
                {
                    customers[i].Name = name;
                    return true;
                }
            }
            return false;
        }
        public List<string> RemoveCustomer(long ssn) 
        {
            List<string> removedCustomer = new List<string>();
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].SSN == ssn)
                {
                    foreach (var item in customers[i].Accounts)
                    {
                        removedCustomer.Add($"{item.AccountID.ToString()}: {item.Balance.ToString()}");
                    }
                }
            }
            return removedCustomer;
        }
    }
}