using System;
using System.Collections.Generic;
using System.Linq;

public class PoisonousPlants
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var poisonPlants = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Take(n)
            .ToArray();

        var days = new int[n];
        var indexes = new Stack<int>();
        indexes.Push(0);
        int maximumDays = 0;

        for (int i = 1; i < poisonPlants.Length; i++)
        {
            while (indexes.Count > 0 && poisonPlants[indexes.Peek()] >= poisonPlants[i])
            {
                maximumDays = Math.Max(maximumDays, days[indexes.Pop()]);
            }

            if (indexes.Count > 0)
            {
                days[i] = maximumDays + 1;
            }

            indexes.Push(i);
        }

        Console.WriteLine(days.Max());
    }
}