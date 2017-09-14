using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] spiralMatrix = new int[n, n];
        int num = 1;
        int manipulateMoves = 0;

        int globalCol = 0;
        int globalRow = 0;

        while (num <= n * n)
        {
            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < spiralMatrix.GetLength(1) - manipulateMoves; globalCol++, col++, num++)
                {                                                                                           
                    spiralMatrix[globalRow, globalCol] = num;
                }
            }

            manipulateMoves++;
            for (int col = 0; col < 1; col++)
            {
                for (int row = 0; row < spiralMatrix.GetLength(0) - manipulateMoves; globalRow++, row++, num++)
                {
                    spiralMatrix[globalRow + 1, globalCol - 1] = num;
                }
                globalCol--;
            }

            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < spiralMatrix.GetLength(1) - manipulateMoves; globalCol--, col++, num++)
                {
                    spiralMatrix[globalRow, globalCol - 1] = num;
                }
            }

            manipulateMoves++;
            for (int col = 0; col < 1; col++)
            {
                for (int row = 0; row < spiralMatrix.GetLength(0) - manipulateMoves; globalRow--, row++, num++)
                {
                    spiralMatrix[globalRow - 1, globalCol] = num;
                }
                globalCol++;
            }
        }

        for (int row = 0; row < spiralMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < spiralMatrix.GetLongLength(1); col++)
            {
                Console.Write("{0, 6} ", spiralMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}