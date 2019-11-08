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
            //  this.mySSN.Text=
        }

        private void myCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartPage));
        }

        private void myBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            customer = (Customer)e.Parameter;
            this.mySSN.Text = customer.SSN.ToString();
            this.myCustomerName.Text = customer.Name;
        }

        private void myTransactions_Click(object sender, RoutedEventArgs e)
        {
            object selected = accountList.SelectedItem;
            this.Frame.Navigate(typeof(TransactionsPage), selected);
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

            MessageDialog NameChange = new MessageDialog($"New Name: {myCustomerName.Text}", "Name Was Changed Successfully!");
            var result = await NameChange.ShowAsync();

        }

        private async void addCredit_Click(object sender, RoutedEventArgs e)
        {
           int accountID = AccountLogic.AddCreditAccount(customer);

           
            MessageDialog CreditAccCreation = new MessageDialog($"Account ID: {accountID}" , "Credit Account Created!");
            var result = await CreditAccCreation.ShowAsync();
        }

        private async void myWithdraw_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(withdrawBox.Text, out decimal amount);
            AccountLogic.Withdraw(customer.Accounts[accountList.SelectedIndex], amount);

            MessageDialog SavingsWithdraw = new MessageDialog($"{amount} SEK withdrawn", "Withdrawal successful!");
            var result = await SavingsWithdraw.ShowAsync();

        }

        private async void myDeposit_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(depositBox.Text, out decimal amount);
            AccountLogic.Deposit(customer.Accounts[accountList.SelectedIndex], amount);

            MessageDialog Deposit = new MessageDialog($"{amount} SEK Deposited", "Deposit Successful!");
            var result = await Deposit.ShowAsync();
        }
        private async void myCloseAccount_Click(object sender, RoutedEventArgs e)
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
