using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Transaction
    {
        public long AccountID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }

        public Transaction(long accountID, bool transactionType, decimal amount, decimal newBalance)
        {
            AccountID = accountID;
            TransactionType = transactionType;
            Amount = amount;
            NewBalance = newBalance;
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        public string Summary
        {
            get { return $"{Time}\t{AccountID}\t{TransactionType}\t{Amount}\t{NewBalance}"; }
        }
    }
}
