using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;
    private static string _saveFile = Path.Combine(Environment.CurrentDirectory, "eternalquest-goals.txt");

    // Creativity beyond the basic requirements: this version adds a level badge, persistent save/load,
    // and a guided goal-creation flow so the quest feels more like a real game while keeping the core goal types.
    static void Main(string[] args)
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest Menu");
            Console.WriteLine($"Current Score: {_score} | Level: {GetLevelBadge()}");
            Console.WriteLine("1. Create a goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. View goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("Farewell, adventurer!");
                    return;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static string GetLevelBadge()
    {
        int level = (_score / 250) + 1;
        return $"{level}";
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type: ");

        string typeChoice = Console.ReadLine();
        string name = ReadRequiredText("Goal name: ");
        string description = ReadRequiredText("Description: ");

        switch (typeChoice)
        {
            case "1":
                int simplePoints = ReadPositiveInt("Points for completion: ");
                _goals.Add(new SimpleGoal(name, description, simplePoints));
                Console.WriteLine($"Simple goal '{name}' created.");
                break;
            case "2":
                int eternalPoints = ReadPositiveInt("Points per event: ");
                _goals.Add(new EternalGoal(name, description, eternalPoints));
                Console.WriteLine($"Eternal goal '{name}' created.");
                break;
            case "3":
                int checklistPoints = ReadPositiveInt("Points per completion: ");
                int targetCount = ReadPositiveInt("How many times to complete: ");
                int bonusPoints = ReadPositiveInt("Bonus points for finishing: ");
                _goals.Add(new ChecklistGoal(name, description, checklistPoints, targetCount, bonusPoints));
                Console.WriteLine($"Checklist goal '{name}' created.");
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals yet.");
            return;
        }

        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }

        int index = ReadIntInRange("Goal number: ", 1, _goals.Count) - 1;
        Goal selectedGoal = _goals[index];
        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine($"You earned {earnedPoints} points for '{selectedGoal.GetName()}'.");
        Console.WriteLine($"Total score: {_score}");
    }

    static void ViewGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Your Goals:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(_saveFile))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine($"Goals saved to {_saveFile}");
    }

    static void LoadGoals()
    {
        if (!File.Exists(_saveFile))
        {
            Console.WriteLine("No saved quest found yet.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(_saveFile);

            if (lines.Length == 0)
            {
                return;
            }

            _score = int.Parse(lines[0]);
            _goals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                Goal loadedGoal = Goal.CreateFromSaveString(lines[i]);
                _goals.Add(loadedGoal);
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load saved goals: {ex.Message}");
        }
    }

    static string ReadRequiredText(string prompt)
    {
        string input;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    static int ReadPositiveInt(string prompt)
    {
        int value;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a positive number.");
        }
    }

    static int ReadIntInRange(string prompt, int min, int max)
    {
        int value;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }
}
