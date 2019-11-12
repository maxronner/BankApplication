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
        private void myHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StartPage));
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
                mySSN.Text = customer.SSN.ToString();
                myCustomerName.Text = customer.Name;
            }
        }
        private void myTransactions_Click(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedItem != null)
            Frame.Navigate(typeof(TransactionsPage), accountList.SelectedItem);
        }
        private async void addSavings_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog SavingsAccCreation = new MessageDialog($"Account ID: {AccountLogic.AddSavingsAccount(customer)}", "Savings Account Created!");
            await SavingsAccCreation.ShowAsync();
        }
        private async void myEditName_Click(object sender, RoutedEventArgs e)
        {
            if (!CustomerLogic.ChangeCustomerName(customer, myCustomerName.Text))
            {
                MessageDialog msg = new MessageDialog("You can only enter letters.", "Error!");
                myCustomerName.Text = "";
                myCustomerName.PlaceholderText = "Enter Name";
                await msg.ShowAsync();
            }
            else
            {
                MessageDialog msg2 = new MessageDialog($"Name was changed to {myCustomerName.Text}. ","Name Change Successful!");
                await msg2.ShowAsync();
            }
        }
        private async void addCredit_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog CreditAccCreation = new MessageDialog($"Account ID: {AccountLogic.AddCreditAccount(customer)}" , "Credit Account Created!");
            await CreditAccCreation.ShowAsync();
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
                    string rate = AccountLogic.CloseAccount((Account)accountList.SelectedItem, customer);
                    MessageDialog msg2 = new MessageDialog(rate, "Deleted account information");
                    await msg2.ShowAsync();

                }
            }                    
        }
    }
}
