using System.Text.Json;

namespace MulticastLibrary;

public enum MessageType
{
    News,
    Reminder,
    Entertainment,
    Emergency
}
public class CompanyMessage
{
    public string Text { get; set; } = string.Empty;

    public MessageType Type { get; set; }

    public DateTime Time { get; set; } = DateTime.Now;

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static CompanyMessage? FromJson(string json)
    {
        return JsonSerializer.Deserialize<CompanyMessage>(json);
    }

    public override string ToString()
    {
        return $"[{Time:HH:mm}] [{Type}] {Text}";
    }
}