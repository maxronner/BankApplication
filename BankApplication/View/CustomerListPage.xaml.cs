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
    public sealed partial class CustomerListPage : Page
    {
        public CustomerListPage()
        {
            this.InitializeComponent();
            
        }
        private void CommandBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void CustomerSearchBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerAddPage));
        }
    }
}
