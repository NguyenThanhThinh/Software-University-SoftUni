using System;
using System.Linq;

public class SumMatrixElements
{
    public static void Main()
    {
        var rowCol = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        var matrix = new int[rowCol[0]][];

        for (int i = 0; i < rowCol[0]; i++)
        {
            matrix[i] = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        Console.WriteLine(rowCol[0]);
        Console.WriteLine(rowCol[1]);
        long sum = 0L;

        foreach (var row in matrix)
        {
            sum += row.Sum();
        }

        Console.WriteLine(sum);
    }
}