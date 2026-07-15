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

                Console.WriteLine("How are you doin today? ");
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

    public class Entry
    {
        public string _date;
        public string _promptText;
        public string _entryText;
        public string _mood;

        public void Display()
        {
            Console.WriteLine($"Date:{_date}");
            Console.WriteLine($"Prompt:{_promptText}");
            Console.WriteLine($"Response:{_entryText}");
            Console.WriteLine($"Mood:{_mood}");
            Console.WriteLine();
        }
    }

   

    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No journal entries found.");
                return;
            }

            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter output = new StreamWriter("fileName"))
            {
                foreach (Entry entry in _entries)
                {
                    output.WriteLine(
                          entry._date,
                          entry._promptText, 
                          entry._entryText, 
                          entry._mood);
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }

        public void LoadFromFile(string fileName)
        {
            if (! File.Exists(fileName))
            {
                Console.WriteLine("file not found.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._mood = parts[3];
                _entries.Add(entry);
            }

            Console.WriteLine("Journal loaded successfully.");
        }

        public void DisplayCount()
        {
            Console.WriteLine($"Total Entries: {_entries.Count}");
        }

            
        




    }
     public class PromptGenerator
    {
        private List<string> _prompts = new List<string>()
        {
            "What is the best thing that happened to me today?",
            "What did God do as a miracle today in my life?",
            "Who was the most interesting person i interacted with today?",
            "What is the strongest emotion i felt today?",
            "What life lession did i learn today?",
            "What did i do to manage my time today?",
            "What help did i ask the holy spirit for today?",
            "What made me smile today?",
            "What did i do to help someone today?",

        };

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);

            return _prompts[index];
        }
    }


}