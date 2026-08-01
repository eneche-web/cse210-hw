using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public GratitudeActivity()
    : base (
        "Gratitude",
        "This activity will help you focus on the blessings in your life by thinking about and listing things you are grateful for."
    )
    {
       _random = new Random();
       _prompts = new List<string>
       {
           "What  are three things you are grateful for.?",
           "Who has made a positive difference in your life recently.?",
           "What talents or abilitis are you thankful for?",
           "What simple blessing have you enjoyed today?",
           "What experience has made you smile this week?"
       };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();


        Console.WriteLine("Gratitude Prompt:");
        Console.WriteLine();
        Console.WriteLine($"-------{GetRandomPrompt()}-----");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine("Enter as many things as you are grateful for as you can.");

        List<string> gratitudeItems = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(">");
            string response = Console.ReadLine();

            if (! string.IsNullOrWhiteSpace(response))
            {
                gratitudeItems.Add(response);
            }
        }

        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine($"Wonderful! You listed {gratitudeItems.Count} things you are grateful for.");
        Console.WriteLine();

        ActivityLog log = new ActivityLog();
        log.LogActivity("Gratitude", GetDuration());

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}