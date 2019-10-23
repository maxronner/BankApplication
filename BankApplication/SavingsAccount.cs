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
    }
}
