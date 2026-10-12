using System;
using System.Diagnostics;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration() => _duration;

    public virtual void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = ReadDuration();

        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowCountdown(3);
    }

    protected virtual void PerformActivity()
    {
    }

    protected int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like this activity to last? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a positive number of seconds.");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinnerFrames = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds; i++)
        {
            foreach (string frame in spinnerFrames)
            {
                Console.Write($"\r{frame} processing...");
                Thread.Sleep(250);
            }
        }

        Console.WriteLine();
    }

    protected void WaitForSeconds(int seconds)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed < TimeSpan.FromSeconds(seconds))
        {
            Console.Write($"\r{(seconds - stopwatch.Elapsed.Seconds)}");
            Thread.Sleep(250);
        }

        Console.WriteLine();
    }
}
