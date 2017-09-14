using System;
using System.Linq;
using System.Text;

public class MaximumSumOfSubmatrix
{
    public static void Main()
    {
        var rowCol = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        var matrix = new int[rowCol[0]][];

        for (int i = 0; i < rowCol[0]; i++)
        {
            matrix[i] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        long bestSum = long.MinValue;
        var bestMatrix = new StringBuilder();

        for (int row = 0; row < rowCol[0] - 1; row++)
        {
            for (int col = 0; col < rowCol[1] - 1; col++)
            {
                if (matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1] > bestSum)
                {
                    bestMatrix.Clear();
                    bestSum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                    bestMatrix.AppendLine(matrix[row][col] + " " + matrix[row][col + 1]);
                    bestMatrix.AppendLine(matrix[row + 1][col] + " " + matrix[row + 1][col + 1]);
                }
            }
        }

        Console.Write(bestMatrix);
        Console.WriteLine(bestSum);
    }
}