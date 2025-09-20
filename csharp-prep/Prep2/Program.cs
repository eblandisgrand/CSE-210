using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?: ");

        string StudentGrade = Console.ReadLine();
        int number = int.Parse(StudentGrade);

        string grade = "";

        if (number >= 90)
        {
            grade = "A";
        }
        else if (number >= 80)
        {
            grade = "B";
        }
        else if (number >= 70)
        {
            grade = "C";
        }
        else if (number >= 60)
        {
            grade = "D";
        }
        else if (number < 60)
        {
            grade = "F";
        }

        Console.WriteLine($"Your letter grade is: {grade}");

        if (number >= 70)
        {
            Console.WriteLine("Good job, you passed!");

        }
        else
        {
            Console.WriteLine("You failed, try harder next time.");
        }
    }
}