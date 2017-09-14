using System;

class Trapezoid
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal h = decimal.Parse(Console.ReadLine());

        decimal area = h * ((a + b) / 2);

        Console.WriteLine(area);
    }
}