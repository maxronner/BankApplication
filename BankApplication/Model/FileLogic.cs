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
        /// <summary>
        /// Prints the first and last name as well as social security number to a file. 
        /// </summary>
        public async void PrintCustomersInfo()
        {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync("CustomerInformation.txt",
            Windows.Storage.CreationCollisionOption.ReplaceExisting);

            string result = "Newton Bank - Customer information\n\n";

            foreach  (Customer customer in CustomerLogic.Customers)
            {
                result += $"Name: {customer.Name} \n\tSSN: {customer.SSN}\n";
            }
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, result);
        }
        /// <summary>
        /// Prints selected account transaction history to a file. 
        /// </summary>
        /// <param name="account"></param>
        public async void PrintTransactionsHistory(Account account)
        {
            try
            {

                Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync($"TransactionHistory - {account.AccountID}.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);

                string result = $"AccountID: {account.AccountID} || Remaining balance: {account.Balance} SEK " +
                                $"|| {account.GetType().Name} ({account.Interest*100}%) \n ";

                foreach (var transaction in account.Transactions)
                {
                    result += $"\n{transaction.Time}\t" +
                                       $"{transaction.TransactionType}: \t" +
                                       $"Amount: {transaction.Amount} SEK \t " +
                                       $"Remaining balance: {transaction.NewBalance} SEK \n";
                }

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, result);
            }
            catch (Exception) { }
        }
    }
}
