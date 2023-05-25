namespace OOPBank
{
    public class Savings : Account
    {
        public Savings(int customerID) : base(customerID)
        {
            MIN_Balance = 10;
        }
    }
}