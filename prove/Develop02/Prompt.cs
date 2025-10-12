using System;
using System.Collections.Generic;
public class Prompt
{
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "What was the best part of your day?",
        "What did you learn today?",
        "What are you grateful for?",
        "How did you show kindness today?"
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }

}