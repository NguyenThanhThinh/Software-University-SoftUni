using System;
using System.Collections.Generic;
using System.Linq;

public static class FIndEvensOrOdds
{
    public static void Main()
    {
        var range = Console.ReadLine().Split().Select(int.Parse).ToList();
        string criteria = Console.ReadLine();
        var rangeNumbers = InitializeNumbers(range);
        var finalNumbers = new List<int>();

        if (criteria.Equals("even"))
        {
            Predicate<int> evenNums = n => n % 2 == 0;
            finalNumbers = rangeNumbers.FindAll(evenNums);
        }
        else if (criteria.Equals("odd"))
        {
            Predicate<int> oddNums = n => n % 2 != 0;
            finalNumbers = rangeNumbers.FindAll(oddNums);
        }
        Console.WriteLine(string.Join(" ", finalNumbers));
    }

    private static List<int> InitializeNumbers(List<int> range)
    {
        var numbers = new List<int>();
        int startNum = range[0];

        for (int i = 0; i <= range[1] - range[0]; i++, startNum++)
        {
            numbers.Add(startNum);
        }
        return numbers;
    }
}