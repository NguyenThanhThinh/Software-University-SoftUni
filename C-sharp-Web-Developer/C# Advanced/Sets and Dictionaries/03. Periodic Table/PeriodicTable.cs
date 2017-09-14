using System;
using System.Collections.Generic;

public class PeriodicTable
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var set = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            for (int p = 0; p < input.Length; p++)
            {
                set.Add(input[p]);
            }
        }
        Console.WriteLine(string.Join(" ", set));
    }
}