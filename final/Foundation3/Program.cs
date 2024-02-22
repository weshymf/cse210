using System;

public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to get full address
    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}

public class Event
{
    protected string title;
    protected string description;
    protected DateTime date;
    protected TimeSpan time;
    protected Address address;

    // Constructor
    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Method to generate standard event details string
    public virtual string GenerateStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}\n";
    }

    // Method to generate full event details string
    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    // Method to generate short event description string
    public virtual string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date.ToShortDateString()}\n";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    // Constructor
    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // Override method to generate full event details string
    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}\n";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    // Constructor
    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Override method to generate full event details string
    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"Type: Reception\nRSVP Email: {rsvpEmail}\n";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    // Constructor
    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Override method to generate full event details string
    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}\n";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address
        Address address = new Address("456 Oak St", "Anytown", "NY", "USA");

        // Create events
        Event lectureEvent = new Lecture("Lecture on AI", "Introduction to Artificial Intelligence", DateTime.Now, TimeSpan.FromHours(2), address, "Dr. Smith", 100);
        Event receptionEvent = new Reception("Networking Reception", "Meet and greet with industry professionals", DateTime.Now.AddDays(1), TimeSpan.FromHours(3), address, "rsvp@example.com");
        Event outdoorEvent = new OutdoorGathering("Picnic in the Park", "Community gathering at the local park", DateTime.Now.AddDays(2), TimeSpan.FromHours(4), address, "Sunny");

        // Display event details
        Console.WriteLine("Lecture Details:");
        Console.WriteLine(lectureEvent.GenerateFullDetails());

        Console.WriteLine("Reception Details:");
        Console.WriteLine(receptionEvent.GenerateFullDetails());

        Console.WriteLine("Outdoor Gathering Details:");
        Console.WriteLine(outdoorEvent.GenerateFullDetails());
    }
}
