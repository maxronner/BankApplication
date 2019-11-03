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
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            CustomerLogic.Customers.Add(new Customer(1234567890, "Max"));
            Customers = new ObservableCollection<Customer>(CustomerLogic.Customers);
        }

        public Customer Current
        {
            get => this.Customers.Count > 0 ? this.Customers[CurrentCustomer] : null;
        }
    }
}
