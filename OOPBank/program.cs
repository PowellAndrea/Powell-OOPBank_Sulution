using OOPBank;

bool Continue = true;
Bank bank = new();

Customer c = new("Andrea");
bank.addCustomer(c);
bank.Deposit(c.Checking, 2000M);
bank.Deposit(c.Savings, 3000M);


while (Continue)
{
    Console.WriteLine("\n\n\n");
    Console.WriteLine("Please select number 1-4 from the following:\n"
    + "1 : Deposit to savings\n"
    + "2 : Deposit to checking\n"
    + "3 : Withdraw from savings\n"
    + "4 : Withdraw from checking\n"
    + "5 : End");

    Continue = doStuff(Continue);
}

bool doStuff(bool Continue)
{
    switch (Console.ReadLine())
    {
        case "1":   // Deposit to savings
            {
                currentBalance(c.Savings);
                bank.Deposit(c.Savings, GetAmount("Deposit"));
                break;
            }
        case "2":   // Deposit to checking
            {
                currentBalance(c.Checking);
                bank.Deposit(c.Checking, GetAmount("Deposit"));
                break;
            }
        case "3":   // Withdraw from savings
            {
                currentBalance(c.Savings);
                bank.Withdraw(c.Savings, GetAmount("Withdraw"));
                break;
            }
        case "4":   // Withdraw from checking
            {
                currentBalance(c.Checking);
                bank.Withdraw(c.Checking, GetAmount("Withdraw"));
                break;
            }
        case "5":   // Exit
            { 
                Continue = false;
                break;
            }
        default:
            break;
    }
    return Continue;
}


void currentBalance(Account account)
{
    Console.WriteLine("The current balance in your " + account.GetType().Name + " account is " + account.Balance.ToString("C"));
}

decimal GetAmount(string action)
{
    // Fix this - remove logic from program and put it back in the class
    Console.WriteLine("Enter the amount to " + action);
    string strAmount = Console.ReadLine();
    decimal amount;
    if (decimal.TryParse(strAmount, out amount))
    {
        if (action == "Withdraw")
        {
            return -amount;
        } else { return amount; }
      }
    else
    {
        Console.WriteLine("\n\nInvalid entry.  Enter an amount as 12.34 \t");
        return 0;
    }
}