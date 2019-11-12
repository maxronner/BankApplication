using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class CreditAccount : Account
    {
        public decimal CreditLimit { get; set; }
        public double DebtInterest { get; set; }
        public CreditAccount(decimal balance = 0, double interest = 0.005) :base(balance, interest)
        {
            DebtInterest = 0.07;
            CreditLimit = 5000;
        }
    }
}
