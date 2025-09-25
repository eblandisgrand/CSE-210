using System;

class Program
{
    static void Main(string[] args)
    {
        string PlayAgain = "";
        while (PlayAgain != "no")
        {

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);

            int guess = 0;

            Console.WriteLine("Welcome to the magic number generator, try to guess the magic number!");


            while (guess != number)
            {

                Console.WriteLine("What is your guess?: ");
                guess = int.Parse(Console.ReadLine());


                if (guess < number)
                {
                    Console.WriteLine("Higher");

                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess == number)
                {
                    Console.WriteLine($"Good job you guessed correct, the magic number is {number}");
                    Console.WriteLine("Would you like to play again? yes/no: ");
                    PlayAgain = Console.ReadLine().ToLower();
                }
            }
        }
        
    }
}