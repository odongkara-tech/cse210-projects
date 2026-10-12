using System;

// Creativity beyond the core requirements: this version adds a menu-driven flow, a reusable activity base class,
// animated countdown/spinner pauses, and varied reflection/listing prompts to create a more engaging mindfulness app.
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Thanks for taking a mindful moment.");
                    return;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }
}