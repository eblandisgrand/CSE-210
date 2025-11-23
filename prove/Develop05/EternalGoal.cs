using System;

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description)
        : base(title, description)
    {
    }

    public override bool MarkComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return 50;
    }

    public override string GetSummary()
    {
        return $"[∞] {_title}: {_description}";
    }

    public override string SaveString()
    {
        return $"{GetType().Name}|{_title}|{_description}";
    }
}
