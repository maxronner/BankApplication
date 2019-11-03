using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModels
{
    class CustomerListModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerListModel()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Customers = new ObservableCollection<Customer>(CustomerLogic.Customers);
        }

    }
}
