using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class CustomerLogic
    {
        public ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public List<string> GetCustomers() 
        {
            //foreach
        }
        public bool AddCustomer(string name, long ssn) 
        {
            if (customers.Contains(new Customer(ssn, name)))
            {
                return false;
            }
            else
            {
                customers.Add(new Customer(ssn, name));
                return true;
            }
            //Customers.Add(new Customer(ssn, name))
        }
        public List<string> GetCustomer(long ssn) 
        {
            //sql?
        }
        public bool ChangeCustomerName(string name, long ssn) { }
        public List<string> RemoveCustomer(long ssn) { }

    }
}
