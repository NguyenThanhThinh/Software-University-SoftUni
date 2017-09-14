using System;

class FillTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int number = 1;
        int[,] matrix = new int[n, n];

        for (int cow = 0; cow < n; cow++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, cow] = number;
                number++;
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int cow = 0; cow < n; cow++)
            {
                Console.Write("{0, 4} ", matrix[row,cow]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}