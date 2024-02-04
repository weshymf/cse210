using System;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Start();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Start();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

class Activity
{
    protected int duration;

    public Activity()
    {
        duration = 0;
    }

    public void SetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    public void ShowStartingMessage(string description)
    {
        Console.WriteLine($"{description} activity starting...");
        Thread.Sleep(2000);
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000);
    }

    public void ShowEndingMessage(string activityName)
    {
        Console.WriteLine("Good job!");
        Thread.Sleep(2000);
        Console.WriteLine($"You have completed the {activityName} activity for {duration} seconds.");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : Activity
{
    public void Start()
    {
        SetDuration();
        ShowStartingMessage("Breathing");
        
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(2000);
        }

        ShowEndingMessage("Breathing");
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void Start()
    {
        SetDuration();
        ShowStartingMessage("Reflection");

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000);

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000);
            }
        }

        ShowEndingMessage("Reflection");
    }
}

class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void Start()
    {
        SetDuration();
        ShowStartingMessage("Listing");

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(2000);
        Console.WriteLine("Get ready to list...");

        for (int i = 1; i <= duration; i++)
        {
            Console.WriteLine($"Item {i}: ");
            Thread.Sleep(1000);
        }

        Console.WriteLine($"You listed {duration} items.");
        ShowEndingMessage("Listing");
    }
}
