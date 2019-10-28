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
        public long Interest { get; set; }
        public long AccountID { get; set; }

        public Account(long balance, long interest, long accountId)
        {
            Balance = balance;
            Interest = interest;
            AccountID = accountId;
        }
    }
}
