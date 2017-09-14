using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        List<int> uniqueNumbers = numbers.Distinct().ToList();

        string bitString = "";
        List<int> elements = new List<int>();
        int sum = 0;
        List<SortedSet<int>> result = new List<SortedSet<int>>();
        bool noMatchingSubsets = true;
        int addSortedSetArray = 0;


        for (int i = 0; i < Math.Pow(2, uniqueNumbers.Count); i++)
        {
            bitString = "";
            bitString = Convert.ToString(i, 2).PadLeft(16, '0');

            for (int h = 0; h < bitString.Length - 1; h++)
            {
                if (bitString[bitString.Length - 1 - h] == '1')
                {
                    elements.Add(h);
                }
            }

            for (int p = 0; p < elements.Count; p++)
            {
                sum += uniqueNumbers[elements[p]];
                if (sum == n && p + 1 == elements.Count)
                {
                    result.Add(new SortedSet<int>());
                    for (int y = 0; y <= p; y++)
                    {
                        var position = elements[y];
                        result[addSortedSetArray].Add(uniqueNumbers[position]);
                    }
                    addSortedSetArray++;
                    noMatchingSubsets = false;
                }
            }
            sum = 0;
            elements.Clear();
        }
        result.Sort((a, b) => a.Count.CompareTo(b.Count));

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(string.Join(" + ", result[i]));
            Console.WriteLine(" = {0}", n);
        }

        if (noMatchingSubsets)
        {
            Console.WriteLine("No Matching Subsets");
        }
    }
}