using System;
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Computer Engineer";
        job1._company = "Microsoft";
        job1._yearsOfService = "2000-2006";

        Job job2 = new Job();
        job2._jobTitle = "Elementary School Teacher";
        job2._company = "MJUSD";
        job2._yearsOfService = "2007-2011";

        Resume myResume = new Resume();
        myResume._name = "Ethan Bland";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
    
}