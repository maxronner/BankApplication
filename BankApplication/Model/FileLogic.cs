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
        public async void PrintCustomersInfo()
        {
            //Printa för- och efternamn samt personnummer till fil.

            foreach (var item in CustomerLogic.Customers)
            {
                Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("CustomerInformation.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, $"Namn: {item.Name} Personnummer: {item.SSN}");
            }

            //using (StreamWriter writer = new StreamWriter(@"C:\CustomerInformation.txt"))
            //{
            //    foreach (var item in CustomerLogic.Customers)
            //    {
            //        writer.WriteLine("Namn: {0} Personnummer: {1}", item.Name, item.SSN);
            //    }

            //    //Hänvisa till listan i CustomerLogic.
            //}
        }

        public async void TransactionsHistory()
        {
            //Snygga till koden
            foreach (var customer in CustomerLogic.Customers)
            {
                foreach (var account in customer.Accounts)
                {
                    foreach (var transaction in account.Transactions)
                    {
                        Windows.Storage.StorageFolder storageFolder =
                        Windows.Storage.ApplicationData.Current.LocalFolder;
                        Windows.Storage.StorageFile sampleFile =
                        await storageFolder.CreateFileAsync("TransactionHistory.txt",
                         Windows.Storage.CreationCollisionOption.ReplaceExisting);
                        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, $"{transaction.Time}\t" +
                                                                                $"Account ID: {transaction.AccountID}\t" +
                                                                                $"{transaction.TransactionType}\t\t" +
                                                                                $"Amount: {transaction.Amount}\t " +
                                                                                $"Remaining balance: {transaction.NewBalance}");
                    }
                }
            }

            //Printa ut kontotransaktioner till fil enligt instruktion.

            //using (StreamWriter writer = new StreamWriter("TransactionHistory.txt"))
            //{

            //    writer.WriteLine("Kontonummer: {0} Saldo: {1} kr Ränta: ({2}%)", account.AccountID, account.Balance, account.Interest);

            //    foreach (var item in account.Transactions)
            //    {
            //        writer.WriteLine("{0} {1} Insättning/Uttag: {2} Saldo: {3}", item.Time, item.Amount, item.NewBalance);
            //    }
            //    //Hänvisa till listan i Transactions.
            //}
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
