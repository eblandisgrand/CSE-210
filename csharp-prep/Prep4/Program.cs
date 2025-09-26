using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        
        int NewNumber = -1;
        while (NewNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userinput = Console.ReadLine();
            NewNumber = int.Parse(userinput);
            
            
            if (NewNumber != 0)
            {
                numbers.Add(NewNumber);
            }
        }

        //Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        //Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Compute the max
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}