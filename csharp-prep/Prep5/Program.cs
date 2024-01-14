using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        //  Displays the message, "Welcome to the Program!"
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        // Asks for and returns the user's name (as a string)
        string userName;

        Console.Write("Enter your name: ");
        userName = Console.ReadLine();

        return userName;
    }
    static int PromptUserNumber()
    {
        // Asks for and returns the user's favorite number (as an integer)

        string userInput;
        int userNumber;

        Console.Write("Enter a number: ");
        userInput = Console.ReadLine();
        userNumber = int.Parse(userInput);

        return userNumber;
    }
    static int SquareNumber(int number)
    {
        //Accepts an integer as a parameter and returns that number squared (as an integer)
        int squaredNumber = number * number;
        return squaredNumber;
    }
    static void DisplayResult(string userName, int squaredNumber)
    {
        //Accepts the user's name and the squared number and displays them.
        Console.WriteLine($"{userName}, your number squared is {squaredNumber}");
    }
}