using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        string YourName = UserName();
        int YourNumber = UserNumber();

        int NumberSquared = SquareNumber(YourNumber);

        int BirthYear;
        UserBirthyear(out BirthYear);


        DisplayResult(YourName, NumberSquared, BirthYear);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string UserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int UserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static void UserBirthyear(out int birthYear)
    {
        Console.Write("Enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());

    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will be {2025 - birthYear} years old this year.");
    }
}