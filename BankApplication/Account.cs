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

        internal Transactions Transactions
        {
            get => default;
            set
            {
            }
        }
    }
}
