public class Message
{
    public int Id { get; set; }
    public int ChannelId { get; set; }
    public required string Content { get; set; }
    public DateTime Date { get; set; }

    public required Channel Channel { get; set; }
}