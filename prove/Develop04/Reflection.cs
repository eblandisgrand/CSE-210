using System;
using System.Collections.Generic;
using System.Threading;

public class Reflection : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you stood up for someone else.",
        "Think of a time you did something really difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you felt truly peaceful."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What made this moment special?",
        "What did you learn from this experience?",
        "How can you apply this lesson in your everyday life?"
    };

    public Reflection(int duration)
        : base("Reflection Activity", "This activity will help you reflect on times you showed strength and resilience.", duration){}

    public void Run()
    {
        DoStartingMessage();
        Console.CursorVisible = false;
        Console.WriteLine("\nThink about the following prompt:");
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---\n");

        Console.Write("Press Enter when you are ready...");
        Console.ReadLine();

        Console.WriteLine("\nGet ready...");
        Spinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[new Random().Next(_questions.Count)];
            Console.WriteLine(question);
            Spinner(4);
            Console.WriteLine();
        }
        Console.CursorVisible = true;
        DoEndingMessage();
    }
}
