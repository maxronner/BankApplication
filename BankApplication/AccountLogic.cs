using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class AccountLogic
    {
        public int AddSavingsAccount(long pNr) { }
        public string GetAccount(long pNr, int accountId) { }
        public bool Deposit(long pNr, int accountId, decimal amount) { }
        public bool Withdraw(long pNr, int accountId, decimal amount) { }
        public string CloseAccount(long pNr, int accountId) { }
    }
}
