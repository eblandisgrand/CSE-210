using System;

class Program
{
    static void Main()
    {
        DisplayCalendar(DateTime.Now);
    }

    static void DisplayCalendar(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;

        // Header
        Console.WriteLine($"     {date:MMMM yyyy}");
        Console.WriteLine("Su Mo Tu We Th Fr Sa");

        // First day of the month
        DateTime firstDay = new DateTime(year, month, 1);

        // Number of days in month
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // Convert DayOfWeek to Sunday = 0
        int startDay = (int)firstDay.DayOfWeek;

        // Print initial spaces
        for (int i = 0; i < startDay; i++)
        {
            Console.Write("   ");
        }

        // Print dates
        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,2} ");

            // Move to next line after Saturday
            if ((startDay + day) % 7 == 0)
            {
                Console.WriteLine();
            }
        }


        Console.WriteLine("\n\n1--Create New Goal--");
        Console.WriteLine("2--Log New Income--");
        Console.WriteLine("3--Log New Expense--");
        Console.WriteLine("4--Display Progress--\n\n");
    }
}
