namespace OOPBank
{
    public class Account : IAccount
    {
        public decimal MIN_Balance = 0;

        internal static int _accountNumber;
        public int AccountNumber { get { return _accountNumber; } }

        internal decimal _balance;
        public decimal Balance { get { return _balance; } }
        
        internal int _customerId;
        public int CustomerId { get { return _customerId; } }

        private bool _odProtection = false;
        public bool ODProtection { get { return _odProtection; } }

        public void turnOnOd() { _odProtection = true; }
        public void turnOffOd() { _odProtection = false; }

        public Account(int customerID)
        {
            _accountNumber = generateId();
            _customerId = customerID;
            _balance = 0;
        }

        public void Deposit(decimal amount) 
        {
            _balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            var newBalance = _balance - amount;
            // hard limit on minimum balance, final check before withdrawl
            if (newBalance >= MIN_Balance)
            {
                _balance = newBalance;
            } else if (!ODProtection)
            {
                throw new Exception("Withdraw failed.  Under minimum balance");
            }
        }

        internal static int generateId()
        {
            int id = 1;
            return id += 1;
        }

    }
}
