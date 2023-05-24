namespace OOPBank
{
    public class Savings : Account
    {
        public new static decimal MIN_Balance = 10;

        public Savings(int customerID) : base(customerID)
        {
        }
    }
}