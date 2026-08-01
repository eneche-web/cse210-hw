using System;
using System.Collections.Generic;
using System.IO;


public class ActivityLog
{
    private List<string> _logEntries;
    private string _fileName;

    public ActivityLog()
    {
        _logEntries = new List<string>();
        _fileName = "activitylog.txt";
    }

    public void LogActivity(string activityName, int duration)
    {
        string entry = $"{DateTime.Now:G} - {activityName} Activity completed for {duration} seconds.";

        _logEntries.Add(entry);

        File.AppendAllText(_fileName, entry + Environment.NewLine);
    }

    public void DisplayLog()
    {
        Console.Clear();

        Console.WriteLine("Activity Log");

        Console.WriteLine("-----------------");

        if (File.Exists(_fileName))
        {
            string[] enteries = File.ReadAllLines(_fileName);

            if (enteries.Length == 0)
            {
                Console.WriteLine("No activities have been logged yet.");
            }
            else
            {
                foreach (string entry in enteries)
                {
                    Console.WriteLine(entry);
                }
            }

        }
        else
        {
            Console.WriteLine("No log file found.");
        }
        Console.WriteLine();
        Console.WriteLine("press Enter to continue.....");
        Console.ReadLine();
    }
}