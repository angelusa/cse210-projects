using System;
using System.Collections.Generic;
using System.IO;


namespace Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store entries
            List<Entry> entries = new List<Entry>();

            // Display the menu
            Console.WriteLine("Welcome to your Journal");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Exit");
            Console.Write("Please enter a number (1-5): ");
            int choice = Int32.Parse(Console.ReadLine());

            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        // Write a new entry
                        Entry newEntry = new Entry();
                        newEntry.WriteNewEntry();
                        entries.Add(newEntry);
                        break;
                    case 2:
                        // Display the journal
                        foreach (Entry entry in entries)
                        {
                            entry.DisplayEntry();
                        }
                        break;
                    case 3:
                        // Load the journal from a file
                        Console.Write("Please enter the file name: ");
                        string fileName = Console.ReadLine();
                        entries = Entry.LoadFromFile(fileName);
                        break;
                    case 4:
                        // Save the journal to a file
                        Console.Write("Please enter the file name: ");
                        string fileName2 = Console.ReadLine();
                        Entry.SaveToFile(entries, fileName2);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.Write("Please enter a number (1-5): ");
                choice = Int32.Parse(Console.ReadLine());
            }
        }
    }

    class Entry
    {
        string prompt;
        string response;
        DateTime date;

        public Entry()
        {
            // Choose a random prompt from the list
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
            Random random = new Random();
            int index = random.Next(prompts.Length);
            prompt = prompts[index];

            // Save the current date
            date = DateTime.Now;
        }

        public void WriteNewEntry()
        {
            Console.WriteLine(prompt);
            response = Console.ReadLine();
        }

        public void DisplayEntry()
        {
            Console.WriteLine("Date: {0}", date.ToShortDateString());
            Console.WriteLine("Prompt: {0}", prompt);
            Console.WriteLine("Response: {0}", response);
            Console.WriteLine();
        }

        public static List<Entry> LoadFromFile(string fileName)
        {
            List<Entry> entries = new List<Entry>();

            StreamReader reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = "ABCDD";
                Entry entry = new Entry();
                try
                {
                    entry.date = Convert.ToDateTime(line);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                entry.prompt = reader.ReadLine();
                entry.response = reader.ReadLine();
                entries.Add(entry);
            }
            reader.Close();

            return entries;
        }

        public static void SaveToFile(List<Entry> entries, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.date);
                writer.WriteLine(entry.prompt);
                writer.WriteLine(entry.response);
            }
            writer.Close();
        }
    }
}
