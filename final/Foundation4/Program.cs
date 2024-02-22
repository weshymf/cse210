using System;
using System.Collections.Generic;

public class Activity
{
    protected DateTime date;
    protected int lengthInMinutes;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    // Virtual method to calculate distance
    public virtual double CalculateDistance()
    {
        return 0;
    }

    // Virtual method to calculate speed
    public virtual double CalculateSpeed()
    {
        return 0;
    }

    // Virtual method to calculate pace
    public virtual double CalculatePace()
    {
        return 0;
    }

    // Method to generate summary
    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({lengthInMinutes} min)";
    }
}

public class Running : Activity
{
    private double distance;

    // Constructor
    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    // Override method to calculate distance
    public override double CalculateDistance()
    {
        return distance;
    }

    // Override method to calculate speed
    public override double CalculateSpeed()
    {
        return distance / (lengthInMinutes / 60.0);
    }

    // Override method to calculate pace
    public override double CalculatePace()
    {
        return lengthInMinutes / distance;
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {distance} miles, Speed: {CalculateSpeed()} mph, Pace: {CalculatePace()} min/mile";
    }
}

public class StationaryBicycle : Activity
{
    private double speed;

    // Constructor
    public StationaryBicycle(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    // Override method to calculate speed
    public override double CalculateSpeed()
    {
        return speed;
    }

    // Override method to calculate pace
    public override double CalculatePace()
    {
        return 60 / speed;
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {speed} mph, Pace: {CalculatePace()} min/mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    // Constructor
    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    // Override method to calculate distance
    public override double CalculateDistance()
    {
        return laps * 50 / 1000.0; // 50 meters per lap
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {CalculateDistance()} kilometers";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Activity runningActivity = new Running(DateTime.Now, 30, 3.0);
        Activity bicycleActivity = new StationaryBicycle(DateTime.Now, 45, 20.0);
        Activity swimmingActivity = new Swimming(DateTime.Now, 60, 20);

        // List of activities
        List<Activity> activities = new List<Activity>
        {
            runningActivity,
            bicycleActivity,
            swimmingActivity
        };

        // Display activity summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
