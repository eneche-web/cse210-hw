using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private LevelSystem _levelSystem;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _levelSystem = new LevelSystem();
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("       ETERNAL QUEST PROGRAM");
            Console.WriteLine("=================================");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {_levelSystem.GetLevel(_score)}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number from 1 to 6.");
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
                    Console.WriteLine("Invalid choice. Please select 1-6.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Goal description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");

        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        if (choice == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == 3)
        {
            Console.Write("Target number of completions: ");

            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Invalid target.");
                return;
            }

            Console.Write("Bonus points: ");

            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                )
            );
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals.");
            return;
        }

        Console.WriteLine("Your Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record.");
            return;
        }

        Console.WriteLine("Select a goal to record:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Choice: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = _goals[choice - 1].RecordEvent();

        if (pointsEarned > 0)
        {
            _score += pointsEarned;

            Console.WriteLine($"You earned {pointsEarned} points!");
            Console.WriteLine($"Your total score is now {_score}.");

            _levelSystem.CheckLevelUp(_score);
        }
        else
        {
            Console.WriteLine("No points were earned.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter output = new StreamWriter(fileName))
            {
                output.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    output.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save the file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            _goals.Clear();

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                if (parts.Length == 0)
                {
                    continue;
                }

                if (parts[0] == "SimpleGoal" && parts.Length >= 5)
                {
                    _goals.Add(
                        new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            bool.Parse(parts[4])
                        )
                    );
                }
                else if (parts[0] == "EternalGoal" && parts.Length >= 4)
                {
                    _goals.Add(
                        new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])
                        )
                    );
                }
                else if (parts[0] == "ChecklistGoal" && parts.Length >= 7)
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

            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Goals loaded: {_goals.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load the file: {ex.Message}");
        }
    }
}