using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first video.
        Video video1 = new Video(
            "Learning C# Programming",
            "Code Academy",
            420
        );

        video1.AddComment(new Comment(
            "John",
            "This video helped me understand C# better."
        ));

        video1.AddComment(new Comment(
            "Mary",
            "Great explanation! Thank you."
        ));

        video1.AddComment(new Comment(
            "Peter",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "Sarah",
            "Very helpful tutorial."
        ));


        // Create the second video.
        Video video2 = new Video(
            "How to Build a Website",
            "Web Design School",
            600
        );

        video2.AddComment(new Comment(
            "David",
            "The website example was very useful."
        ));

        video2.AddComment(new Comment(
            "Emily",
            "I really enjoyed this tutorial."
        ));

        video2.AddComment(new Comment(
            "Michael",
            "The HTML explanation was clear."
        ));

        video2.AddComment(new Comment(
            "Anna",
            "Thank you for sharing this."
        ));


        // Create the third video.
        Video video3 = new Video(
            "Introduction to Programming",
            "Programming World",
            510
        );

        video3.AddComment(new Comment(
            "James",
            "This is a great introduction."
        ));

        video3.AddComment(new Comment(
            "Linda",
            "I am learning programming for the first time."
        ));

        video3.AddComment(new Comment(
            "Robert",
            "The examples made the topic easier."
        ));

        video3.AddComment(new Comment(
            "Grace",
            "Very informative video."
        ));


        // Create the fourth video.
        Video video4 = new Video(
            "C# Object-Oriented Programming",
            "Developer Channel",
            720
        );

        video4.AddComment(new Comment(
            "Daniel",
            "The classes and objects explanation was excellent."
        ));

        video4.AddComment(new Comment(
            "Jessica",
            "This helped me understand encapsulation."
        ));

        video4.AddComment(new Comment(
            "Thomas",
            "I will use these examples in my project."
        ));

        video4.AddComment(new Comment(
            "Rachel",
            "Excellent programming lesson."
        ));


        // Put all videos into a list.
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);


        // Display each video and its comments.
        foreach (Video video in videos)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"{comment.GetName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}