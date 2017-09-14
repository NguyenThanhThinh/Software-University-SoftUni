using System;

class HornetWings
{
    static void Main()
    {
        decimal wingFlaps = decimal.Parse(Console.ReadLine());
        decimal distance = decimal.Parse(Console.ReadLine());
        decimal endurance = decimal.Parse(Console.ReadLine());
        long time = 0L;

        decimal finalDistanceTraveled = (wingFlaps / 1000m) * distance;
        time = (long)(wingFlaps / 100L);
        long rest = (long)(wingFlaps / endurance) * 5;

        time += rest;

        Console.WriteLine($"{finalDistanceTraveled:F2} m.");
        Console.WriteLine($"{time} s.");
    }
}