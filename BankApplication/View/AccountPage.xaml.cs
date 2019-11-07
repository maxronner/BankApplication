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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        private Customer customer;
        private ObservableCollection<Account> accounts { get { return customer.Accounts; } set { customer.Accounts = value; } }
        public AccountPage()
        {
            this.InitializeComponent();
            accounts.Add(new CreditAccount());
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
            var param = (Customer)e.Parameter;
            customer = param;
            this.mySSN.Text = param.SSN.ToString();
            this.myCustomerName.Text = param.Name;

        }

        private void myTransactions_Click(object sender, RoutedEventArgs e)
        {
            var selected = accountList.SelectedItem;
            this.Frame.Navigate(typeof(TransactionsPage), selected);
        }

        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addSavings_Click(object sender, RoutedEventArgs e)
        {
            sender.ToString();
           
          
        }

        private void addSavings_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
