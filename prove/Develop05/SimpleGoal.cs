using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description)
        : base(title, description)
    {
    }

    public override bool MarkComplete()
    {
        if (_isComplete) return false;
        _isComplete = true;
        return true;
    }

    public override string GetSummary()
    {
        string check = _isComplete ? "[X]" : "[]";
        return $"{check} {_title}: {_description}";
    }

}