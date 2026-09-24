using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds the core requirements: this program stores several passages and chooses
        // one at random each time it starts, instead of memorizing only one fixed passage.
        // It also uses the stretch challenge: each turn hides only words that are still visible.
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."),
            new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd I shall not want.")
        };

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to hide more words or type 'quit' to finish: ");
            string response = Console.ReadLine();

            if (response != null && response.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}
