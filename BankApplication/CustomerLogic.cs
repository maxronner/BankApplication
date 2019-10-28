using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class CustomerLogic
    {
        public List<string> GetCustomers() { }
        public bool AddCustomer(string name, long pNr) { }
        public List<string> GetCustomer(long pNr) { }
        public bool ChangeCustomerName(string name, long pNr) { }
        public List<string> RemoveCustomer(long pNr) { }

    }
}
