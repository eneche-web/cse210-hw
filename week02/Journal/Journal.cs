using System;
using System.Collections.Generic;
using System.IO;

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