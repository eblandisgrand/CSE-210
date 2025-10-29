using System;

public class MathAssignment : Assignment
{
    protected string _textbookSelection = "";
    protected string _problems = "";

    public MathAssignment(string studentName, string topic, string textbookSelection, string problems)
        : base(studentName, topic)
    {
        _textbookSelection = textbookSelection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"\n{_textbookSelection} : {_problems} ";
    }
}