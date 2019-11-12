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
            switch (account)
            {
                case SavingsAccount savings1 when savings1.FreeWithdraw == true && savings1.Balance - amount > 0:
                    account.Balance -= amount;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                case SavingsAccount savings2 when savings2.FreeWithdraw == false && savings2.Balance - amount > 0:
                    account.Balance -= amount * (decimal)savings2.WithdrawFee;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                case CreditAccount creditAccount when creditAccount.CreditLimit + creditAccount.Balance - amount > 0:
                    account.Balance -= amount;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                default:
                    return false;
            }
        }
        public static string CloseAccount(Account account, Customer customer)
        {
            string deletedAccount = "null...";

            switch (account)
            {
                case CreditAccount creditNegative when creditNegative.Balance < 0:
                    account.Balance += account.Balance * (decimal)creditNegative.DebtInterest;
                    deletedAccount = $"Account balance: {account.Balance} Debt rate: {creditNegative.DebtInterest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                case CreditAccount creditPositive when creditPositive.Balance > 0:
                    account.Balance *= (1 + (decimal)creditPositive.Interest);
                    deletedAccount = $"Account balance: {account.Balance} Account rate: {account.Interest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                case SavingsAccount savings:
                    account.Balance *= (1 + (decimal)savings.Interest);
                    deletedAccount = $"Account balance: {account.Balance} Account rate: {account.Interest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                default:
                    return deletedAccount;
            }
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
