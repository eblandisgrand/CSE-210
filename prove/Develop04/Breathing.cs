using System;

public class Breathing : Activity
{
    public Breathing(int duration)
        : base("Breathing Activity", "This activity will help you relax by guiding your breathing.", duration){}

    public void Run()
    {
        DoStartingMessage();
        Console.CursorVisible = false;
        Console.WriteLine("Get ready...");
        Spinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.CursorVisible = false;
            Console.Write("Breathe in... ");
            Countdown(6);
            Console.WriteLine();

            Console.Write("Hold it in...");
            Countdown(5);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            Countdown(6);
            Console.WriteLine();
            Console.WriteLine();
            Console.CursorVisible = true;
        }
        Console.CursorVisible = true;
        DoEndingMessage();
    }
}
