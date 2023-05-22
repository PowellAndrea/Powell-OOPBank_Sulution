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

        public void Withdraw(IAccount account, decimal amount)
        {
            if (!account.Withdraw(amount))
            {
                decimal odAmount = account._balance - amount;
                if (_savings._balance - _savings.MIN_Balance >= odAmount)
                {
                    Transfer(_savings, account, amount);
                    account.Withdraw(amount);
                }

            }
        }

        public void Transfer(IAccount fromAccount, IAccount toAccount, decimal amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }

    }
}
