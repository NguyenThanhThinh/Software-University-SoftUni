using System;
using System.Collections.Generic;

class PascalTriangle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var pascal = new List<List<long>>();

        for (int i = 0; i < n; i++)
        {
            pascal.Add(new List<long>());
            pascal[i].Add(1);

            if (i > 1)
            {
                // calculating every 2 pairs of numbers from the previous Sequence
                for (int j = 0; j < pascal[i - 1].Count - 1; j++)
                {
                    long nextNum = pascal[i - 1][j] + pascal[i - 1][j + 1];
                    pascal[i].Add(nextNum);
                }
                pascal[i].Add(1);
            }
            // statement so I can manipulate the triangle and add 1, one more time for the second row, which is always the same
            else if (i == 1)
            {
                pascal[i].Add(1);
            }
        }

        for (int i = 0; i < pascal.Count; i++)
        {
            Console.WriteLine(string.Join(" ", pascal[i]));
        }
    }
}