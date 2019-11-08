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
            if (customer != null)
            {
                customer.Accounts.Add(new SavingsAccount(0.01));
                var account = customer.Accounts.Last();
                return account.AccountID;
            }
            return -1;
        }
        public static int NewAccountID()
        {
            int availableAccountID = 1000;
            foreach (var customer in CustomerLogic.Customers)
            {
                foreach (var account in customer.Accounts)
                {
                    if (account.AccountID >= availableAccountID) availableAccountID = account.AccountID + 1;
                }
            }
            return availableAccountID;
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

        public static bool Deposit(Account account, decimal amount)
        {
            if (account != null)
            {
                account.Balance += amount;
                account.Transactions.Add(new Transaction(account.AccountID, "Deposit", amount, account.Balance));
                return true;
            }
            return false;
        }

        public static bool Withdraw(Account account, decimal amount)
        {
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                return true;
            }
            return false;
        }

        public static string CloseAccount(Account account, Customer customer)
        {
            if (account != null)
            {

                string deletedAccount = $"Account balance: {account.Balance} Account rate: {account.Interest*100}%";
                customer.Accounts.Remove(account);
                return deletedAccount;
            }
            return null;
        }

        public static int AddCreditAccount(Customer customer)
        {
            if (customer != null)
            {
                customer.Accounts.Add(new CreditAccount());
                var account = customer.Accounts.Last();
                return account.AccountID;
            }
            return -1;
        }

        public static List<string> GetTransactions(Account account)
        {
            List<string> allTransactions = new List<string>();
            foreach (var temp in account.Transactions)
            {
                allTransactions.Add($"{temp.Time}, {temp.TransactionType}, {temp.Amount}, {temp.NewBalance}");
            }
            return allTransactions;
        }
    }
}
