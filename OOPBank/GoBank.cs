using OOPBank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

bool Continue = true;
Customer customer = new("Andrea");
IAccount Savings = customer._savings;
IAccount Checking = customer._checking;

Savings.Deposit(3000);
Checking.Deposit(2000);


while (Continue)
{
    Console.WriteLine("\n\n\n");
    Console.WriteLine("Please select number 1-4 from the following:\n"
    + "1 : Deposit to Savings\n"
    + "2 : Deposit to Checking\n"
    + "3 : Withdraw from Savings\n"
    + "4 : Withdraw from Checking\n"
    + "5 : End");

    Continue = doStuff(Continue);
}

bool doStuff(bool Continue)
{
    switch (Console.ReadLine())
    {
        case "1":   // Deposit to Savings
            {
                Savings.Deposit(GetAmount("Deposit"));
                break;
            }
        case "2":   // Deposit to Checking
            {
                Checking.Deposit(GetAmount("Deposit"));
                break;
            }
        case "3":   // Withdraw from Savings
            {
                Savings.Withdraw(GetAmount("Withdraw"));
                break;
            }
        case "4":   // Withdraw from Checking
            {
                Checking.Withdraw(GetAmount("Withdraw"));
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

decimal GetAmount(string action)
{
    Console.WriteLine("Enter the amount to " + action);
    string strAmount = Console.ReadLine();
    decimal amount;
    if (decimal.TryParse(strAmount, out amount))
    {
        return amount;
    }
    else
    {
        Console.WriteLine("\n\nInvalid entry.  Enter an amount as 12.34 \t");
        return 0;
    }
}