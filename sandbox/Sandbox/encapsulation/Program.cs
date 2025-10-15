using System;
using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
    //     Account acct = new Account();
    //     acct._balance += 5000;




    //     acct._balance = -1000;

    //     Console.WriteLine(acct._balance);

        Account acct = new Account();
        acct.Deposit(5000);
        acct.Deposit(10000);
        acct.Deposit(-200);
        acct.Withdraw(1800);

        Console.WriteLine($"Your balance is ${Account.GetBalance}")

        public double GetBalance()
        {
            return _balance
        }
    }
}