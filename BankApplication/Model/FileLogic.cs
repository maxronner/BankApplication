using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplication
{
    public class FileLogic
    {
        public void PrintCustomerInfo()
        {
            //Printa för- och efternamn samt personnummer till fil.

            using (StreamWriter writer = new StreamWriter("CustomerInformation.txt"))
            {
                foreach (var item in CustomerLogic.Customers)
                {
                    writer.WriteLine("Namn: {0} Personnummer: {1}", item.Name, item.SSN);
                }

                //Hänvisa till listan i CustomerLogic.
            }
        }

        public void TransactionsHistory(Account account)
        {

            //Printa ut kontotransaktioner till fil enligt instruktion.

            using (StreamWriter writer = new StreamWriter("TransactionHistory.txt"))
            {

                writer.WriteLine("Kontonummer: {0} Saldo: {1} kr Ränta: ({2}%)", account.AccountID, account.Balance, account.Interest);

                foreach (var item in account.Transactions)
                {
                    writer.WriteLine("{0} {1} Insättning/Uttag: {2} Saldo: {3}", item.Time, item.Amount, item.NewBalance);
                }
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
