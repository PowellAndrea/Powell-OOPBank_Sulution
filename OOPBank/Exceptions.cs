using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    internal class Exceptions : Exception
    {
        public Exceptions() { 
            Exception NSF = new Exception("Insufficent Funds");
            Exception UnderMinimum = new Exception("Withdrawl failed, account below minimum balance.");
            Exception FailTransfer = new Exception("Transfer failed.");
        }
    }
}
