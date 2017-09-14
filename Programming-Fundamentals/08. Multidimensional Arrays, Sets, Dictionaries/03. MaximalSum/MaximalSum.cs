using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] colAndRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[][] matrix = new int[colAndRow[0]][];
        int sum = 0;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row < colAndRow[0]; row++)
        {
            matrix[row] = new int[colAndRow[1]];
            for (int col = 0; col < 1; col++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }

        
        for (int row = 0; row < colAndRow[0] - 2; row++)
        {
            for (int col = 0; col < colAndRow[1] - 2; col++)
            {
                int checker = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1] +
                    matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                if (checker > sum)
                {
                    sum = checker;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("Sum = {0}", sum);
        for (int row = bestRow; row < bestRow + 3; row++)
        {
            for (int col = bestCol; col < bestCol + 3; col++)
            {
                Console.Write("{0} ", matrix[row][col]);
            }
            Console.WriteLine();
        }
    }
}