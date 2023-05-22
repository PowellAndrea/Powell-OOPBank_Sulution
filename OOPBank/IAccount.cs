using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public interface IAccount
    {
        int _accountNumber { get; set; }
        decimal _balance { get; set; }
        decimal? MIN_Balance { get; }


        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            decimal newBalance = _balance - amount;

            if (newBalance >= MIN_Balance || MIN_Balance.Equals(null))
            {
                _balance = newBalance;
                return true;
            }
            else
            {
                return false; 
            }
        }

        public string showBalance()
        {
            return "The current balance in Account " + _accountNumber + " is " + _balance.ToString("C");
        }

    }
}
