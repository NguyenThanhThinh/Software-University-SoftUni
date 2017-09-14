using System;
using System.Linq;

class EnduranceRally
{
    static void Main()
    {
        var names = Console.ReadLine().Split();
        double[] zones = Console.ReadLine().Split().Select(double.Parse).ToArray();
        int[] checkPoints = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < names.Length; i++)
        {
            int startFuel = (int)names[i][0];
            string fuelLeft = GetFuelLeft(startFuel, zones, checkPoints);
            if (fuelLeft[0] == '-')
            {
                Console.WriteLine($"{names[i]} - reached {fuelLeft.TrimStart('-')}");
            }
            else
            {
                Console.WriteLine($"{names[i]} - fuel left {double.Parse(fuelLeft):F2}");
            }
        }
    }

    private static string GetFuelLeft(int startFuel, double[] zones, int[] checkPoints)
    {
        double fuel = (double)startFuel;
        for (int i = 0; i < zones.Length; i++)
        {
            if (checkPoints.Contains(i))
            {
                fuel += zones[i];
            }
            else
            {
                fuel -= zones[i];
                if (fuel <= 0)
                {
                    fuel = i;
                    return "-" + fuel;
                }
            }
        }
        return fuel.ToString();
    }
}