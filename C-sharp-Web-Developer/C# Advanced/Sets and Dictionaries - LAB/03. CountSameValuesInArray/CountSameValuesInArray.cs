using System;
using System.Collections.Generic;
using System.Linq;

public class CountSameValuesInArray
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
        var numbers = new Dictionary<double, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (!numbers.ContainsKey(input[i]))
            {
                numbers[input[i]] = 1;
            }
            else
            {
                numbers[input[i]]++;
            }
        }

        foreach (var num in numbers.OrderBy(n => n.Key))
        {
            Console.WriteLine($"{num.Key} - {num.Value} times");
        }
    }
}