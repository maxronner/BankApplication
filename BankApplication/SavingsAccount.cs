using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class SavingsAccount : Account
    {
        public double WithdrawFee { get; set; }
        public bool FreeWithdraw { get; set; }

        public SavingsAccount (double withdrawFee, bool freeWithdraw) : base(balance, interest, accountId)
        {
            WithdrawFee = withdrawFee;
            FreeWithdraw = freeWithdraw;
        }


    }
}
