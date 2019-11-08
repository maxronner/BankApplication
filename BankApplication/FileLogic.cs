using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplication
{
    class FileLogic
    {
        public void PrintCustomerInfo()
        {
            //Printa för- och efternamn samt personnummer till fil.

            using (StreamWriter writer = new StreamWriter("CustomerInformation.txt"))
            {
                //Hänvisa till listan i CustomerLogic.
            }
        }

        public void TransactionsHistory()
        {

            //Printa ut kontotransaktioner till fil enligt instruktion.

            using (StreamWriter writer = new StreamWriter("TransactionHistory.txt"))
            {
                //Hänvisa till listan i Transactions.
            }
        }

        public void ReadCustomerInfo()
        {

            //Läsa in kunder från filen, i detta fall kundernas namn + personnummer.

            string line;
            using (StreamReader reader = new StreamReader("CustomerList.txt"))
            {
                line = reader.ReadToEnd();
            }
        }
    }
}
