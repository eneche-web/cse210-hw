using System;

public class SimpleGoal : Goal
{
    // Private member variable
    private bool _isComplete;

    // Constructor for creating a new goal
    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading a saved goal
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Record the complete of the goal
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }

        Console.WriteLine("This goal has already been complete.");
        return 0;
    }

    // Check if the goal is complete
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Save goal information to a file
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal | {GetName()} | {GetDescription()} | {GetPoints()} | {_isComplete}";
    }
}