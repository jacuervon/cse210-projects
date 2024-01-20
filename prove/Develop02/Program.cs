using System;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        DateTime _date;
        Journal _journal = new Journal();
        PromptGenerator _promptGenerator = new PromptGenerator();

        do
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to your journal!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            string inputOption = Console.ReadLine();

            switch (inputOption)
            {
                case "1":
                    Entry newEntry = new Entry();
                    _date = DateTime.Now;
                    string theCurrentTime = _date.ToShortDateString();
                    string prompt = _promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine($"{prompt}");
                    string entryText = Console.ReadLine();

                    newEntry._date = theCurrentTime;
                    newEntry._promptText = prompt;
                    newEntry._entryText = entryText;

                    _journal.AddEntry(newEntry);
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("======== Entries =========");
                    _journal.DisplayAll();
                    Console.WriteLine("==========================");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("What would you like to name the file?");
                    string fileName = Console.ReadLine();
                    Console.WriteLine("Saving file...");
                    _journal.SaveToFile(fileName);
                    Console.WriteLine("File saved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("What is the name of the file?");
                    string fileToLoad = Console.ReadLine();
                    _journal.LoadFromFile(fileToLoad);
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the journal!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (isRunning);
    }
}