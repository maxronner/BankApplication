﻿using System;
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

        private void addSavings_Click(object sender, RoutedEventArgs e)
        {
            AccountLogic.AddSavingsAccount(customer);
        }

        private void myEditName_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogic.ChangeCustomerName(customer, myCustomerName.Text);

        }

        private void addCredit_Click(object sender, RoutedEventArgs e)
        {
            AccountLogic.AddCreditAccount(customer);
        }

        private void myWithdraw_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(withdrawBox.Text, out decimal amount);
            AccountLogic.Withdraw(customer.Accounts[accountList.SelectedIndex], amount);
        }

        private void myDeposit_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(depositBox.Text, out decimal amount);
            AccountLogic.Deposit(customer.Accounts[accountList.SelectedIndex], amount);
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
