namespace OOPBank
{
    internal class Bank
    {
        public string Name { get; }

        private List<Customer> _customers;

        public Bank()
        {
            Name = "Solvent Bank";
            _customers = new List<Customer>();
        }

        public void addCustomer(string name) {
            Customer newCustomer = new Customer(name);
            _customers.Add(newCustomer);
        }

        public Customer getCustomer(int customerID)
        {
            try
            {
                Customer? c = _customers.Find(c => c.CustomerID == customerID);
                if (c == null) {
                    Console.WriteLine("Customer not found.\n");
                };

                return c;

            } catch (Exception ex) { throw; }
        }

        public void Deposit(Account account, decimal amount)
        {
            account.Deposit(amount);
            Console.WriteLine(string.Format(amount.ToString(), "C") + " has been deposited to your " + account.GetType().Name);
            currentBalance(account);
        }

        public void Withdraw(Account account, decimal amount)
        {
            if (!account.Withdraw(amount))
            {
                if (account.ODProtection)
                {
                    decimal od = account.Balance - account.MIN_Balance - amount;
                    Account s = getCustomer(account.CustomerId).Savings;
                    if (s.Balance - s.MIN_Balance - od >= 0 )
                    {
                        if (Transfer(s, account, od)) {
                            account.Withdraw(amount);
                        }
                    }
                }
            }
        }

        public void currentBalance(Account account)
        {
            Console.WriteLine("The current balance in your " + account.GetType().Name + " is " + account.Balance.ToString("C"));
        }

        public bool Transfer(Account fromAccount, Account toAccount, decimal amount)
        {
            if (fromAccount.Withdraw(amount))
            {
                toAccount.Deposit(amount);
                return true;
            } else {
                Console.WriteLine("Unable to complete transfer.");
                return false;
            }
        }
    }
}
