namespace OOPBank
{
    public class Checking : Account
    {
        public Checking(int customerID) : base(customerID)
        {
            turnOnOd();
        }
    }
}
