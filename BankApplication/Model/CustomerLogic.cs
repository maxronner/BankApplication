using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class CustomerLogic
    {
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> GetCustomers()
        {
            ObservableCollection<Customer> customerInformation = new ObservableCollection<Customer>();
            foreach (var item in Customers)
            {
                //customerInformation.Add($"{item.SSN}\t{item.Name}");
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
        public int AddSavingsAccount(long ssn)
        {
            foreach (var item in Customers)
            {
                if (item.SSN == ssn)
                {
                    int accountID = 1000 + item.Accounts.Count;
                    item.Accounts.Add(new SavingsAccount(0.01, accountID));
                    return accountID;
                }
            }
            return -1;
        }

        public string GetAccount(long ssn, int accountID)
        {
            foreach (var customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    foreach (var account in customer.Accounts)
                    {
                        if (account.AccountID == accountID)
                        {
                            if (account is SavingsAccount)
                            {
                                return $"{account.AccountID}{account.Balance} Savings Account {account.Interest}";
                            }
                            else if (account is CreditAccount)
                            {
                                return $"{account.AccountID}{account.Balance} Credit Account {account.Interest}";
                            }
                        }
                    }
                }
            }

            //var a =
            //    from customer in CustomerLogic.Customers
            //    from account in customer.Accounts
            //    where ssn == customer.SSN && account.AccountID == accountID
            //    select account;
            //            Account temp = selectedAccount.First();
            return null;
        }

        public bool Deposit(long ssn, int accountID, decimal amount)
        {
            //var selectedAccount =
            //    from customer in CustomerLogic.Customers
            //    from account in customer.Accounts
            //    where ssn == customer.SSN && account.AccountID == accountID
            //    select account;

            //Account temp = selectedAccount.First();

            foreach (var customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    for (int i = 0; i < customer.Accounts.Count; i++)
                    {
                        if (customer.Accounts[i].AccountID == accountID)
                        {
                            customer.Accounts[i].Balance += amount;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool Withdraw(long ssn, int accountID, decimal amount)
        {
            foreach (var customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    for (int i = 0; i < customer.Accounts.Count; i++)
                    {
                        if (customer.Accounts[i].AccountID == accountID)
                        {
                            customer.Accounts[i].Balance -= amount;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public string CloseAccount(long ssn, int accountID)
        {
            foreach (var customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    for (int i = 0; i < customer.Accounts.Count; i++)
                    {
                        if (customer.Accounts[i].AccountID == accountID)
                        {
                            string deletedAccount = $"{customer.Accounts[i].Balance} {customer.Accounts[i].Interest}";
                            customer.Accounts.RemoveAt(i);
                            return deletedAccount;
                        }
                    }
                }
            }
            return null;
        }

        public int AddCreditAccount(long ssn)
        {
            foreach (var item in Customers)
            {
                if (item.SSN == ssn)
                {
                    int accountID = 1000 + item.Accounts.Count;
                    item.Accounts.Add(new CreditAccount(accountID));
                    return accountID;
                }
            }
            return -1;
        }
        public List<string> GetTransactions(long ssn, int accountID)
        {
            List<string> allTransactions = new List<string>();
            var transaction =
                from customer in Customers
                from account in customer.Accounts
                where account.AccountID == accountID && customer.SSN == ssn
                select account;
            Account temp = transaction.First();
            for (int i = 0; i < temp.Transactions.Count; i++)
            {
                allTransactions.Add($"{temp.Transactions[i].Time.ToString()}, {temp.Transactions[i].TransactionType}, {temp.Transactions[i].Amount}, {temp.Transactions[i].NewBalance}");
            }
            return allTransactions;
        }
    }
}