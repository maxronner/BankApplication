using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Transactions
    {
        public long AccountIDFrom { get; set; }
        public long AccountIDTo { get; set; }
        public DateTime _DateTime { get; set; }
        public bool TransactionType { get; set; }
        public long Amount { get; set; }
        public long BalanceAfter { get; set; }

        public int AddCreditAccount(long pNr) { }
        public List<string> GetTransactions(long pNr, int accountId) { }

    }
}
