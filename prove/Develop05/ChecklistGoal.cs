using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string title, string description, int target, int bonus)
        : base(title, description)
    {
        _targetCount = target;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
            return 0;

        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            return 100 + _bonus;
        }

        return 100;
    }

    public override string GetSummary()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_title} ({_currentCount}/{_targetCount})";
    }

    public override string SaveString()
    {
        return $"{GetType().Name}|{_title}|{_description}|{_isComplete}|{_currentCount}|{_targetCount}|{_bonus}";
    }
}
