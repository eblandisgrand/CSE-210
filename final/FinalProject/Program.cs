using System;

class Program
{
    static void Main(string[] args)
    {

        Calendar.DisplayCalendar(DateTime.Now);

        Console.WriteLine("\n\n1--Create New Goal--");
        Console.WriteLine("2--Log New Income--");
        Console.WriteLine("3--Log New Expense--");
        Console.WriteLine("4--Display Progress--\n\n");
    }
}