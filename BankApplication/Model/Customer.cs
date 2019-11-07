using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Customer : IComparable
    {
        private long ssn;
        public string Name { get; set; }
        public long SSN 
        { 
            get { return ssn; }
            set { if (value.ToString().Length != 10) ssn = 0; else ssn = value; }
        }
        public List<Account> Accounts { get; set; }

        public Customer(long ssn, string name, List<Account> account = null)
        {
            SSN = ssn;
            Name = name;
            Accounts = account;
        }
        public string Summary
        {
            get { return $"{SSN}\t{Name}"; }
        }
        public int CompareTo(object obj)
        {
            Customer customer = (Customer)obj;
            return this.Name.CompareTo(customer.Name);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Customer c = (Customer)obj;
        }
    }
}
