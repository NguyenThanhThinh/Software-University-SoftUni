using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double xOne = 1d;
        double xTwo = 1d;
        double xTree = 1d;

        double d = Math.Pow(b, 2) - 4 * a * c;

        if (d < 0)
        {
            Console.WriteLine("No real roots!");
        }

        if (d == 0)
        {
            xOne = -b / (2 * a);
            Console.WriteLine(xOne);
        }

        if (d > 0)
        {
            xTwo = (-b + Math.Sqrt(d)) / (2 * a);
            xTree = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("x1 = {0} x2 = {1}" , xTwo, xTree);
        }
    }
}