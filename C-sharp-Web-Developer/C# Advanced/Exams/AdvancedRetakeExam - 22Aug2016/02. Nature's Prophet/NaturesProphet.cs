using System;
using System.Collections.Generic;
using System.Linq;

public class NaturesProphet
{
    public static void Main()
    {
        var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var garden = new List<List<int>>();
        var input = Console.ReadLine().Split();
        var bloomedFLowers = new List<List<int>>();

        Initilizing(garden, bloomedFLowers, dimentions);

        while (input[0] != "Bloom")
        {
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            garden[row][col] = 1;
            bloomedFLowers[row][col] = 1;
            input = Console.ReadLine().Split();
        }
        
        for (int r = 0; r < dimentions[0]; r++)
        {
            for (int c = 0; c < dimentions[1]; c++)
            {
                int row = r;
                int col = c;
                if (garden[row][col] == 1)
                {
                    BloomFlowers(bloomedFLowers, row, col);
                }
            }
        }
        Print(bloomedFLowers);
    }

    private static void Initilizing(List<List<int>> garden, List<List<int>> bloomedFLowers, int[] dimentions)
    {
        for (int r = 0; r < dimentions[0]; r++)
        {
            garden.Add(new List<int>());
            bloomedFLowers.Add(new List<int>());
            for (int c = 0; c < dimentions[1]; c++)
            {
                garden[r].Add(0);
                bloomedFLowers[r].Add(0);
            }
        }
    }

    private static void Print(List<List<int>> bloomedFLowers)
    {
        for (int i = 0; i < bloomedFLowers.Count; i++)
        {
            for (int p = 0; p < bloomedFLowers[i].Count; p++)
            {
                Console.Write(bloomedFLowers[i][p] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void BloomFlowers(List<List<int>> bloomedFLowers, int row, int col)
    {
        for (int r = col + 1; r < bloomedFLowers[row].Count; r++)
        {
            bloomedFLowers[row][r]++;
        }
        for (int r2 = col - 1; r2 >= 0; r2--)
        {
            bloomedFLowers[row][r2]++;
        }
        for (int c = row + 1; c < bloomedFLowers.Count; c++)
        {
            bloomedFLowers[c][col]++;
        }
        for (int c2 = row - 1; c2 >= 0; c2--)
        {
            bloomedFLowers[c2][col]++;
        }
    }
}