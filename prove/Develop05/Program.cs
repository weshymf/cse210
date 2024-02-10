using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public abstract int RecordEvent();
    public abstract string GetProgress();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"You completed the {Name} goal!");
        return Value;
    }

    public override string GetProgress()
    {
        return "[X]";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"You recorded progress on the {Name} goal!");
        return Value;
    }

    public override string GetProgress()
    {
        return "[ ]";
    }
}

public class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int targetTimes;

    public ChecklistGoal(string name, int value, int targetTimes) : base(name, value)
    {
        timesCompleted = 0;
        this.targetTimes = targetTimes;
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You completed an event for the {Name} goal!");
        timesCompleted++;
        if (timesCompleted == targetTimes)
        {
            Console.WriteLine($"Congratulations! You completed the {Name} goal {targetTimes} times and earned a bonus of {Value} points!");
            return Value * targetTimes;
        }
        else
        {
            return Value;
        }
    }

    public override string GetProgress()
    {
        return $"Completed {timesCompleted}/{targetTimes} times";
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        int totalScore = 0;

        Console.WriteLine("Welcome to Eternal Quest!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Record Event");
            Console.WriteLine("2. Show Goals and Progress");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect a Goal to Record Event:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Name}");
                    }
                    Console.Write("Enter the goal number: ");
                    int goalNumber = int.Parse(Console.ReadLine()) - 1;

                    totalScore += goals[goalNumber].RecordEvent();
                    break;
                case 2:
                    Console.WriteLine("\nGoals and Progress:");
                    foreach (var goal in goals)
                    {
                        Console.WriteLine($"{goal.Name}: {goal.GetProgress()}");
                    }
                    Console.WriteLine($"\nTotal Score: {totalScore}");
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}