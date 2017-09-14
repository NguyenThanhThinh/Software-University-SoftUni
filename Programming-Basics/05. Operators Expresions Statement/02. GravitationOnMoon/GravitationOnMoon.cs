using System;

class GravitationOnMoon
{
    static void Main()
    {
        double earthWeight = double.Parse(Console.ReadLine());
        earthWeight /= 100;
        earthWeight *= 17d;
        Console.WriteLine(earthWeight);
    }
}