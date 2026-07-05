using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "Yes";

        while
        (playAgain. ToLower() == "yes")
        {
            Random
            randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int guessCount = ;

            Console.WriteLine("\nI have guess a magic number between 1 and 100");
            while(guess != magicNumber)
            {
                Console.Write("what is your guess? ");

                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You got the guess!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }

            }

            Console.WriteLine("\nDo you want to play again? (yes/no):");
            playAgain = Console.ReadLine();


        }

        Console.WriteLine("\nThanks for playing!");

        
    }
}