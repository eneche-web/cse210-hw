using System;
using System.Collections.Generic;


public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _randoom;


    public ListingActivity()
    : base(
        "Listiing",
        "This activity will help you reflect on the good things in your life by having youo list as many things as you can in a certain area."
    )
    {
        _randoom = new Random();
        _prompts = new List<string>
        {
            "Who are people that you appreciat?",
            "What are your personal strengths?",
            "Who have you helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heros?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"------{GetRandomPrompt()}------");
        Console.WriteLine();

        Console.WriteLine("You may begin in: ")
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing items (press Enter after each one) :");

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write(">");
            string item = Console.ReadLine();

            if (! string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        ActivityLog  log = new ActivityLog();
        log.LogActivity("Listing", GetDuration());

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _randoom.Next(_prompts.Count);
        return _prompts[index];
    }
}