using System;
using System.Linq;
using System.Text.RegularExpressions;

public class SquaresInMatrix
{
    public static void Main()
    {
        var rowCol = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        var matrix = new char[rowCol[0]][];

        for (int i = 0; i < rowCol[0]; i++)
        {
            matrix[i] = Regex.Replace(Console.ReadLine(), @"\s+", "").ToCharArray();
        }
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix[row].Length - 1; col++)
            {
                if (matrix[row][col].Equals(matrix[row + 1][col]) && matrix[row + 1][col + 1].Equals(matrix[row][col + 1])
                    && matrix[row][col].Equals(matrix[row][col + 1]))
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}