using System;

public class LevelSystem
{
    // Keeps track of the player's current level
    private string _currentLevel;

    // Constructor
    public LevelSystem()
    {
        _currentLevel = "Beginner";
    }

    // Returns the appropriate level based on the score
    public string GetLevel(int score)
    {
        if (score >= 10000)
            return "Eternal Hero";
        else if (score >= 6000)
            return "Champion";
        else if (score >= 3000)
            return "Disciple";
        else if (score >= 1000)
            return "Explorer";
        else
            return "Beginner";
    }

    // Checks whether the player has reached a new level
    public void CheckLevelUp(int score)
    {
        string newLevel = GetLevel(score);

        if (newLevel != _currentLevel)
        {
            _currentLevel = newLevel;

            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("🎉 CONGRATULATIONS! 🎉");
            Console.WriteLine($"You have reached the '{_currentLevel}' level!");
            Console.WriteLine("Keep working toward your goals!");
            Console.WriteLine("*************************************");
            Console.WriteLine();
        }
    }
}