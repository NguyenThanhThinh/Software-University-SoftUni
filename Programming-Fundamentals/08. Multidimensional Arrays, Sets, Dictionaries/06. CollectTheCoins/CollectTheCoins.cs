using System;
using System.Collections.Generic;

class CollectTheCoins
{
    static void Main()
    {
        List<string> matrix = new List<string>();

        for (int i = 0; i < 4; i++)
        {
            matrix.Add(Console.ReadLine());
        }

        string moves = Console.ReadLine();
        int row = 0;
        int col = 0;
        int coins = 0;
        int wallHits = 0;

        for (int i = 0; i < moves.Length; i++)
        {
            if (moves[i] == 'V')
            {
                row++;
                if (row >= matrix.Count)
                {
                    row--;
                    wallHits++;
                }
                else if (col >= matrix[row].Length)
                {
                    row--;
                    wallHits++;
                }
                else
                {
                    if (matrix[row][col] == '$')
                    {
                        coins++;
                    }
                }
            }
            else if (moves[i] == '^')
            {
                row--;
                if (row < 0)
                {
                    row++;
                    wallHits++;
                }
                else if (col >= matrix[row].Length)
                {
                    row++;
                    wallHits++;
                }
                else
                {
                    if (matrix[row][col] == '$')
                    {
                        coins++;
                    }
                }       
            }
            else if (moves[i] == '>')
            {
                col++;
                if (col >= matrix[row].Length)
                {
                    col--;
                    wallHits++;
                }
                else
                {
                    if (matrix[row][col] == '$')
                    {
                        coins++;
                    }
                }
            }
            else
            {
                col--;
                if (col < 0)
                {
                    col++;
                    wallHits++;
                }
                else
                {
                    if (matrix[row][col] == '$')
                    {
                        coins++;
                    }
                }
            }
        }
        Console.WriteLine("\nCoins collected: {0}\n", coins);
        Console.WriteLine("Walls hit: {0}\n", wallHits);
    }
}