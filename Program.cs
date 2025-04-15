using System;
using System.Linq;
using SqlChat.Data;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

        // Ensure the database and seed channels
        if (!db.Channels.Any())
        {
            var general = new Channel { Name = "General" };
            var random = new Channel { Name = "Random" };

            db.Channels.AddRange(general, random);
            db.SaveChanges();
        }

        // Add some messages if none exist
        if (!db.Messages.Any())
        {
            var generalChannel = db.Channels.First(c => c.Name == "General");
            var randomChannel = db.Channels.First(c => c.Name == "Random");

            var messages = new[]
            {
                new Message { Channel = generalChannel, Content = "Welcome to General!", Date = DateTime.Now },
                new Message { Channel = generalChannel, Content = "Feel free to chat here.", Date = DateTime.Now.AddMinutes(-10) },
                new Message { Channel = randomChannel, Content = "Random thoughts go here.", Date = DateTime.Now.AddHours(-1) }
            };

            db.Messages.AddRange(messages);
            db.SaveChanges();
        }

        // Display messages grouped by channel
        var channelsWithMessages = db.Channels
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                c.Name,
                Messages = c.Messages.OrderByDescending(m => m.Date).ToList()
            }).ToList();

        foreach (var channel in channelsWithMessages)
        {
            Console.WriteLine($"Channel: {channel.Name}");
            foreach (var message in channel.Messages)
            {
                Console.WriteLine($"  [{message.Date:t}] {message.Content}");
            }
            Console.WriteLine();
        }
    }
}
