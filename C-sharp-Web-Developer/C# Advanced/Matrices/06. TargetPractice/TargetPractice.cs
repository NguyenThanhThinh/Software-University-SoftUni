using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    static void Main(string[] args)
    {
        var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = dimensions[0];
        int col = dimensions[1];
        var matrix = new string[row][];
        string snake = Console.ReadLine();
        var shotParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

        FillMatrix(matrix, snake, col, row);
        ReplaceAllOutsideOfRadiusChars(matrix, shotParameters);

        //this is when the radius is == 0, so we just change the shot index to " "
        if (shotParameters[2] == 0)
        {
            matrix[shotParameters[0]][shotParameters[1]] = " ";
        }

        FallDownCharacters(matrix, row, col);

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Console.Write(matrix[r][c]);
            }
            Console.WriteLine();
        }
    }

    private static void FallDownCharacters(string[][] matrix, int row, int col)
    {
        var currentCol = new List<string>();

        for (int i = 0; i < col; i++)
        {
            for (int p = 0; p < row; p++)
            {
                var currentSymbol = matrix[p][i];
                if (currentSymbol != " ")
                {
                    currentCol.Add(currentSymbol);
                }
            }

            int currentIndexOfCurrentCol = currentCol.Count - 1;
            for (int c = row - 1; c >= 0; c--)
            {
                if (currentIndexOfCurrentCol >= 0)
                {
                    matrix[c][i] = currentCol[currentIndexOfCurrentCol];
                    currentIndexOfCurrentCol--;
                }
                else
                {
                    matrix[c][i] = " ";
                }
            }
            currentCol.Clear();
        }
    }

    private static void ReplaceAllOutsideOfRadiusChars(string[][] matrix, int[] shotParameters)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int p = 0; p < matrix[i].Length; p++)
            {
                if (PointInACircle(shotParameters, i, p))
                {
                    matrix[i][p] = " ";
                }
            }
        }
    }

    private static bool PointInACircle(int[] shotParameters, double x, double y)
    {
        var impactRow = shotParameters[0];
        var impactCol = shotParameters[1];
        var radius = shotParameters[2];
        double d = Math.Pow((x - impactRow), 2) + Math.Pow((y - impactCol), 2);

        if (d > radius * radius)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static void FillMatrix(string[][] matrix, string snake, int col, int row)
    {
        int n = 0;
        int currentIndex = 0;
        for (int i = row - 1; i >= 0; i--, n++)
        {
            matrix[i] = new string[col];
            if (n % 2 == 0)
            {
                for (int p = col - 1; p >= 0; p--)
                {
                    matrix[i][p] = snake[currentIndex].ToString();
                    currentIndex++;
                    if (currentIndex == snake.Length)
                    {
                        currentIndex = 0;
                    }
                }
            }
            else
            {
                for (int p = 0; p < col; p++)
                {
                    matrix[i][p] = snake[currentIndex].ToString();
                    currentIndex++;
                    if (currentIndex == snake.Length)
                    {
                        currentIndex = 0;
                    }
                }
            }
        }
    }
}