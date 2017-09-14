using System;

class RadianToDegree
{
    static void Main()
    {
        double rad = double.Parse(Console.ReadLine());
        double deg = 0d;

        deg = rad * (180 / Math.PI);
        Console.WriteLine(Math.Round(deg));
    }
}
