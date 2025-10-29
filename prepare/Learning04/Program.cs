using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Ethan", "Math");

        string summary = assignment1.GetSummary();

        Console.WriteLine(summary);

        MathAssignment mathAssignment1 = new MathAssignment("Ethan", "Addition", "Section 2", "Problems 3-4");

        string summary1 = mathAssignment1.GetHomeworkList();

        Console.WriteLine(summary1);

        Assignment assignment2 = new Assignment("Grace", "Write-A-Thon");

        string summary3 = assignment2.GetSummary();

        Console.WriteLine(summary3);

        WritingAssignment writingAssignment1 = new WritingAssignment("Grace", "Write-A-Thon", "Ed Core 200");

        string summary2 = writingAssignment1.GetTitle();

        Console.WriteLine(summary2);

    }
}