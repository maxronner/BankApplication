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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerListPage : Page
    {
        public CustomerListPage()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<Customer> customers { get { return CustomerLogic.Customers; } }

        private void myHome_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void myRemove_Click(object sender, RoutedEventArgs e)
        {
            var selected = customerList.SelectedItem;

            CustomerLogic.RemoveCustomer((Customer)selected);
            

        }

        private async void mySearch_Click(object sender, RoutedEventArgs e)
        {
            var input = mySearchBox.Text;
            long.TryParse(input, out long result);
            //var message = new MessageDialog("Type a valid name/ssn!");
            //await message.ShowAsync();

            for (int i = 0; i < customers.Count; i++)
            {
                if (result == customers[i].SSN || input == customers[i].Name)
                {
                    var selected = customers[i];
                    Frame.Navigate(typeof(AccountPage), selected);
                }

            }
        }

        private void mySearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myView_Click(object sender, RoutedEventArgs e)
        {
            var selected = customerList.SelectedItem;
            this.Frame.Navigate(typeof(AccountPage), selected);
        }

    

        private void printCustomerButton_Click(object sender, RoutedEventArgs e)
        {

            new FileLogic().PrintCustomersInfo();

        }

        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            name = this.accountNameBox.Text;
            long ssn;
            ssn = Convert.ToInt64(this.accountSSNBox.Text);
            CustomerLogic.AddCustomer(name, ssn);
        }
    }
}
