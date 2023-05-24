namespace OOPBank
{
    public class Customer
    {
        
        public int CustomerID { get; set; }

        private string _name { get; set; }
        public string Name { get { return _name; } }

        private Savings _savings;
        private Checking _checking;

        public Savings Savings { get { return _savings; } }
        public Checking Checking { get { return _checking; } }

        public Customer(string name)
        {
            CustomerID = generateId();
            _name = name;
            _savings = new(CustomerID);
            _checking = new(CustomerID);
        }

        static int generateId()
        {
            int id = 1;
            return id += 1;
        }

    }
}
