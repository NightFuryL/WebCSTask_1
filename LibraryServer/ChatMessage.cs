using System.Text.Json;

namespace LibraryServer;
public class ChatMessage
{
    public string UserName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public ConsoleColor Color { get; set; }
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static ChatMessage? FromJson(string json)
    {
        return JsonSerializer.Deserialize<ChatMessage>(json);
    }

    public override string ToString()
    {
        return $"[{UserName}]: {Text}";
    }
}
