using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        private Customer customer;
        public AccountPage()
        {
            this.InitializeComponent();
        }

        private void myCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void myHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartPage));
        }

        private void myBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            customer = (Customer)e.Parameter;
            if (customer != null)
            {               
                this.mySSN.Text = customer.SSN.ToString();
                this.myCustomerName.Text = customer.Name;
            }
        }

        private void myTransactions_Click(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedItem != null)
            this.Frame.Navigate(typeof(TransactionsPage), accountList.SelectedItem);
        }

        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void addSavings_Click(object sender, RoutedEventArgs e)
        {
            int accountID = AccountLogic.AddSavingsAccount(customer);

            MessageDialog SavingsAccCreation = new MessageDialog($"Account ID: {accountID}", "Savings Account Created!");
            var result = await SavingsAccCreation.ShowAsync();
        }

        private async void myEditName_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogic.ChangeCustomerName(customer, myCustomerName.Text);


        }

        private async void addCredit_Click(object sender, RoutedEventArgs e)
        {
           int accountID = AccountLogic.AddCreditAccount(customer);

           
            MessageDialog CreditAccCreation = new MessageDialog($"Account ID: {accountID}" , "Credit Account Created!");
            var result = await CreditAccCreation.ShowAsync();
        }

        private async void myWithdraw_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            decimal amount = 0;
            if (accountList.SelectedIndex != -1)
            {
                decimal.TryParse(withdrawBox.Text, out amount);
                success = AccountLogic.Withdraw(customer.Accounts[accountList.SelectedIndex], amount);
            }
            MessageDialog withdraw;
            if (success)
            {
                withdraw = new MessageDialog($"{amount} SEK withdrawn", "Withdrawal successful!");
            }
            else
            {
                withdraw = new MessageDialog("Withdraw failed...");
            }
            await withdraw.ShowAsync();
        }

        private async void myDeposit_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            decimal amount = 0;
            if (accountList.SelectedIndex != -1)
            {
                decimal.TryParse(depositBox.Text, out amount);
                success = AccountLogic.Deposit(customer.Accounts[accountList.SelectedIndex], amount);                
            }            
            MessageDialog deposit;
            if (success)
            {
                deposit = new MessageDialog($"{amount} SEK Deposited", "Deposit Successful!");
            }
            else
            {
                deposit = new MessageDialog("Deposit failed...");
            }
            await deposit.ShowAsync();     
        }
        private async void myCloseAccount_Click(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedItem != null)
            {
                MessageDialog msg = new MessageDialog("Remove account permanently?", "Remove account");

                msg.Commands.Clear();
                msg.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
                msg.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

                var result = await msg.ShowAsync();

                if ((int)result.Id == 0)
                {
                    var selected = accountList.SelectedItem;

                    string rate = AccountLogic.CloseAccount((Account)selected, customer);

                    MessageDialog msg2 = new MessageDialog(rate, "Deleted account information");

                    var result2 = await msg2.ShowAsync();

                }
            }                    
        }
    }
}
