using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class Customer
    {
        public string _name { get; set; }
        public Savings _savings { get; set; }
        public Checking _checking { get; set; }

        public Customer(string name)
        {
            _name = name;
            _savings = new(1);      // Account Number = 1
            _checking = new(2);
        }

    }
}
