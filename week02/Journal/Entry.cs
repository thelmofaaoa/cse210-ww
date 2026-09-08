using System;

class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // Constructor
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string GetSaveString()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public void LoadFromString(string line)
    {
        string[] parts = line.Split('|');

        _date = parts[0];
        _promptText = parts[1];
        _entryText = parts[2];
    }
}