using OOPBank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class Savings : IAccount
    {
        public int _accountNumber { get; set; }
        public decimal _balance { get; set; }
        public decimal? MIN_Balance => 10;

        public Savings(int accountNumber)
        {
            _accountNumber = accountNumber;
            _balance = 0;
        }
    }
}
