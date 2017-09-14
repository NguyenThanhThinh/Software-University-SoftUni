using System;

class CelsiumToF
{
    static void Main()
    {
        double celsium = Double.Parse(Console.ReadLine());
        double fahrenheit = (celsium * 1.8) + 32;

        Console.WriteLine(fahrenheit);
    }
}
