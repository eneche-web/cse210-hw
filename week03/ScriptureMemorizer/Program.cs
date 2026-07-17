using System;
using System.Collections.Generic;

//Program can randomly choose scriptures.
//Only words that are not hidden are selected.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                new Reference("John",3,16),"For God so love the world that he gave his only begotten Son that who so ever believeth in him should not perish but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs",3,5,6),"Trust in the lord with all your heart and lean not unto thine own understanding in all your ways acknowledge him and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Mosiah",2,17),"When ye are in the service of your fellow beings ye are only in the service of your God."
            )
        };
        Random random = new Random();
        Scripture scripture = scripture[random.Next(scripture.count)];

        while(!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("Press Enter to continue or type quit: ");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HidenRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(
            scripture.GetDisplayText()
            );
        Console.WriteLine();
        Console.WriteLine("Program ended.");

        
        
    }
}