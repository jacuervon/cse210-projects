using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        bool running = true;

        while (running)
        {
            DisplayMainMenu();
            int option = GetOption();

            switch (option)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    RunActivity(breathingActivity);
                    activities.Add(breathingActivity);
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                    RunActivity(reflectingActivity);
                    activities.Add(reflectingActivity);
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                    RunActivity(listingActivity);
                    activities.Add(listingActivity);
                    break;
                case 4:
                    DisplayStatistics(activities);
                    running = false;
                    break;
                case 5:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
            }
        }
    }

    static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Statistics");
        Console.WriteLine("5. Quit");
    }

    static int GetOption()
    {
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();
        int option = int.Parse(userInput);
        return option;
    }

    static void RunActivity(Activity activity)
    {
        Console.Clear();
        activity.DisplayStartingMessage();

        Console.Write("How long, in seconds, would you like for your session? ");
        string userInput = Console.ReadLine();
        int duration = int.Parse(userInput);
        activity.SetDuration(duration);

        Console.Clear();
        Console.WriteLine("Get ready...");
        activity.ShowSpinner(5);
        Console.WriteLine();

        activity.Run();

        Console.WriteLine();
        activity.DisplayEndingMessage();
    }

    static void DisplayStatistics(List<Activity> activities)
    {
        List<string> activityNames = activities.Select(activity => activity.GetName()).ToList();
        List<int> activityDurations = activities.Select(activity => activity.GetDuration()).ToList();
        double averageDuration = activityDurations.Average();
        int totalDuration = activityDurations.Sum();

        Console.Clear();
        Console.WriteLine("========> Statistics <==========");
        Console.WriteLine($"Favorite activity: {activityNames.GroupBy(name => name).OrderByDescending(group => group.Count()).First().Key}");
        Console.WriteLine($"Total duration: {totalDuration} seconds");
        Console.WriteLine($"Average duration: {averageDuration} seconds");
        Console.WriteLine("=======> Activity history <=========");
        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            Console.WriteLine($"Activity: {activity.GetName()}");
            Console.WriteLine($"Duration: {activity.GetDuration()} seconds");
            Console.WriteLine();
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}