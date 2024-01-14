using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        int magicNumber;
        int userGuessNumber;
        bool isCorrect;

        //Generate random number
        Random randomGenerator = new Random();
        magicNumber = randomGenerator.Next(1, 100);

        // // //Prompt user for magic number
        // Console.WriteLine("What is the magic number?: ");
        // userInput = Console.ReadLine();
        // magicNumber = int.Parse(userInput);

        isCorrect = false;
        while (!isCorrect)
        {
            //Guess the magic number
            Console.WriteLine("Guess the magic number: ");
            userInput = Console.ReadLine();
            userGuessNumber = int.Parse(userInput);

            //Check if user guess is correct
            if (userGuessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                isCorrect = true;
            }

        }
    }
}