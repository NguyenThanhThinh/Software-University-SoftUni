using System;

class Portal
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[][] matrix = new string[n][];
        int counter = 0;
        int[] startCell = new int[2];
        int[] currentCell = new int[2];

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            matrix[i] = new string[input.Length];
            for (int p = 0; p < input.Length; p++)
            {
                matrix[i][p] = input[p].ToString();
                if (input[p].Equals('S'))
                {
                    startCell[0] = i;
                    startCell[1] = p;
                }
            }
        }

        var directions = Console.ReadLine();
        currentCell = startCell;

        for (int i = 0; i < directions.Length; i++)
        {
            switch (directions[i])
            {
                case 'D':
                    if (MoveDown(matrix, currentCell))
                    {
                        counter++;
                        Console.WriteLine($"Experiment successful. {counter} turns required.");
                        return;
                    }
                    counter++;
                    break;
                case 'U':
                    if (MoveUp(matrix, currentCell))
                    {
                        counter++;
                        Console.WriteLine($"Experiment successful. {counter} turns required.");
                        return;
                    }
                    counter++;
                    break;
                case 'R':
                    if (MoveRight(matrix, currentCell))
                    {
                        counter++;
                        Console.WriteLine($"Experiment successful. {counter} turns required.");
                        return;
                    }
                    counter++;
                    break;
                case 'L':
                    if (MoveLeft(matrix, currentCell))
                    {
                        counter++;
                        Console.WriteLine($"Experiment successful. {counter} turns required.");
                        return;
                    }
                    counter++;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine($"Robot stuck at {currentCell[0]} {currentCell[1]}. Experiment failed.");
    }

    private static bool MoveLeft(string[][] matrix, int[] currentCell)
    {
        int row = currentCell[0];
        int col = currentCell[1];
        string symbol = string.Empty;

        if (col - 1 >= 0)
        {
            symbol = matrix[row][col - 1];

            if (symbol == "E")
            {
                return true;
            }
            else
            {
                currentCell[1] = col - 1;
            }
        }
        else
        {
            col = matrix[row].GetLength(1) - 1;
            symbol = matrix[row][col - 1];

            if (symbol == "E")
            {
                return true;
            }
            else
            {
                currentCell[1] = col - 1;
            }
        }
        return false;
    }

    private static bool MoveRight(string[][] matrix, int[] currentCell)
    {
        int row = currentCell[0];
        int col = currentCell[1];
        string symbol = string.Empty;
        int iterations = 1;

        if (matrix[row].Length > col + iterations)
        {
            symbol = matrix[row][col + iterations];

            if (symbol == "E")
            {
                return true;
            }
            else
            {
                currentCell[1] = col + iterations;
            }
        }
        else
        {
            col = 0;
            symbol = matrix[row][col];
            if (symbol == "E")
            {
                return true;
            }
            else
            {
                currentCell[1] = col;
            }
        }
        return false;
    }

    private static bool MoveUp(string[][] matrix, int[] currentCell)
    {
        int row = currentCell[0];
        int col = currentCell[1];
        string symbol = string.Empty;
        int iterations = 1;

        while (true)
        {
            if (row - iterations >= 0)
            {
                if (matrix[row - iterations].Length > col)
                {
                    symbol = matrix[row - iterations][col];

                    if (symbol == "E")
                    {
                        return true;
                    }
                    else
                    {
                        currentCell[0] = row - iterations;
                    }
                    break;
                }
                iterations++;
            }
            else
            {
                row = matrix.GetLength(0) - 1;
                iterations = 1;
                if (matrix[row].Length > col)
                {
                    symbol = matrix[row][col];

                    if (symbol == "E")
                    {
                        return true;
                    }
                    else
                    {
                        currentCell[0] = row;
                    }
                    break;
                }
            }
        }
        return false;
    }

    private static bool MoveDown(string[][] matrix, int[] currentCell)
    {
        int row = currentCell[0];
        int col = currentCell[1];
        string symbol = string.Empty;
        int iterations = 1;

        while (true)
        {
            if (matrix.GetLength(0) > row + iterations)
            {
                if (matrix[row + iterations].Length > col)
                {
                    symbol = matrix[row + iterations][col];

                    if (symbol == "E")
                    {
                        return true;
                    }
                    else
                    {
                        currentCell[0] = row + iterations;
                    }
                    break;
                }
                iterations++;
            }
            else
            {
                row = 0;
                iterations = 1;
                if (matrix[row].Length > col)
                {
                    symbol = matrix[row][col];

                    if (symbol == "E")
                    {
                        return true;
                    }
                    else
                    {
                        currentCell[0] = row;
                    }
                    break;
                }
            }
        }
        return false;
    }
}