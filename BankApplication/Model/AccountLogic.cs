using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public static class AccountLogic
    {
        public static int AddSavingsAccount(Customer customer) // genererar nytt sparkonto för vald kund
        {
            if (customer != null)
            {
                customer.Accounts.Add(new SavingsAccount(0.01));
                return customer.Accounts.Last().AccountID;
            }
            return -1;
        }
        public static int NewAccountID() // genererar ett unikt kontonr
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
        public static bool Deposit(Account account, decimal amount) // deposit till valt konto samt lagrar transaktionen i Transactions som ligger i Account
        {
            if (account != null && amount > 0)
            {
                account.Balance += amount;
                account.Transactions.Add(new Transaction(account.AccountID, "Deposit", amount, account.Balance));
                return true;
            }
            return false;
        }
        public static bool Withdraw(Account account, decimal amount) // withdraw för valt konto samt lagrar transaktionen i Transactions som ligger i Account
        {
            if(amount == 0)
            {
                return false;
            }
            switch (account)
            {
                case SavingsAccount savings1 when savings1.FreeWithdraw == true && savings1.Balance - amount >= 0: // uttag savings, efter första fria uttaget -> bool blir false
                    account.Balance -= amount;
                    savings1.FreeWithdraw = false;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                case SavingsAccount savings2 when savings2.FreeWithdraw == false && savings2.Balance - amount >= 0: // uttag savings efter fritt uttag
                    account.Balance -= amount * (decimal)savings2.WithdrawFee;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                case CreditAccount creditAccount when creditAccount.CreditLimit + creditAccount.Balance - amount >= 0: // uttag credit
                    account.Balance -= amount;
                    account.Transactions.Add(new Transaction(account.AccountID, "Withdrawal", amount, account.Balance));
                    return true;
                default:
                    return false;
            }
        }
        public static string PrintAccountInfo(Account account)
        {
            string info = "null...";

            switch (account)
            {
                case CreditAccount creditNegative when creditNegative.Balance < 0: // credit med negativt saldo, skuldränta
                    account.Balance += account.Balance * (decimal)creditNegative.DebtInterest;
                    info = $"AccountID: {account.AccountID} Account Type: {account.GetType().Name}\n" +
                        $"Account balance: {account.Balance} Debt rate: {creditNegative.DebtInterest * 100}%";
                    return info;
                case SavingsAccount _:
                case CreditAccount _ when account.Balance >= 0:
                    account.Balance *= (1 + (decimal)account.Interest);
                    info = $"AccountID: {account.AccountID} Account Type: {account.GetType().Name}\n" + 
                        $"Account balance: {account.Balance} Account rate: {account.Interest * 100}%";
                    return info;
                default:
                    return info;

            }
        }

        public static int AddCreditAccount(Customer customer) // genererar nytt credit för vald kund
        {
            if (customer != null)
            {
                customer.Accounts.Add(new CreditAccount());
                return customer.Accounts.Last().AccountID;
            }
            return -1;
        }
    }
}
