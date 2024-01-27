using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Scripture Memorization Program!");

        // Create a scripture object with the reference and text
        Scripture scripture = new Scripture(new Reference("John 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        DisplayScripture(scripture);

        while (true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            // Hide a few random words and display the updated scripture
            HideRandomWords(scripture);
            DisplayScripture(scripture);

            // Check if all words are hidden
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Program ending.");
                break;
            }
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {scripture.GetReference()}");
        Console.WriteLine(scripture.GetVisibleText());
    }

    static void HideRandomWords(Scripture scripture)
    {
        scripture.HideRandomWords();
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = ParseText(text);
        this.random = new Random();
    }

    public string GetReference()
    {
        return reference.ToString();
    }

    public string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "_____" : word.Text));
    }

    public void HideRandomWords()
    {
        int wordsToHide = random.Next(1, words.Count + 1);
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();

        if (wordsToHide > visibleWords.Count)
            wordsToHide = visibleWords.Count;

        List<int> indicesToHide = new List<int>();

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            indicesToHide.Add(words.IndexOf(visibleWords[index]));
            visibleWords.RemoveAt(index);
        }

        foreach (int index in indicesToHide)
        {
            words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    private List<Word> ParseText(string text)
    {
        List<Word> parsedWords = new List<Word>();

        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            parsedWords.Add(new Word(word));
        }

        return parsedWords;
    }
}

class Reference
{
    private string reference;

    public Reference(string reference)
    {
        this.reference = reference;
    }

    public override string ToString()
    {
        return reference;
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
