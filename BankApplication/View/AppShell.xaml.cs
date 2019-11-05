using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    /// Provides navigation within application
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public readonly string CustomerListLabel = "Customer list";
        public readonly string AccountListLabel = "Account list";
        public readonly string ExportMenuLabel = "Export data";
        public AppShell()
        {
            this.InitializeComponent();
        }
        public Frame AppFrame => frame;

        
        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(CustomerListPage))
                {
                    NavView.SelectedItem = CustomerListMenuItem;
                    frame.Navigate(typeof(CustomerListPage));
                }
                else if (e.SourcePageType == typeof(AccountListPage))
                {
                    NavView.SelectedItem = AccountListMenuItem;
                }
                else if (e.SourcePageType == typeof(SettingsPage))
                {
                    NavView.SelectedItem = NavView.SettingsItem;
                }
            }
        }
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            var pageType =
                args.IsSettingsInvoked ? typeof(SettingsPage) :
                label == CustomerListLabel ? typeof(CustomerListPage) :
                label == AccountListLabel ? typeof(AccountListPage) : null;
            if (pageType != null && pageType != AppFrame.CurrentSourcePageType)
            {
                AppFrame.Navigate(pageType);
            }
        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }
    }
}
