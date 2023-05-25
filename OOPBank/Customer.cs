namespace OOPBank
{
    public class Customer
    {
        private int Id;
        public int ID { get { return Id; } }

        private string _name { get; set; }
        public string Name { get { return _name; } }

        private Savings _savings;
        private Checking _checking;

        public Savings Savings { get { return _savings; } }
        public Checking Checking { get { return _checking; } }

        public Customer(string name)
        {
            Id = generateId();
            _name = name;
            _savings = new(Id);
            _checking = new(Id);
        }

        static int generateId()
        {
            int id = 1;
            return id += 1;
        }

    }
}
