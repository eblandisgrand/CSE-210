using System;
using System.Collections.Generic;
using System.IO;

public class JournalEntry
{
   public string Date { get; set; }
   public string Prompt { get; set; }
   public string Response { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} - {Prompt} \n {Response} \n";
    }
}

