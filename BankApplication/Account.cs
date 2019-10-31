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
        public int AccountID { get; set; } //MÅSTE VARA UNIKT

        public Account(decimal balance, double interest, int accountId)
        {
            Balance = balance;
            Interest = interest;
            AccountID = accountId;
        }

        //to string
    }
}
