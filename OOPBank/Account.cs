namespace OOPBank
{
    public class Account : IAccount
    {
        internal static int _accountNumber;
        public int AccountNumber { get { return _accountNumber; } }

        internal decimal _balance;
        public decimal Balance { get { return _balance; } }

        public decimal MIN_Balance = 0;
        internal int _customerId;
        public int CustomerId { get { return _customerId; } }

        private bool _odProtection = false;
        public bool ODProtection { get { return _odProtection; } }

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

        public bool Withdraw(decimal amount)
        {
            var newBalance = _balance + amount;
            if (newBalance >= MIN_Balance) { _balance= newBalance; return true; }
            return false;
        }

        internal static int generateId()
        {
            int id = 1;
            return id += 1;
        }

    }
}
