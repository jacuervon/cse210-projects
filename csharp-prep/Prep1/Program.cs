using System;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        string first_name;
        string last_name;
        Console.WriteLine("What is your first name?");
        first_name = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}");

    }
}