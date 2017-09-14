using System;
using System.Linq;

public class MaximalSum
{
    public static void Main()
    {
        var rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var matrix = new int[rowCol[0]][];

        for (int i = 0; i < rowCol[0]; i++)
        {
            matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        long bestSum = long.MinValue;
        var bestRow = 0;
        var bestCol = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix[row].Length - 2; col++)
            {
                if (matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                    matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                    matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2] > bestSum)
                {
                    bestSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                              matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                              matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine($"Sum = {bestSum}");
        Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]} {matrix[bestRow][bestCol + 2]}");
        Console.WriteLine($"{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]} {matrix[bestRow + 1][bestCol + 2]}");
        Console.WriteLine($"{matrix[bestRow + 2][bestCol]} {matrix[bestRow + 2][bestCol + 1]} {matrix[bestRow + 2][bestCol + 2]}");
    }
}