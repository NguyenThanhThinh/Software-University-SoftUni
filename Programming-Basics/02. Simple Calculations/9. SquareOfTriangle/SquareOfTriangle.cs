using System;

class SquareOfTriangle
{
    static void Main()
    {
        double a = Double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double area = (a * h) / 2d;

        Console.WriteLine(Math.Round(area, 2));
    }
}
