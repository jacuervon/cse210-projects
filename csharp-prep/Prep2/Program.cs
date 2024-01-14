using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        string gradeLetter;
        string gradeSign;
        int gradePercentage;
        bool isPassing;

        // Prompt user for grade percentage
        Console.WriteLine("What is your grade percentage?: ");
        userInput = Console.ReadLine();
        gradePercentage = int.Parse(userInput);

        // Compute grade letter
        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        // Compute grade sign
        int result = gradePercentage % 10;

        if (result >= 7 && (gradeLetter != "F" || gradeLetter != "A"))
        {
            gradeSign = "+";
        }
        else if (result < 3 && gradeLetter != "F")
        {
            gradeSign = "-";
        }else{
            gradeSign = "";
        }

        // Compute if passing
        if (gradePercentage >= 70)
        {
            isPassing = true;
        }
        else
        {
            isPassing = false;
        }

        Console.WriteLine($"your grade is {gradeLetter}{gradeSign}.");
        Console.WriteLine($"{(isPassing ? "You passed!" : "Better luck next time!")}");
    }
}