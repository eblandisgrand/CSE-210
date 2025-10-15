using System;
using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
        Account acct = new Account();
        acct._balance += 5000;




        acct._balance = -1000;

        Console.WriteLine(acct._balance);
    }
}