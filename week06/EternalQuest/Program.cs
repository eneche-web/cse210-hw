using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // This program exceeds the assignment requirements by adding
        // a Level System. As users earn points, they advance through
        // different levels:
        // Beginner -> Explorer -> Disciple -> Champion -> Eternal Hero.
        // Whenever a new level is reached, the program displays a
        // congratulatory message to encourage continued progress.

        Console.Title = "Eternal Quest Program";

        GoalManager goalManager = new GoalManager();
        goalManager.Start();

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Eternal Quest Program!");
    }
}