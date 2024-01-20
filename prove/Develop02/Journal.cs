using System;
using System.Text.Json;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        using (FileStream fs = File.Create(file))
        {
            JsonSerializer.SerializeAsync(fs, _entries);
        }
    }

    public void LoadFromFile(string file)
    {
        using (FileStream fs = File.OpenRead(file))
        {
            _entries = JsonSerializer.DeserializeAsync<List<Entry>>(fs).Result;
        }
    }
}