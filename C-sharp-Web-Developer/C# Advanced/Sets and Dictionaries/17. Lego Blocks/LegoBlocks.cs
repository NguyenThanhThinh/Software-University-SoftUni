using System;
using System.Collections.Generic;
using System.Linq;

public class LegoBlocks
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] firstMatrix = new int[n][];
        int[][] secondMatrix = new int[n][];
        int positionOne = 0;
        int positionTwo = 0;
        int[] equalRowsInBothMatrix = new int[n];
        bool equalOrNot = true;
        int countCells = 0;
        List<List<int>> combinedMatrix = new List<List<int>>();

        for (int i = 0; i < n * 2; i++)
        {
            if (i < n)
            {
                firstMatrix[positionOne] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                positionOne++;
            }
            else
            {
                secondMatrix[positionTwo] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                positionTwo++;
            }
        }

        for (int i = 0; i < n - 1; i++)
        {
            equalRowsInBothMatrix[i] = firstMatrix[i].Length + secondMatrix[i].Length;
            equalRowsInBothMatrix[i + 1] = firstMatrix[i + 1].Length + secondMatrix[i + 1].Length;
            if (i + 1 < n - 1)
            {
                countCells += equalRowsInBothMatrix[i];
            }
            else
            {
                countCells += equalRowsInBothMatrix[i] + equalRowsInBothMatrix[i + 1];
            }

            if (equalRowsInBothMatrix[i] != equalRowsInBothMatrix[i + 1])
            {
                equalOrNot = false;
            }
        }

        if (equalOrNot != true)
        {
            Console.WriteLine("The total number of cells is: {0}", countCells);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                combinedMatrix.Add(new List<int>());
                combinedMatrix[i].AddRange(firstMatrix[i]);
                for (int p = secondMatrix[i].Length - 1; p >= 0; p--)
                {
                    combinedMatrix[i].Add(secondMatrix[i][p]);
                }
            }

            for (int i = 0; i < combinedMatrix.Count; i++)
            {
                Console.Write("[");
                Console.Write(string.Join(", ", combinedMatrix[i]));
                Console.WriteLine("]");
            }
        }
    }
}