using System;

public class CheckListGoal : Goal
{
    // Private member variable
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor for creating a new checklist goal
    public CheckListGoal(string name, string description, int points, int target, int bonus)
    : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Constructor for loading a saved checlist goal
    public CheckListGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
    :base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Record an event
    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;

            if (_amountCompleted == _target)
            {
                Console.WriteLine("Congratulations! You completed this checlist goal!");

                Console.WriteLine($"Bonus earned: {_bonus} points!");
                return GetPoints() + _bonus;
            }
            return GetPoints();
        }
        
        Console.WriteLine("This checklist goal has already been completed.");
        return 0;
    }

    // Determine if tyhe goal is complete
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Display goal details with progress
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[]";

        return $"{status} {GetName()} {_amountCompleted}/{_target} times";
    }

    // Save goal information
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal | {GetName()} | {GetDescription()} | {GetPoints()} | {_bonus} | {_target} | {_amountCompleted}";
    }
}