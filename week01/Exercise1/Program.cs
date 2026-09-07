using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1: Ask for the user's name
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        // Core Requirement 2: Ask for the user's birth year
        Console.Write("What year were you born? ");
        int birthYear = int.Parse(Console.ReadLine());

        // Core Requirement 3: Calculate the user's approximate age
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        // Core Requirement 4: Display a personalized message with the name and age
        Console.WriteLine($"Hello {name}, you are {age} years old.");
    }
}