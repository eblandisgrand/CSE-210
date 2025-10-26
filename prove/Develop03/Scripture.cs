using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // Split the text into Word objects
        string[] splitWords = text.Split(' ');
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine();

        foreach (Word w in _words)
        {
            Console.Write(w.GetDisplayText() + " ");
        }

        Console.WriteLine("\n\n(Press Enter to continue or type 'quit' to stop)");
    }

    public void HideRandomWords(int count)
    {
        int hidden = 0;
        while (hidden < count)
        {
            int index = _rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }

            if (IsCompletelyHidden())
                break;
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }

    
    public string GetReferenceText()
    {
        return _reference.GetReference();
    }


}
