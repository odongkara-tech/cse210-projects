using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        bool inhale = true;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(inhale ? "Breathe in..." : "Breathe out...");
            int remaining = Math.Min(3, (int)(endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0)
            {
                break;
            }

            ShowCountdown(remaining);
            inhale = !inhale;
        }

        DisplayEndingMessage();
    }
}
