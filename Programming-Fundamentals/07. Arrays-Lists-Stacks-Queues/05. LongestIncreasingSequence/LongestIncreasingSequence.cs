using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        List<int> sequencesForPrint = new List<int>();
        List<int> longestSequenceForPrint = new List<int>();
        bool toPrint = false;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
            {
                sequencesForPrint.Add(numbers[i]);

            }
            else
            {
                toPrint = true;
            }

            if (toPrint || i == numbers.Length - 2)
            {

                if (i != numbers.Length - 2)
                {
                    sequencesForPrint.Add(numbers[i]);
                }
                else
                {
                    sequencesForPrint.Add(numbers[i + 1]);
                }

                foreach (int num in sequencesForPrint)
                {
                    Console.Write("{0} ", num);
                }
                Console.WriteLine();

                if (longestSequenceForPrint.Count < sequencesForPrint.Count)
                {
                    longestSequenceForPrint.Clear();
                    longestSequenceForPrint.AddRange(sequencesForPrint);
                }
                sequencesForPrint.Clear();
                toPrint = false;
            }
        }

        Console.Write("Longest: ");
        foreach (int num in longestSequenceForPrint)
        {
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }
}