using System.Xml.Linq;

namespace OOPBank
{
    public class Bank
    {
        public string Name { get; }

        private List<Customer> _customers;
        public int CustomerCount(){ return _customers.Count(); }

        public Bank()
        {
            Name = "Solvent Bank";
            _customers = new List<Customer>();
        }

        //public void addCustomer(string name) {
        //    Customer newCustomer = new Customer(name);
        //    _customers.Add(newCustomer);
        //}

        public void addCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer getCustomer(string name) {
            return _customers.Find(x => x.Name.Equals(name));
        }

        public Customer getCustomer(int customerID)
        {
            return _customers.Find(x => x.ID.Equals(customerID));
        }

        public void Deposit(Account account, decimal amount)
        {
            account.Deposit(amount);
            Console.WriteLine(string.Format(amount.ToString(), "C") + " has been deposited to your " + account.GetType().Name);
            CurrentBalance(account);
        }

        public void Withdraw(Account account, decimal amount)
        {
            try
            {
                account.Withdraw(amount);
            }
            catch
            {
                if (account.ODProtection)
                {
                    // should I be able to grab the balance amount from exception thrown?
                    decimal od = account.Balance - account.MIN_Balance - amount;
                    Account s = getCustomer(account.CustomerId).Savings;
                    if (s.Balance - s.MIN_Balance - od >= 0)
                    {
                        if (Transfer(s, account, od))
                        {
                            account.Withdraw(amount);
                        }
                    }
                }
            }
        }

        public static void CurrentBalance(Account account)
        {
            Console.WriteLine("The current balance in your " + account.GetType().Name + " is " + account.Balance.ToString("C"));
        }

        public bool Transfer(Account fromAccount, Account toAccount, decimal amount)
        {
            try
            {
                fromAccount.Withdraw(amount); 
            } catch
            {
                // send to debug window?
                Console.WriteLine("Unable to complete transfer.");
                return false;
            }

            toAccount.Deposit(amount);
            return true;
        }
    }
}
