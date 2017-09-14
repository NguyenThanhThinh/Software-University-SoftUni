using System;
using System.Linq;

public class MatrixOfPalindromes
{
    public static void Main()
    {
        var rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var matrix = new string[rowCol[0]][];

        for (int row = 0; row < rowCol[0]; row++)
        {
            matrix[row] = new string[rowCol[1]];
            for (int col = 0; col < rowCol[1]; col++)
            {
                matrix[row][col] = ((char)(97 + row)).ToString() + ((char)(97 + col + row)).ToString() + ((char)(97 + row)).ToString();
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }
}