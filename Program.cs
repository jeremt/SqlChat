using System.Data;
using SqlChat.Data;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

        if (!db.Channels.Any())
        {
            var general = new Channel { Name = "General" };
            var random = new Channel { Name = "Random" };

            db.Channels.AddRange(general, random);
            db.SaveChanges();
        }

        foreach (var channelName in db.Channels.Select((chan) => chan.Name).ToList()) {
            Console.WriteLine(channelName);
        }
    }
}