using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file successfully!");
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear(); // Clear existing entries before loading new ones
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        AddEntry(parts[1], parts[2], parts[0]);
                    }
                }
            }
            Console.WriteLine("Journal loaded from file successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. No entries loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    journal.AddEntry(randomPrompt, response, date);
                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter the file name to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case "4":
                    Console.Write("Enter the file name to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "5":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose again.\n");
                    break;
            }
        }
    }
}
