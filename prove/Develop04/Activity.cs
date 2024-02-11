public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);

    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "/", "-", "\\", "|" };
        DateTime futureTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < futureTime)
        {
            foreach (string spin in spinner)
            {
                Console.Write($"{spin}");
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }

    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            int length = i.ToString().Length;
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write($"{new String('\b', length)}{new String(' ', length)}{new String('\b', length)}");
        }
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public abstract void Run();
}