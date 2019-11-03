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
        public ObservableCollection<Customer> Customers { get; set; }
        public int CurrentCustomer { get; set; }

        public CustomerListModel()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            customerLogic.Customers.Add(new Customer(123456789, "Max"));
            Customers = new ObservableCollection<Customer>(customerLogic.Customers);
        }

        public Customer Current
        {
            get => this.Customers.Count > 0 ? this.Customers[CurrentCustomer] : null;
        }
    }
}
