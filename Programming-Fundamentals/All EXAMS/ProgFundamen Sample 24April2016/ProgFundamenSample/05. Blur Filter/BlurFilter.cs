using System;
using System.Linq;

class BlurFilter
{
    static void Main(string[] args)
    {
        long blur = long.Parse(Console.ReadLine());
        var rowCol = Console.ReadLine().Split();
        int row = int.Parse(rowCol[0]);
        int col = int.Parse(rowCol[1]);
        long[,] matrix = new long[row, col];

        for (int i = 0; i < row; i++)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            for (int p = 0; p < col; p++)
            {
                matrix[i, p] = line[p];
            }
        }

        var blurIndexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int blurRow = blurIndexes[0];
        int blurCol = blurIndexes[1];

        BlurMatrix(blur, matrix, blurRow, blurCol);
        PrintMatrix(matrix);
    }

    private static void BlurMatrix(long blur, long[,] matrix, int blurRow, int blurCol)
    {
        matrix[blurRow, blurCol] += blur;

        if (blurRow - 1 >= 0 && blurCol - 1 >= 0)
        {
            matrix[blurRow - 1, blurCol - 1] += blur;
        }
        if (blurRow - 1 >= 0)
        {
            matrix[blurRow - 1, blurCol] += blur;
        }
        if (blurCol - 1 >= 0)
        {
            matrix[blurRow, blurCol - 1] += blur;
        }
        if (blurRow - 1 >= 0 && blurCol + 1 < matrix.GetLength(1))
        {
            matrix[blurRow - 1, blurCol + 1] += blur;
        }
        if (blurCol + 1 < matrix.GetLength(1))
        {
            matrix[blurRow, blurCol + 1] += blur;
        }
        if (blurRow + 1 < matrix.GetLength(0) && blurCol - 1 >= 0)
        {
            matrix[blurRow + 1, blurCol - 1] += blur;
        }
        if (blurRow + 1 < matrix.GetLength(0))
        {
            matrix[blurRow + 1, blurCol] += blur;
        }
        if (blurRow + 1 < matrix.GetLength(0) && blurCol + 1 < matrix.GetLength(1))
        {
            matrix[blurRow + 1, blurCol + 1] += blur;
        }
    }

    private static void PrintMatrix(long[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int p = 0; p < matrix.GetLength(1); p++)
            {
                Console.Write(matrix[i, p]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}