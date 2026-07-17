using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Entry Couunt");
            Console.WriteLine("6. Qiut");

            Console.Write("Choose an option: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                string prompt = prompts.GetRandomPrompt();
                  Console.WriteLine();
                Console.WriteLine(prompt);

                Console.Write(">");
                string response = Console.ReadLine();

                Console.WriteLine("How are you doing today? ");
                string mood = Console.ReadLine();
                Entry entry = new Entry();
    

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);

                Console.WriteLine("Entry added.");
                break;

                case 2:

                journal.DisplayAll();
                break;

                case 3:

                Console.WriteLine("Enter fiename: ");
                string saveFile = Console.ReadLine();

                journal.SaveToFile(saveFile);
                break;

                case 4:

                Console.WriteLine("Enter filename: ");
                string loadFile = Console.ReadLine();

                journal.LoadFromFile(loadFile);
                break;

                case  5 :

                journal.DisplayCount();
                break;

                case 6:

                Console.WriteLine("Invalid option.");
                break;



            }
        }
    }

}