
public class Channel {
    public int Id {get; init;}
    public required string Name {get; set; }

    public List<Message> Messages { get; set; } = new();
}