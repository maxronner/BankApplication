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
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();
        public decimal Balance { get; set; }
        public double Interest { get; set; }
        public int AccountID { get; set; } //MÅSTE VARA UNIKT

        public Account(long balance, double interest)
        {
            Balance = balance;
            Interest = interest;
            AccountID = AccountLogic.NewAccountID();
        }
        public string Summary
        {
            get { return $"{AccountID} \t {Balance} \t {Interest*100}% \t {GetType().Name}"; }
        }
        //to string
    }
}
