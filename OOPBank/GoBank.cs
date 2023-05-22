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
                doTransaction(Savings, "Deposit");
                break;
            }
        case "2":   // Deposit to Checking
            {
                doTransaction(Checking, "Deposit");
                break;
            }
        case "3":   // Withdraw from Savings
            {
                doTransaction(Savings, "Withdraw");
                break;
            }
        case "4":   // Withdraw from Checking
            {
                doTransaction(Checking, "Withdrawl");
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


void doTransaction(IAccount Account, string Action)
{
    Console.WriteLine(Account.showBalance());
    switch (Action)
    {
        case "Deposit":
            {
                Account.Deposit(GetAmount(Action));
                break;
            }
        case "Withdraw":
            {
                if (Account.Withdraw(GetAmount(Action)))
                {
                    Console.WriteLine(Account.showBalance());
                }
                else
                {
                    Console.WriteLine("Withdrawl over maximum amount");
                }
                break;
            };
    }
    Console.WriteLine(Account.showBalance());
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