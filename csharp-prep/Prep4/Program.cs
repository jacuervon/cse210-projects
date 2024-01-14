using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        int userNumber;
        bool isRunning;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        isRunning = true;
        while (isRunning)
        {
            // Prompt the user to enter a list of numbers
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();

            // If the user enters 0, exit the program
            if (userInput == "0")
            {
                isRunning = false;
                continue;
            }

            // If the user enters a number, add it to the list
            userNumber = int.Parse(userInput);
            numbers.Add(userNumber);
        }

        // Compute the sum of the numbers in the list
        Console.WriteLine($"The sum of the numbers is: {numbers.Sum()}");
        Console.WriteLine($"The average of the numbers is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
        Console.WriteLine($"The smallest number is: {numbers.Min()}");

        // Sort the list of numbers
        numbers.Sort();
        Console.WriteLine("The numbers in sorted order are:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}