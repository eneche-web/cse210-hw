using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();

        Fraction f2 = new Fraction(5);

        Fraction f3 = new Fraction(3, 4);

        Fraction f4 = new Fraction(1, 3);

        Console.WriteLine(f1.GetFractionString());

        Console.WriteLine(f1.GetDecinalValue());

        Console.WriteLine();

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        Console.WriteLine();

        f1.SetTop(6);
        f1.SetBottom(7);

        Console.WriteLine("After using setters");

        Console.WriteLine(f1.GetTop());
        Console.WriteLine(f1.GetBottom());

        Console.WriteLine(f1.GetFraction());
        Console.WriteLine(f1.GetDecimal());

    }
}