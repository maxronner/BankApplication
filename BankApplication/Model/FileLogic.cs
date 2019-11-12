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
        }

        public async void TransactionsHistory(Account account)
        {
            try
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
            catch (Exception) { }         
        }
    }
}
