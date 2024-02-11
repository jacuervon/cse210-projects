class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private int _count;
    public ListingActivity(string name, string description) : base(name, description)
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public override void Run()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        GetListFromUser();
        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
    }

    private void GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private List<string> GetListFromUser()
    {
        List<string> list = new List<string>();
        DateTime futureTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < futureTime)
        {
            Console.Write(">");
            string response = Console.ReadLine();
            list.Add(response);
            _count++;
        }
        return list;
    }
}