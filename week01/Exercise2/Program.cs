using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1 & 2: Ask for grade and determine letter grade
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter = "";
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Add +/- grades based on last digit
        string sign = "";
        int lastDigit = gradePercentage % 10;

        if (letter == "A")
        {
            // No A+ grade, only A and A-
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "F")
        {
            // No F+ or F- grades, only F
            sign = "";
        }
        else
        {
            // For B, C, D: add + if last digit >= 7, - if last digit < 3
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Core Requirement 3: Print the letter grade with sign once
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Core Requirement 2: Check if passed (>= 70) and display message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time!");
        }
    }
} 