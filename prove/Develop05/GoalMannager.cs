using System.IO;
class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        DisplayPlayerInfo();
        DisplayMenu();
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine("");
        Console.WriteLine($"You have {_score} Points.");
        Console.WriteLine("");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Menu options: ");
        Console.WriteLine("1. Add a Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
    }

    public void CreateGoal()
    {
        Console.WriteLine("The goal types are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished with this goal? ");
                string target = Console.ReadLine();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonus = Console.ReadLine();
                _goals.Add(new ChecklistGoal(name, description, points, int.Parse(target), int.Parse(bonus)));
                break;
            default:
                Console.WriteLine("Invalid goal type");
                break;
        }
    }

    public void ListGoalDetails()
    {
        List<string> goalDetails = _goals.Select(goal => goal.GetDetailsString()).ToList();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goalDetails.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goalDetails[i]}");
        }
    }

    private void ListGoalNames()
    {
        List<string> goalNames = _goals.Select(goal => goal.GetName()).ToList();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goalNames.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goalNames[i]}");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();
        int goalIndex = int.Parse(input) - 1;
        _goals[goalIndex].RecordEvent();

        int addScore = int.Parse(_goals[goalIndex].GetPoints());

        if (_goals[goalIndex].IsCompleted() && _goals[goalIndex] is ChecklistGoal)
        {
            addScore += ((ChecklistGoal)_goals[goalIndex]).GetBonus();
        }

        _score += addScore;

        Console.WriteLine($"Congratulations! You have earned {addScore} points!");
    }

    public void SaveGoals()
    {
        Console.WriteLine("What would you like to name the file?");
        string fileName = Console.ReadLine();
        StreamWriter streamWriter = new StreamWriter(fileName);
        using (StreamWriter outputFile = streamWriter)
        {
            outputFile.WriteLine($"{_score}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.WriteLine("What is the name of the file?");
        string fileName = Console.ReadLine();
        StreamReader streamReader = new StreamReader(fileName);
        using (StreamReader inputFile = streamReader)
        {
            _score = int.Parse(inputFile.ReadLine());
            _goals.Clear();
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] goalData = line.Split(':');
                string[] goalDetails = goalData[1].Split(',');
                switch (goalData[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(goalDetails[0], goalDetails[1], goalDetails[2]));
                        if (goalDetails[3] == "True")
                        {
                            _goals[_goals.Count - 1].RecordEvent();
                        }
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(goalDetails[0], goalDetails[1], goalDetails[2]));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(goalDetails[0], goalDetails[1], goalDetails[2], int.Parse(goalDetails[4]), int.Parse(goalDetails[3])));
                        for (int i = 0; i < int.Parse(goalDetails[5]); i++)
                        {
                            _goals[_goals.Count - 1].RecordEvent();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type");
                        break;
                }
            }
        }

        Console.WriteLine("Goals loaded!");
    }


}