using System;
using System.Collections.Generic;

public class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display video details along with comments
    public void DisplayDetailsWithComments()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Length: " + lengthInSeconds + " seconds");
        Console.WriteLine("Number of comments: " + comments.Count);
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine("Comment by " + comment.CommenterName + ": " + comment.CommentText);
        }
        Console.WriteLine();
    }
}

public class Comment
{
    private string commenterName;
    private string commentText;

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    // Properties
    public string CommenterName
    {
        get { return commenterName; }
        set { commenterName = value; }
    }

    public string CommentText
    {
        get { return commentText; }
        set { commentText = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Title 1", "Author 1", 120);
        Video video2 = new Video("Title 2", "Author 2", 180);

        // Add comments
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "I learned a lot from this."));
        video2.AddComment(new Comment("User3", "Interesting topic."));

        // Display video details with comments
        video1.DisplayDetailsWithComments();
        video2.DisplayDetailsWithComments();
    }
}
