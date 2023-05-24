namespace OOPBank
{
    interface IAccount
    {
        int AccountNumber { get; }
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
