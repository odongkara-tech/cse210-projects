using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video videoOne = new Video("Building a Better Morning Routine", "Maya Chen", 542);
        videoOne.AddComment(new Comment("Alex Rivera", "The planning tip made my mornings much easier."));
        videoOne.AddComment(new Comment("Sam Patel", "I am going to try this routine tomorrow."));
        videoOne.AddComment(new Comment("Jordan Kim", "Thanks for keeping the advice practical."));
        videos.Add(videoOne);

        Video videoTwo = new Video("Easy Weeknight Pasta", "Kitchen with Luca", 684);
        videoTwo.AddComment(new Comment("Taylor Brooks", "The lemon at the end was a great touch."));
        videoTwo.AddComment(new Comment("Morgan Diaz", "I made this for dinner and everyone loved it."));
        videoTwo.AddComment(new Comment("Casey Nguyen", "Could you share a vegetarian variation?"));
        videos.Add(videoTwo);

        Video videoThree = new Video("A Walk Through Kyoto", "Wander with Emi", 913);
        videoThree.AddComment(new Comment("Riley Adams", "The street market looked amazing."));
        videoThree.AddComment(new Comment("Jamie Park", "Adding this neighborhood to my travel list."));
        videoThree.AddComment(new Comment("Drew Foster", "The quiet temple scenes were beautiful."));
        videos.Add(videoThree);

        Video videoFour = new Video("Five Useful C# Tips", "Code Simply", 761);
        videoFour.AddComment(new Comment("Avery Wilson", "The dictionary example finally clicked for me."));
        videoFour.AddComment(new Comment("Quinn Lewis", "Shortcuts like these save so much time."));
        videoFour.AddComment(new Comment("Cameron Bell", "Please make another video about debugging."));
        videos.Add(videoFour);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comment list:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}