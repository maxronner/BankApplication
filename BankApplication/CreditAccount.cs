using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class CreditAccount : Account
    {
        private double debtInterest;
        public long CreditLimit { get; set; }
        public double DebtInterest 
        { 
            get { return debtInterest; } 
            set { if (value < 0) debtInterest = 0; else debtInterest = value; }
        }
        public CreditAccount(double debtInterest, long creditLimit)
        {
            this.debtInterest = debtInterest;
            CreditLimit = creditLimit;
        }
    }
}
