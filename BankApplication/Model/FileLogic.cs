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
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync("CustomerInformation.txt",
            Windows.Storage.CreationCollisionOption.ReplaceExisting);

            List<string> customerInfo = new List<string>();

            foreach (var customer in CustomerLogic.Customers)
            {
                customerInfo.Add($"Name: {customer.Name} \n\tSSN: {customer.SSN}\n");
            }
            string bankInfo = "Newton Bank - Customer information\n\n";
            string allCustomers = String.Join("", customerInfo.ToArray());
            string allInfo = String.Concat(bankInfo, allCustomers);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, allInfo);
        }

        public async void TransactionsHistory(Account account)
        {
            try
            {

                Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync($"TransactionHistory - {account.AccountID}.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);

                List<string> specTrans = new List<string>();

                foreach (var transaction in account.Transactions)
                {
                    specTrans.Add($"\n{transaction.Time}\t" +
                                       $"{transaction.TransactionType}: \t" +
                                       $"Amount: {transaction.Amount} SEK \t " +
                                       $"Remaining balance: {transaction.NewBalance}\n");
                }
                var accInfo = $"AccountID: {account.AccountID} Remaining balance: {account.Balance}\n";
                var allTrans = String.Join(" ", specTrans.ToArray());
                var transHist = String.Concat(accInfo, allTrans);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, transHist); 
            }
            catch (Exception) { }
        }
    }
}
