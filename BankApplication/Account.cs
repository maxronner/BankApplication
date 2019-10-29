using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    abstract class Account
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public decimal Balance { get; set; }
        public double Interest { get; set; }
        public long AccountID { get; set; } //MÅSTE VARA UNIKT

        public Account(long balance, double interest, long accountId)
        {
            Balance = balance;
            Interest = interest;
            AccountID = accountId;
        }

        //to string
    }
}
