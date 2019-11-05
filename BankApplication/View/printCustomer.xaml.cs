using System;
using System.Collections.Generic;
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
using BankApplication.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class printCustomer : Page
    {
        public printCustomer()
        {
            this.InitializeComponent();
        }

        private void myWithdraw_Click(object sender, RoutedEventArgs e)
        {
            //bool res = AccountLogic.Withdraw(ssn, accountID, amount);
            //if (res==true) { update balance}
            //else {...
           
        }

        private void myEditName_Click(object sender, RoutedEventArgs e)
        {
           myCustomerName.Text = myNewName.Text;
        }

        private void myCustomerName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
