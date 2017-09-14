using System;

class CirclePerAndArea
{
    static void Main()
    {
        double r = Double.Parse(Console.ReadLine());

        Console.WriteLine("{0:F2}", (Math.PI * (r * r)));
        Console.WriteLine("{0:F2}", 2 * (Math.PI * r));
    }
}