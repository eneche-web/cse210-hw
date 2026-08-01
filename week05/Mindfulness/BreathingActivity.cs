using System;


public class BreathingActivity: Activity
{
    public BreathingActivity()
    :base("Breathing", "This activity will help you relax by walking you through breathing in and put slowly.So clear your mind and focus on your breathing.")
    {
        
    }
    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Begin your breathing exercise....");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breath in.........");
            ShowCountdown(4);
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine("Breath out.......");
            ShowCountdown(4);
        }

        ActivityLog log = new ActivityLog();
        log.LogActivity("Breathing", GetDuration());

        DisplayEndingMessage();

    }
}