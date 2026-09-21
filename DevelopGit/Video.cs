namespace DevelopGit;

public class Video
{
    public string Name { get; set; }


    public void VideoNotification()
    {
        Console.WriteLine($"{Name} is out");
    }
}