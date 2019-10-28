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
        public string Type { get; set; }
        public long AccountID { get; set; }

        public Account(long balance, long interest, string type, long accountId)
        {
            Balance = balance;
            Interest = interest;
            Type = type;
            AccountID = accountId;
        }
    }
}
