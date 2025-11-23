using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ShowGoals()
    {
        if (_goals.Count == 0)
        {
            ConsoleHelpers.WriteInfo("No goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetDisplayText()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            ConsoleHelpers.WriteWarning("No goals to record. Create a goal first.");
            return;
        }

        ShowGoals();
        Console.Write("\nWhich goal was accomplished? (enter number) ");
        string input = Console.ReadLine()?.Trim();

        if (!int.TryParse(input, out int choice))
        {
            ConsoleHelpers.WriteWarning("Invalid input. Please enter a number corresponding to a goal.");
            return;
        }

        if (choice < 1 || choice > _goals.Count)
        {
            ConsoleHelpers.WriteWarning("Choice out of range. Please enter a valid goal number.");
            return;
        }

        Goal g = _goals[choice - 1];
        try
        {
            int earned = g.RecordEvent();
            _score += earned;
            ConsoleHelpers.WriteSuccess($"You earned {earned} points!");
            ConsoleHelpers.WriteInfo($"Total Score: {_score}");
        }
        catch (Exception ex)
        {
            // If a goal implementation throws, catch and show an error
            ConsoleHelpers.WriteError($"An error occurred recording the event: {ex.Message}");
        }
    }

    public void Save(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new ArgumentException("Filename cannot be empty.");

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(_score);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.SaveString());
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            throw new Exception("Access denied when saving file. Check permissions.");
        }
        catch (DirectoryNotFoundException)
        {
            throw new Exception("Directory not found. Provide a valid path.");
        }
        catch (IOException ioex)
        {
            throw new Exception("I/O error while saving file: " + ioex.Message);
        }
    }

    public void Load(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new ArgumentException("Filename cannot be empty.");

        if (!File.Exists(filename))
            throw new FileNotFoundException($"File '{filename}' not found.");

        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to read file: " + ex.Message);
        }

        if (lines.Length == 0)
            throw new Exception("File is empty.");

        _goals.Clear();

        if (!int.TryParse(lines[0], out _score))
            throw new Exception("First line should be an integer score.");

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("|");
            if (parts.Length < 3)
            {
                ConsoleHelpers.WriteWarning($"Skipping malformed line {i + 1}: {line}");
                continue;
            }

            string type = parts[0];

            try
            {
                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2]));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2]));
                }
                else if (type == "ChecklistGoal")
                {
                    // expected format: ChecklistGoal|title|description|isComplete|currentCount|targetCount|bonus
                    if (parts.Length < 7)
                    {
                        ConsoleHelpers.WriteWarning($"Checklist line malformed (expected 7 parts): {line}");
                        continue;
                    }

                    bool complete = bool.TryParse(parts[3], out bool c) ? c : false;
                    int count = int.TryParse(parts[4], out int cc) ? cc : 0;
                    int target = int.TryParse(parts[5], out int tt) ? tt : 0;
                    int bonus = int.TryParse(parts[6], out int bb) ? bb : 0;

                    ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], target, bonus);

                    // set private fields via reflection (existing approach)
                    cg.GetType().GetField("_currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(cg, count);
                    cg.GetType().GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(cg, complete);

                    _goals.Add(cg);
                }
                else
                {
                    ConsoleHelpers.WriteWarning($"Unknown goal type '{type}' on line {i + 1}. Skipping.");
                }
            }
            catch (Exception ex)
            {
                ConsoleHelpers.WriteWarning($"Failed to load line {i + 1}: {ex.Message}. Skipping.");
            }
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"You have {_score} points.");
    }
}
