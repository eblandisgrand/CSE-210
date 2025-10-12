using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private const string _defaultFile = "journal.txt"; //auto save to this file
    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
        SaveToFile("journal.txt"); //auto save entry
    }

    public void DisplayEntries()
    {
        foreach (JournalEntry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine($"Auto-Saved to {Path.GetFullPath(filename)}");
    }
    public void LoadFromFile(string filename = _defaultFile)
    {
        if (!File.Exists(filename)) // auto create a default file
        {
            Console.WriteLine("No previous journal found — starting a new one.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if (parts.Length == 3)
            {
                JournalEntry entry = new JournalEntry(parts[1], parts[2]);
                entry.Date = parts[0];
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from {filename}"); //display entries to user
    }
}