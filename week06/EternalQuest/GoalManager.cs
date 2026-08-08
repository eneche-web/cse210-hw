using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    // Member variables
    private List<Goal> _goals;
    private int _score;
    private LevelSystem _levelSystem;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _levelSystem = new LevelSystem();
    }

    // Display the player's score and level
    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Current Level: {_levelSystem.GetLevel(_score)}");
        Console.WriteLine();
    }

    // Display all goals
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Create a new goal
    public void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");

        int choice = int.Parse(Console.ReadLine());

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case 3:
                Console.Write("How many times must this goal be completed? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points when completed: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    // Record an event
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        Console.WriteLine("\nSelect a goal:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[choice - 1].RecordEvent();

        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
        Console.WriteLine($"Current Score: {_score}");

        _levelSystem.CheckLevelUp(_score);
    }

    // Save goal to a file
    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            // Save the current score
            output.WriteLine(_score);

            // Save each goal
            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    // Load goals from a file
    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found");
            return;
        }

        _goals.Clear();

        string[] lines = 
        File.ReadAllLines(fileName);

        // First line is the score
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[1].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    )
                );
            }
            else if ( type == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[5]),
                        int.Parse(parts[4]),
                        int.Parse(parts[6])
                    )
                );
            }
        }

        Console.WriteLine("Goals loaded successully!");
    }

    // Mian menu loop
    public void start()
    {
        int choice = 0;

        while (choice !=6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice");

            if (! int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a alid number.");
                continue;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                CreateGoal();
                break;

                case 2:
                ListGoalDetails();
                break;

                case 3:
                SaveGoals();
                break;

                case 4:
                LoadGoals();
                break;

                case 5:
                RecordEvent();
                break;

                case 6:

                Console.WriteLine("Thank you for using Eternal Quest!");
                break;

                default:

                Console.WriteLine("Invalid option.");
                break;
            }

            Console.WriteLine();

        }
    }




}