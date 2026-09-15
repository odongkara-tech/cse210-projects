using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private const string Separator = "~|~";
    private readonly List<Entry> _entries = new List<Entry>();
    private readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What is one goal I want to focus on tomorrow?"
    };
    private readonly Random _random = new Random();

    public void WriteEntry()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine() ?? "";
        Console.Write("How would you describe your mood? ");
        string mood = Console.ReadLine() ?? "";

        _entries.Add(new Entry(DateTime.Now.ToShortDateString(), prompt, response, mood));
        Console.WriteLine("Entry added.");
    }

    public void Display()
    {
        Console.WriteLine($"\nJournal entries: {_entries.Count}");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine("\n" + entry);
        }
    }

    public void Save()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        try
        {
            using StreamWriter outputFile = new StreamWriter(filename);
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{Escape(entry.Date)}{Separator}{Escape(entry.Prompt)}{Separator}{Escape(entry.Response)}{Separator}{Escape(entry.Mood)}");
            }

            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not save the journal: {exception.Message}");
        }
    }

    public void Load()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Entry> loadedEntries = new List<Entry>();
            foreach (string line in lines)
            {
                List<string> parts = SplitRecord(line);
                if (parts.Count >= 3)
                {
                    string mood = parts.Count >= 4 ? parts[3] : "Not recorded";
                    loadedEntries.Add(new Entry(parts[0], parts[1], parts[2], mood));
                }
            }

            _entries.Clear();
            _entries.AddRange(loadedEntries);
            Console.WriteLine($"Loaded {_entries.Count} entries from {filename}.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not load the journal: {exception.Message}");
        }
    }

    private static string Escape(string value)
    {
        return value.Replace("\\", "\\\\").Replace(Separator, "\\" + Separator);
    }

    private static List<string> SplitRecord(string line)
    {
        List<string> parts = new List<string>();
        string current = "";

        for (int index = 0; index < line.Length; index++)
        {
            if (line[index] == '\\' && index + 1 < line.Length)
            {
                current += line[index];
                current += line[index + 1];
                index++;
            }
            else if (line.AsSpan(index).StartsWith(Separator))
            {
                parts.Add(Unescape(current));
                current = "";
                index += Separator.Length - 1;
            }
            else
            {
                current += line[index];
            }
        }

        parts.Add(Unescape(current));
        return parts;
    }

    private static string Unescape(string value)
    {
        string result = "";

        for (int index = 0; index < value.Length; index++)
        {
            if (value[index] == '\\' && index + 1 < value.Length)
            {
                if (value.AsSpan(index + 1).StartsWith(Separator))
                {
                    result += Separator;
                    index += Separator.Length;
                }
                else if (value[index + 1] == '\\')
                {
                    result += '\\';
                    index++;
                }
                else
                {
                    result += value[index];
                }
            }
            else
            {
                result += value[index];
            }
        }

        return result;
    }
}