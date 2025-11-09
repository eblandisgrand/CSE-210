using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people you appreciate?",
        "What are personal strengths you have?",
        "Who have you helped recently?",
        "What are things that bring you joy?"
    };

    public Listing(int duration)
        : base("Listing Activity", "List as many items as you can in the allotted time.", duration){}

    public void Run()
    {
        DoStartingMessage();
        Console.CursorVisible = false;
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"List items for: {prompt}");

        Console.WriteLine("You may begin in:");
        Countdown(5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        Console.CursorVisible = true;
        DoEndingMessage();
    }
}
