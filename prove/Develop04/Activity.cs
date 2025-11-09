using System;
using System.Threading;

public class Activity
{
    private string _name = "";
    private string _description = "";
    protected int _duration = 0;


    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public void DoStartingMessage()
    {
        Console.WriteLine(_name);
        Console.WriteLine(_description);
        
    }

    public void DoEndingMessage()
    {
        Console.WriteLine("Well done :-)");
        Console.WriteLine("Thank you for participating");
    }

    public void Spinner(int duration)
    {
        Console.CursorVisible = false;


        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\\");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        Console.CursorVisible = true;
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }   

}