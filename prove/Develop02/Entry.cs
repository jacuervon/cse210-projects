using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry
{
    [JsonPropertyName("_date")]
    public string _date { get; set; }
    [JsonPropertyName("_promptText")]
    public string _promptText { get; set; }
    [JsonPropertyName("_entryText")]
    public string _entryText { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }
}