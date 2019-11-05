using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Model;

namespace BankApplication.ViewModels
{
    public class CustomerPageModel
    {
        public ObservableCollection<Customer> Customers { get { return CustomerLogic.Customers; } }

        public CustomerPageModel()
        {
        }
     
    }
}
