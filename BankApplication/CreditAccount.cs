using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class CreditAccount : Account
    {
        public long CreditLimit { get; set; }
        public double DebtInterest { get; set; }
    }
}
