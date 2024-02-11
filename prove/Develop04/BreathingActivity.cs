class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }
    public override void Run()
    {
        DateTime futureTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < futureTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
