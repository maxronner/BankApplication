using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// A class that handles savings account information. 
    /// </summary>
    class SavingsAccount : Account
    {
        public double WithdrawFee { get; set; }
        public bool FreeWithdraw { get; set; }

        public SavingsAccount (double interest, long balance = 0) : base(balance, interest)
        {
            WithdrawFee = 0.02;
            FreeWithdraw = true;
        }
    }
}
