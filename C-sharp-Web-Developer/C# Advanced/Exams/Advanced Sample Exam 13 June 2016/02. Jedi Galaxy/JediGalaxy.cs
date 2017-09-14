using System;
using System.Linq;

class JediGalaxy
{
    static void Main()
    {
        int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[,] matrix = InitilizeMatrix(dimentions);
        var input = Console.ReadLine();
        long sum = 0;

        while (input != "Let the Force be with you")
        {
            int ivoRow = int.Parse(input.Split()[0]);
            int ivoCol = int.Parse(input.Split()[1]);
            input = Console.ReadLine();
            int evilRow = int.Parse(input.Split()[0]);
            int evilCol = int.Parse(input.Split()[1]);

            EvilDamagingDiagonal(evilRow, evilCol, matrix);
            sum += IvoCollectingDiagonal(ivoCol, ivoRow, matrix);

            input = Console.ReadLine();
        }
        Console.WriteLine(sum);
    }

    private static int IvoCollectingDiagonal(int ivoCol, int ivoRow, int[,] matrix)
    {
        int sum = 0;
        while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
        {
            if (IsInMatrix(ivoRow, ivoCol, matrix))
            {
                sum += matrix[ivoRow, ivoCol];
            }
            ivoRow--;
            ivoCol++;
        }
        return sum;
    }

    private static void EvilDamagingDiagonal(int evilRow, int evilCol, int[,] matrix)
    {
        while (evilCol >= 0 && evilRow >= 0)
        {
            if (IsInMatrix(evilRow, evilCol, matrix))
            {
                matrix[evilRow, evilCol] = 0;
            }
            evilCol--;
            evilRow--;
        }
    }

    private static bool IsInMatrix(int givenRow, int givenCol, int[,] matrix)
    {
        bool result = givenRow >= 0 && givenRow < matrix.GetLength(0) && givenCol >= 0 && givenCol < matrix.GetLength(1);
        return result;
    }

    private static int[,] InitilizeMatrix(int[] dimentions)
    {
        int[,] matrix = new int[dimentions[0], dimentions[1]];
        int counter = 0;
        for (int row = 0; row < dimentions[0]; row++)
        {
            for (int col = 0; col < dimentions[1]; col++)
            {
                matrix[row, col] = counter;
                counter++;
            }
        }
        return matrix;
    }
}