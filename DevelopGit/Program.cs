using DevelopGit;

public class Program
{
    public static void Main(string[] args)
    {
        Creator creator = new Creator();
        Video video = new Video();

        video.Name = "Hello";

        creator.OnNotification += () =>
        {
            Console.WriteLine("G");
        };
        
        creator.Notify();
    }
}