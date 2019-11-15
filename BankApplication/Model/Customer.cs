using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Handles customer information.
    /// </summary>
    public class Customer
    {
        private long ssn;
        public string Name { get; set; }
        public long SSN 
        { 
            get { return ssn; }
            private set { if (value.ToString().Length != 10) ssn = 0; else ssn = value; }
        }
        /// <summary>
        /// The selected customers accounts. 
        /// </summary>
        public  ObservableCollection<Account> Accounts { get; set; }        

        public Customer(long ssn, string name)
        {
            SSN = ssn;
            Name = name;
            Accounts = new ObservableCollection<Account>();
        }
    }
}
