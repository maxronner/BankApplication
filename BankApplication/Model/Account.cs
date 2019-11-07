using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public abstract class Account
    {
        private int accountID;
        
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();
        public decimal Balance { get; set; }
        public double Interest { get; set; }
        public int AccountID { get { return accountID; } private set { AccountLogic.NewAccountID(); } } //MÅSTE VARA UNIKT

        public Account(long balance, double interest)
        {
            Balance = balance;
            Interest = interest;
            accountID = AccountID;
        }
        public string Summary
        {
            get { return $"{AccountID}\t{Balance}\t{Interest} {typeof(Account).ToString()}"; }
        }
        //to string
    }
}
