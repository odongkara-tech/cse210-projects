using System;

class Program
{
    static void Main(string[] args)
    {
        // Stretch Challenge 2: Play again loop
        string playAgain = "yes";
        
        while (playAgain.ToLower() == "yes")
        {
            PlayGame();
            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }

    static void PlayGame()
    {
        // Core Requirement 3: Generate random number from 1 to 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        
        int guess = 0;
        int guessCount = 0; // Stretch Challenge 1: Track guesses

        Console.WriteLine("\nI'm thinking of a number between 1 and 100. Can you guess it?");

        // Core Requirement 2: Loop until guess matches magic number
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            
            guessCount++; // Increment guess count

            // Core Requirement 1: Determine if higher, lower, or correct
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher! Try again.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower! Try again.");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
        }

        // Stretch Challenge 1: Display number of guesses
        Console.WriteLine($"It took you {guessCount} guess(es) to find the magic number!");
    }
}