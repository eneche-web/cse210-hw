using System;

public abstract class Goal
{
    // Private member variables
    private string _name;
    private string _description;
    private int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    //Geters
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }

    // Abstract methods
    public abstract int RecordEvent();
    public abstract bool IsComplete();

    // Virtual method
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[]";
        return $"{status} {_name} ({_description})";
    }

    // Save goal to file
    public abstract string GetStringRepresentation();

}