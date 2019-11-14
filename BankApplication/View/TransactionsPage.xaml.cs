using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class TransactionsPage : Page
    {
        private Account account;
        public TransactionsPage()
        {
            this.InitializeComponent();

        }

        private void myBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            account = (Account)e.Parameter;
            //behandla data från mottaget objekt 
        }

        private async void myPrint_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog Print = new MessageDialog($"Transactions were printed to C:'\'Users'\'USER'\'AppData'\'Local'\'Packages", "Transactions printed!");
            await Print.ShowAsync();
            new FileLogic().TransactionsHistory(account);
        }
    }
}
