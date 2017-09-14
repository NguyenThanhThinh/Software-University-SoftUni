using System;

class RectangleArea
{
    static void Main()
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());

        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        double area = 0d;
        double Perimeter = 0d;

        double x = 0d;
        double y = 0d;

        if (x1 > x2)
        {
            x = x1 - x2;
        }
        else
        {
            x = x2 - x1;
        }

        if (y1 > y2)
        {
            y = y1 - y2;
        }
        else
        {
            y = y2 - y1;
        }

        Console.WriteLine(x * y);
        Console.WriteLine(2 * (x + y));
    }
}
