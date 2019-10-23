using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Customer
    {
        public string Name { get; set; }
        public long PNr { get; private set; }
        public List<Account> Accounts { get; set; }

        internal Account Account
        {
            get => default;
            set
            {
            }
        }
    }
}
