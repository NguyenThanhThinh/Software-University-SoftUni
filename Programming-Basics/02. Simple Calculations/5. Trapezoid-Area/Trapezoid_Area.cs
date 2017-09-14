using System;

class Trapezoid_Area
{
    static void Main()
    {
        double b1 = double.Parse(Console.ReadLine());
        double b2 = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double area = ((b1 + b2) * h) / 2d;

        Console.WriteLine(area);
    }
}
