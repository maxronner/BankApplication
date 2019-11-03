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
        private long creditLimit;
        public long CreditLimit 
        {
            get { return creditLimit; }
            set { if (value < 0) creditLimit = 0; else creditLimit = value; }
        }
        public double DebtInterest
        { 
            get { return debtInterest; } 
            set { if (value < 0) debtInterest = 0; else debtInterest = value; }
        }
        public CreditAccount(long accountID, long balance = 0, double interest = 0.005) :base(balance, interest, accountID)
        {
            debtInterest = 0.07;
            creditLimit = 5000;
        }
    }
}
