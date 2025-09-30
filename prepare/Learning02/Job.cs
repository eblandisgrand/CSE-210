using System;

public class Job
{
    public string _jobTitle;
    public string _company;
    public string _yearsOfService;


    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) ({_yearsOfService})");
    }
}

