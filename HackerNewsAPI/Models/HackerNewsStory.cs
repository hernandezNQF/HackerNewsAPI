namespace HackerNewsAPI.Models;

public class HackerNewsStory
{
    public string Title { get; set; } = string.Empty;
    public string? Url { get; set; }
    public string By { get; set; } = string.Empty;
    public long Time { get; set; }
    public int Score { get; set; }
    public int Descendants { get; set; }
}
