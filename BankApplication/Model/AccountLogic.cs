using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Model
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
                account.Transactions.Add(new Transaction(accountID, false, amount, account.Balance));
                return true;
            }
            return false;
        }

        public static bool Withdraw(Account account, decimal amount)
        {
            //Fixa så att vi kan göra ett minsta/största uttagsbelopp?
            if (account.Balance >= amount || account.Balance > 0)
            {
                account.Balance -= amount;
                account.Transactions.Add(new Transaction(account.AccountID, true, amount, account.Balance));
                return true;
            }
            return false;
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
