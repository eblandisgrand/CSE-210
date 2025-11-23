using System;

public class Goal
{
    protected string _title;
    protected string _description;
    protected bool _isComplete;

public Goal(string title, string description)
{
    _title = title ?? "";
    _description = description ?? "";
    _isComplete = false;
}

public string GetTitle()
    {
        return _title;
    }
public string GetDescription()
    {
        return _description;
    }
public bool IsComplete()
    {
        return _isComplete;
    }
public virtual bool MarkComplete()
    {
        if (_isComplete) return false;
        _isComplete = true;
        return true;
    }

public virtual string GetSummary()
    {
        string status = _isComplete ? "[X]" : "[]";
        return $"{status} {_title}: {_description}";
    }

public virtual string GetDisplayText() => GetSummary();

public virtual int RecordEvent()
    {
        if(MarkComplete()) return 0;
        return 0;
    }

    public virtual string SaveString()
    {
        return $"{GetType().Name}|{_title}|{_description}|{_isComplete}";
    }

}

