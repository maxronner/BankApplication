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
            if (account != null)
            {
                account.Balance += amount;
                account.Transactions.Add(new Transaction(account.AccountID, "Deposit", amount, account.Balance));
                return true;
            }
            return false;
        }
        public static bool Withdraw(Account account, decimal amount) // withdraw för valt konto samt lagrar transaktionen i Transactions som ligger i Account
        {
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
        public static string CloseAccount(Account account, Customer customer) // stänger ett konto, beräknar ränta
        {
            string deletedAccount = "null...";

            switch (account)
            {
                case CreditAccount creditNegative when creditNegative.Balance < 0: // credit med negativt saldo, skuldränta
                    account.Balance += account.Balance * (decimal)creditNegative.DebtInterest;
                    deletedAccount = $"Account balance: {account.Balance} Debt rate: {creditNegative.DebtInterest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                case CreditAccount creditPositive when creditPositive.Balance > 0: //credit 
                    account.Balance *= (1 + (decimal)creditPositive.Interest);
                    deletedAccount = $"Account balance: {account.Balance} Account rate: {account.Interest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                case SavingsAccount savings:                                    // savings
                    account.Balance *= (1 + (decimal)savings.Interest);
                    deletedAccount = $"Account balance: {account.Balance} Account rate: {account.Interest * 100}%";
                    customer.Accounts.Remove(account);
                    return deletedAccount;
                default:
                    return deletedAccount;          //returnerar kontouppgifterna
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
