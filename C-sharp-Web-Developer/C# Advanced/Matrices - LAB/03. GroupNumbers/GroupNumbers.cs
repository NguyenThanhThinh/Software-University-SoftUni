using System;
using System.Linq;

public class GroupNumbers
{
    public static void Main()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        var numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        var numberGroups = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            numberGroups[i] = numbers.Where(n => Math.Abs(n % 3) == i).ToArray();
        }

        foreach (var array in numberGroups)
        {
            if (array.Length > 0)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
    }
}