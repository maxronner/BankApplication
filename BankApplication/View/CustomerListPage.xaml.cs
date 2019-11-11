using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            this.Frame.Navigate(typeof(StartPage));
        }

        private async void myRemove_Click(object sender, RoutedEventArgs e)
        {
            if (customerList.SelectedItem != null)
            {
                MessageDialog msg = new MessageDialog("Remove customer permanently?", "Remove customer");

                msg.Commands.Clear();
                msg.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
                msg.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

                var result = await msg.ShowAsync();

                if ((int)result.Id == 0)
                {
                    CustomerLogic.RemoveCustomer((Customer) customerList.SelectedItem);
                }
            }
        }

        private void mySearch_Click(object sender, RoutedEventArgs e)
        {
            var input = mySearchBox.Text;
            long.TryParse(input, out long result);


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
        private void myView_Click(object sender, RoutedEventArgs e)
        {
            if (customerList.SelectedItem is Customer customer)
            this.Frame.Navigate(typeof(AccountPage), customer);
        }

        private async void printCustomerButton_Click(object sender, RoutedEventArgs e)
        {

            //new FileLogic().PrintCustomersInfo();

            MessageDialog PrintCustomers = new MessageDialog($"Customers were printed to file", "Customers Printed Successfully!");
            var result = await PrintCustomers.ShowAsync();
        }

        private async void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (long.TryParse(accountSSNBox.Text, out long ssn))
            {
                success = CustomerLogic.AddCustomer(accountNameBox.Text, ssn);
            }                    
            MessageDialog customerCreation;
            if (success)
            {
            customerCreation = new MessageDialog($"Name: {accountNameBox.Text}\nSSN: {ssn}", "Customer Created Successfully!");
            }
            else
            {
            customerCreation = new MessageDialog("Customer creation failed...");
            }            
            await customerCreation.ShowAsync();
        }
    }
}
