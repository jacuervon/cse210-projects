class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    public ReflectingActivity(string name, string description) : base(name, description)
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public override void Run()
    {
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime futureTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> questions = _questions;
        while (DateTime.Now < futureTime && questions.Count > 0)
        {
            string question = GetRandomQuestion(questions);
            DisplayQuestion(question);
        }
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion(List<string> questions)
    {
        Random rnd = new Random();
        int index = rnd.Next(questions.Count);
        string question = questions[index];
        questions.RemoveAt(index);
        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    private void DisplayQuestion(string question)
    {
        Console.Write($"> {question}");
        ShowSpinner(10);
        Console.WriteLine();
    }
}