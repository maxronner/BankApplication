using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModels
{
    public class CustomerListModel
    {
        public ObservableCollection<Customer> Customers { get { return CustomerLogic.Customers; } }
        public int CurrentCustomer { get; set; }

        public CustomerListModel()
        {
        }

    }
}
