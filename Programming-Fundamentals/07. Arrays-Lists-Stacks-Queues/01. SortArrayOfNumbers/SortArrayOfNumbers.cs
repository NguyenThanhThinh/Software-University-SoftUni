using System;
using System.Collections.Generic;
using System.Linq;

class SortArrayOfNumbers
{
    static void Main()
    {
        List<int> arrayNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        arrayNumbers.Sort();

        foreach (var num in arrayNumbers)
        {
            Console.Write("{0} ", num);
        }

        Console.WriteLine();
    }
}