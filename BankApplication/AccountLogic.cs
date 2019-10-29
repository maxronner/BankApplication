using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class AccountLogic
    {
        public int AddSavingsAccount(long ssn) 
        {
            foreach (var item in CustomerLogic.Customers)
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

        public string GetAccount(long pNr, int accountId) { }

        public bool Deposit(long pNr, int accountId, decimal amount) { }

        public bool Withdraw(long pNr, int accountId, decimal amount) { }

        public string CloseAccount(long pNr, int accountId) { }

    }
}
