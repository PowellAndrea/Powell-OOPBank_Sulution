﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class Checking : IAccount
    {
        public int _accountNumber { get; set; }
        public decimal _balance { get; set; }
        public decimal? MIN_Balance => 0;

        public Checking(int accountNumber)
        {
            _accountNumber = accountNumber;
            _balance = 0;
        }
    }
}