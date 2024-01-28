using System;

class Program
{
    static void Main(string[] args)
    {

        List<Scripture> scriptures = new List<Scripture>();

        Reference referenceDefault = new Reference("Proverbs", 3, 5, 6);
        string textDefault = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture defaultScripture = new Scripture(referenceDefault, textDefault);

        Reference reference = new Reference("John", 3, 16);
        string textDefault2 = "For God so bloved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture defaultScripture2 = new Scripture(reference, textDefault2);

        scriptures.Add(defaultScripture);
        scriptures.Add(defaultScripture2);

        string userOption = "";

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorization App!");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayReference()}");
            }
            Console.WriteLine($"{scriptures.Count + 1}. Add a new scripture");
            Console.Write("Enter your selection, or type 'quit' to exit: ");

            userOption = Console.ReadLine();

            if (userOption == "quit")
            {
                continue;
            }

            int numOption = int.Parse(userOption);
            if (numOption == scriptures.Count + 1)
            {
                Console.Write("Enter the book: ");
                string book = Console.ReadLine();
                Console.Write("Enter the chapter: ");
                int chapter = int.Parse(Console.ReadLine());
                Console.Write("How many verses?: ");
                int numVerses = int.Parse(Console.ReadLine());
                if (numVerses == 1)
                {
                    Console.Write("Enter the verse: ");
                    int verse = int.Parse(Console.ReadLine());
                    Console.Write("Enter the text: ");
                    string text = Console.ReadLine();
                    scriptures.Add(new Scripture(new Reference(book, chapter, verse), text));
                }
                else
                {
                    Console.Write("Enter the start verse: ");
                    int startVerse = int.Parse(Console.ReadLine());
                    Console.Write("Enter the end verse: ");
                    int endVerse = int.Parse(Console.ReadLine());
                    Console.Write("Enter the text: ");
                    string text = Console.ReadLine();
                    scriptures.Add(new Scripture(new Reference(book, chapter, startVerse, endVerse), text));
                }
            }
            else
            {
                MemorizeScriptture(scriptures[numOption - 1]);
            }
        } while (userOption != "quit");

    }

    static void MemorizeScriptture(Scripture scripture)
    {
        int numberToHide = 3;
        bool isRunning = true;

        if(scripture.IsCompletelyHidden())
        {
            Console.WriteLine("You have already memorized this scripture!");
            Console.WriteLine("Do you want to reset it? (y/n)");
            string reset = Console.ReadLine();
            if(reset != "y")
            {
                return;
                
            }

            scripture.Reset();
        }

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("Press enter to hide words, or type 'quit' to exit:");
            string userInput = Console.ReadLine();
            if (userInput == "quit" || scripture.IsCompletelyHidden())
            {
                isRunning = false;
                continue;
            }
            scripture.HideRandomWords(numberToHide);
        }
        Console.WriteLine(scripture.GetDisplayText());
    }
}