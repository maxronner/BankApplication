using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public static class AccountLogic
    {
        public static int AddSavingsAccount(Customer customer)
        {
            int accountID = 1000 + customer.Accounts.Count;
            customer.Accounts.Add(new SavingsAccount(0.01, accountID));
            return accountID;
        }

        public static string GetAccount(Customer customer, long accountID)
        {
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                if (customer.Accounts[i].AccountID == accountID)
                {
                    if (customer.Accounts[i] is SavingsAccount)
                    {
                        return $"{customer.Accounts[i].AccountID}{customer.Accounts[i].Balance} Savings Account {customer.Accounts[i].Interest}";
                    }
                    else if (customer.Accounts[i] is CreditAccount)
                    {
                        return $"{customer.Accounts[i].AccountID}{customer.Accounts[i].Balance} Credit Account {customer.Accounts[i].Interest}";
                    }
                }
            }
            return null;
        }

        public static bool Deposit(Account account, long accountID, decimal amount)
        {
            if (account.AccountID == accountID)
            {
                account.Balance += amount;
                return true;
            }
            return false;
        }

        public static bool Withdraw(Account account, decimal amount)
        {
            if (amount > account.Balance || account.Balance <= 0)
            {
                return false;
            }
            else
            {
                account.Balance -= amount;
                return true;
            }
        }

        public static string CloseAccount(Customer customer, int accountID)
        {

            if (customer != null)
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

            return null;
        }

        public static int AddCreditAccount(Customer customer)
        {
            int accountID = 1000 + customer.Accounts.Count;
            customer.Accounts.Add(new CreditAccount(accountID, 0));
            return accountID;
        }

        public static List<string> GetTransactions(Account account)
        {
            List<string> allTransactions = new List<string>();
            foreach (var temp in account.Transactions)
            {
                allTransactions.Add($"{temp.Time.ToString()}, {temp.TransactionType}, {temp.Amount}, {temp.NewBalance}");
            }
            return allTransactions;
        }
    }
}
