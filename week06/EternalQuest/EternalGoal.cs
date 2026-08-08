using System;

public class EternalGoal : Goal
{
    // Consructor for creating a new Eternal Goal
    public EternalGoal(string name, string description, int points)
    : base(name, description, points)
    {
        
    }

    // Reccord the event and always award points
    public override int RecordEvent()
    {
        return GetPoints();
    }

    // Eternal goals are never complete
    public override bool IsComplete()
    {
        return  false;
    }

    // Save goal information to a file
    public override string GetStringRepresentation()
    {
        return $"EternalGoal | {GetName()} | {GetDescription()} | {GetPoints()}";
    }
}