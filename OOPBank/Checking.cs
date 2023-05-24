namespace OOPBank
{
    public class Checking : Account
    {
        private bool _odProtection;
        public bool OdProtection { get { return _odProtection; } }

        public Checking(int customerID) : base(customerID)
        {
            _odProtection = true;
        }
    }
}
