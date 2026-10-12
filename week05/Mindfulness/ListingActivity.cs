using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are things you are grateful for today?"
    };

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        Console.WriteLine($"Prompt: {_prompts[random.Next(_prompts.Count)]}");
        Console.WriteLine("Take a moment to think and then begin listing items.");

        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($"Enter item {itemCount + 1}: ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine("Keep going...");
            ShowCountdown(1);
        }

        Console.WriteLine($"You listed {itemCount} items.");
        DisplayEndingMessage();
    }
}
