using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scripture Memorizer\n");

        // Step 1: Create multiple scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Alma", 32, 28),
                @"Now, we will compare the word unto a seed. 
                Now, if ye give place, that a seed may be planted in your heart,
                behold, if it be a true seed, or a good seed, if ye do not cast it out by your unbelief,
                that ye will resist the Spirit of the Lord, behold, it will begin to swell within your breasts;
                and when you feel these swelling motions,
                ye will begin to say within yourselves—It must needs be that this is a good seed,
                or that the word is good, for it beginneth to enlarge my soul;
                yea, it beginneth to enlighten my understanding, yea, it beginneth to be delicious to me."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                @"Trust in the Lord with all thine heart; 
                and lean not unto thine own understanding.
                In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(new Reference("John", 3, 16),
                @"For God so loved the world, that he gave his only begotten Son, 
                that whosoever believeth in him should not perish, but have everlasting life.")
        };

        // Step 2: Display menu
        Console.WriteLine("Choose a scripture to memorize:\n");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
        }

        Console.Write("\nEnter a number: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > scriptures.Count)
        {
            Console.WriteLine("Invalid selection. Exiting program.");
            return;
        }

        // Step 3: Select scripture and begin memorizing
        Scripture selected = scriptures[choice - 1];
        StartMemorization(selected);
    }

    static void StartMemorization(Scripture scripture)
    {
        scripture.Display();

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Great job!");
                break;
            }
        }
    }
}
