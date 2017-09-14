using System;
using System.Linq;

public class DiagonalDifference
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        long leftDiag = 0;
        long rightDiag = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            leftDiag += matrix[row][row];
            rightDiag += matrix[row][matrix[row].Length - 1 - row];
        }
        Console.WriteLine(Math.Abs(leftDiag - rightDiag));
    }
}