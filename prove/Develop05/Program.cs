using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        bool isRunning = true;
        while (isRunning)
        {
            goalManager.Start();

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int option = int.Parse(input);
            switch (option)
            {
                case 1:
                    goalManager.CreateGoal();
                    break;
                case 2:
                    goalManager.ListGoalDetails();
                    break;
                case 3:
                    goalManager.SaveGoals();
                    break;
                case 4:
                    goalManager.LoadGoals();
                    break;
                case 5:
                    goalManager.RecordEvent();
                    break;
                case 6:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}