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
using Windows.UI.Popups;
using System.Windows.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartPage));
        }


        private void myExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            bool success = false;
            success = CustomerLogic.Login(UsernameBox.Text, PasswordBox.Password);


            if (success)
            {
                Frame.Navigate(typeof(CustomerListPage));
            }
            else
            {
                MessageDialog logincreation = new MessageDialog("Wrong username or password", "Login failure");
                {
                    logincreation.Commands.Add(new UICommand { Label = "OK" });

                }
                await logincreation.ShowAsync();
            }

        }


        private async void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool success = false;
            success = CustomerLogic.Login(UsernameBox.Text, PasswordBox.Password);

            if (e.Key == Windows.System.VirtualKey.Enter && success)
            {
                Frame.Navigate(typeof(CustomerListPage));
            }
            else if(e.Key == Windows.System.VirtualKey.Enter && !success)
            {
                MessageDialog logincreation = new MessageDialog("Wrong username or password", "Login failure");
                {
                    logincreation.Commands.Add(new UICommand { Label = "OK" });
                }
                await logincreation.ShowAsync();
            }
        }
    }
}