class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        // Creativity extension: entries also record the user's mood, and the menu shows the current entry count.
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("  1. Write a new entry");
            Console.WriteLine("  2. Display the journal");
            Console.WriteLine("  3. Save the journal");
            Console.WriteLine("  4. Load the journal");
            Console.WriteLine("  5. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    journal.Save();
                    break;
                case "4":
                    journal.Load();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}