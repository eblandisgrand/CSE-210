using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            manager.ShowScore();
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine()?.Trim();

            if (choice == "1")
            {
                ConsoleHelpers.WriteInfo("Which type?");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");

                string type = Console.ReadLine()?.Trim();

                Console.Write("Title: ");
                string title = Console.ReadLine() ?? "";

                Console.Write("Description: ");
                string desc = Console.ReadLine() ?? "";

                if (type == "1")
                {
                    manager.AddGoal(new SimpleGoal(title, desc));
                    ConsoleHelpers.WriteSuccess("Simple Goal added.");
                }
                else if (type == "2")
                {
                    manager.AddGoal(new EternalGoal(title, desc));
                    ConsoleHelpers.WriteSuccess("Eternal Goal added.");
                }
                else if (type == "3")
                {
                    Console.Write("Target count: ");
                    string tRaw = Console.ReadLine();
                    if (!int.TryParse(tRaw, out int t) || t <= 0)
                    {
                        ConsoleHelpers.WriteWarning("Invalid target count. Must be a positive integer. Goal not created.");
                        continue;
                    }

                    Console.Write("Bonus points: ");
                    string bRaw = Console.ReadLine();
                    if (!int.TryParse(bRaw, out int b) || b < 0)
                    {
                        ConsoleHelpers.WriteWarning("Invalid bonus points. Must be a non-negative integer. Goal not created.");
                        continue;
                    }

                    manager.AddGoal(new ChecklistGoal(title, desc, t, b));
                    ConsoleHelpers.WriteSuccess("Checklist Goal added.");
                }
                else
                {
                    ConsoleHelpers.WriteWarning("Unknown goal type. Returning to main menu.");
                }
            }
            else if (choice == "2")
            {
                manager.ShowGoals();
            }
            else if (choice == "3")
            {
                manager.RecordEvent();
            }
            else if (choice == "4")
            {
                Console.Write("Filename to save: ");
                string file = Console.ReadLine()?.Trim() ?? "";
                try
                {
                    manager.Save(file);
                    ConsoleHelpers.WriteSuccess($"Saved to '{file}'.");
                }
                catch (Exception ex)
                {
                    ConsoleHelpers.WriteError($"Save failed: {ex.Message}");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Filename to load: ");
                string file = Console.ReadLine()?.Trim() ?? "";
                try
                {
                    manager.Load(file);
                    ConsoleHelpers.WriteSuccess($"Loaded from '{file}'.");
                }
                catch (Exception ex)
                {
                    ConsoleHelpers.WriteError($"Load failed: {ex.Message}");
                }
            }
            else if (choice == "6")
            {
                ConsoleHelpers.WriteInfo("Goodbye!");
                break;
            }
            else
            {
                ConsoleHelpers.WriteWarning("Invalid menu choice. Please enter a number 1–6.");
            }
        }
    }
}
