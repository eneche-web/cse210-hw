using System;
using System.Collections.Generic;

using System.Reflection.PortableExecutable;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to BYU-Pathway", "Students", 750);
        video1.AddComment(new Comment("Eneche", "Expilicite Explanation!"));
        video1.AddComment(new Comment("Barri", "Helpful insight."));
        video1.AddComment(new Comment("Williams", "Excellent"));

        videos.Add(video1);


        Video video2 = new Video("Introduction to C# Programming", "Code Academy", 950);
        video2.AddComment(new Comment("Eneche", "Great Explanation!"));
        video2.AddComment(new Comment("Serah", "I finally understand classes."));
        video2.AddComment(new Comment("Michael", "Looking forward to the next lession."));

        videos.Add(video2);


        Video video3 = new Video("Learning Object-Oriented Programing", "Programming Hub", 900);
        video3.AddComment(new Comment("Eneche", "Excellent content."));
        video3.AddComment(new Comment("Williams", "Thanks for sharing."));
        video3.AddComment(new Comment("Veronica", "Awesome examples"));

        videos.Add(video3);

        foreach(Video video in videos)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAutor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()}");



            Console.WriteLine($"Comment:");
            {
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"{comment.GetCommenterName()}: {comment.GetCommentText}");
                }
            }

            Console.WriteLine();
        }
    }
}