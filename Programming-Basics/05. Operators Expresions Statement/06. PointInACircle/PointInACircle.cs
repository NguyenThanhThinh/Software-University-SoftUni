using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double d = Math.Pow((2 - x), 2) + Math.Pow((3 - y), 2);

        if (d > 2 * 2)
        {
            Console.WriteLine("false");
        }
        else
        {
            Console.WriteLine(true);
        }
    }
}