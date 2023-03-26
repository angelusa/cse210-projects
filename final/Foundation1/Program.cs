using System;
using System.Collections.Generic;

public class Video
{
    public string title { get; set; }
    public string author { get; set; }
    public int length { get; set; }
    public List<Comment> comments { get; set; }

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public int CommentCount()
    {
        return this.comments.Count;
    }
}

public class Comment
{
    public string name { get; set; }
    public string text { get; set; }

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
}

public class Program
{
    public static void Main()
    {
        // Create 3-4 videos
        Video video1 = new Video("Video 1", "Author 1", 360);
        video1.comments.Add(new Comment("John", "This video is great!"));
        video1.comments.Add(new Comment("Mark", "I agree, it's very informative."));

        Video video2 = new Video("Video 2", "Author 2", 240);
        video2.comments.Add(new Comment("John", "I like this video."));
        video2.comments.Add(new Comment("Paul", "This video is amazing!"));

        Video video3 = new Video("Video 3", "Author 3", 120);
        video3.comments.Add(new Comment("Mike", "I'm enjoying this video."));
        video3.comments.Add(new Comment("John", "This video is great!"));

        // Put videos in a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through list of videos
        foreach (Video video in videos)
        {
            // Display video details
            Console.WriteLine("Title: " + video.title);
            Console.WriteLine("Author: " + video.author);
            Console.WriteLine("Length: " + video.length + " seconds");
            Console.WriteLine("Comments: " + video.CommentCount());

            // Display comments
            foreach (Comment comment in video.comments)
            {
                Console.WriteLine("Commenter: " + comment.name);
                Console.WriteLine("Comment: " + comment.text);
            }
            Console.WriteLine();
        }
    }
}
