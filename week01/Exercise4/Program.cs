using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        // Input phase: Ask for numbers until 0 is entered
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int input = -1;
        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            
            // Don't add 0 to the list
            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        // Core Requirement 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute the average
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Find the smallest positive number
        List<int> positiveNumbers = new List<int>();
        foreach (int number in numbers)
        {
            if (number > 0)
            {
                positiveNumbers.Add(number);
            }
        }

        if (positiveNumbers.Count > 0)
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge 2: Sort and display the list
        List<int> sortedNumbers = new List<int>(numbers);
        sortedNumbers.Sort();
        
        Console.WriteLine("The sorted list is:");
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}