using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetFractionValue()}");

        Fraction f2 = new Fraction(5);
        Console.WriteLine($"{f2.GetFractionString()}");
        Console.WriteLine($"{f2.GetFractionValue()}");

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine($"{f3.GetFractionString()}");
        Console.WriteLine($"{f3.GetFractionValue()}");

        f3.SetTop(1);
        f3.SetBottom(3);
        Console.WriteLine($"{f3.GetFractionString()}");
        Console.WriteLine($"{f3.GetFractionValue()}");
    }
}