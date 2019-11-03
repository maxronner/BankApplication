using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModel
{
    public class CustomerAddModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
    }
}
