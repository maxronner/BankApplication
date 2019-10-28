using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    abstract class Account
    {
        public long Balance { get; set; }
        public double Interest { get; set; }
        public long AccountID { get; set; } //MÅSTE VARA UNIKT

        public Account(long balance, double interest, long accountId)
        {
            Balance = balance;
            Interest = interest;
            AccountID = accountId;
        }
    }
}
