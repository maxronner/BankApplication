using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Model
{
    public class Transaction
    {
        public long AccountID { get; set; }
        public DateTime Time { get; set; }
        public bool TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }

        public Transaction(long accountID, bool transactionType, decimal amount, decimal newBalance)
        {
            AccountID = accountID;
            TransactionType = transactionType;
            Amount = amount;
            NewBalance = newBalance;
            Time = new DateTime();
        }
    }
}
