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

        public void addCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer getCustomer(string name) {
            return _customers.Find(x => x.Name.Equals(name));
        }

        public Customer getCustomer(int customerID)
        {
            return _customers.Find(x => x.ID == customerID);
        }

        public void Deposit(Account account, decimal amount)
        {
            account.Deposit(amount);
        }

        // Needs more testing
        public void Withdraw(Account account, decimal amount)
        {
            decimal testBalance = account.Balance - amount;
            if (testBalance > account.MIN_Balance)
            {   // normal case
                account.Withdraw(amount);
            }
            else if (account.ODProtection)
            {
                Savings savings = getCustomer(account.CustomerId).Savings;
                if (savings.Balance - savings.MIN_Balance > testBalance)
                {
                    if (!Transfer(savings, account, testBalance))
                    {
                        throw new Exception("Transfer failed"); ;
                    }
                }
                else
                {
                    throw new Exception("Withdraw faild. Balance under minimum.");
                }
            }
            else throw new Exception("Insufficent Funds");
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
            return true;
        }
    }
}
