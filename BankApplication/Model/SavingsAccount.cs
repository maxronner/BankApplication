using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Model
{
    class SavingsAccount : Account
    {
        public double WithdrawFee { get; set; }
        public bool FreeWithdraw { get; set; }

        public SavingsAccount (double interest, long accountId, long balance = 0) : base(balance, interest, accountId)
        {
            WithdrawFee = 0.02;
            FreeWithdraw = true;
        }
    }
}
