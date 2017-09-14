using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOfPredicates
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> numbersRange = CreateNumbersRange(length);

        for (int i = 0; i < sequence.Count; i++)
        {
            numbersRange = numbersRange.Where(n => n % sequence[i] == 0).ToList();
        }
        Console.WriteLine(string.Join(" ", numbersRange));
    }

    private static List<int> CreateNumbersRange(int n)
    {
        var numbers = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            numbers.Add(i);
        }
        return numbers;
    }
}