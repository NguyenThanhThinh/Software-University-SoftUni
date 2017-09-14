using System;
using System.Collections.Generic;
using System.Linq;

class SortWithSelectionSort
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        int nextNumToCheck = 0;
        int oldPositionValue = 0;
        int positionOfSmallerNum = 0;
        bool hadChange = false;

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            oldPositionValue = numbers[i];
            nextNumToCheck = oldPositionValue;
            for (int p = 1 + i; p < numbers.Count; p++)
            {
                if (nextNumToCheck > numbers[p])
                {
                    nextNumToCheck = numbers[p];
                    positionOfSmallerNum = p;
                    hadChange = true;
                }
            }
            if (hadChange)
            {
                numbers.RemoveAt(i);
                numbers.Insert(i, nextNumToCheck);
                numbers.RemoveAt(positionOfSmallerNum);
                numbers.Insert(positionOfSmallerNum, oldPositionValue);
            }
            hadChange = false;
        }

        foreach (var num in numbers)
        {
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }
}