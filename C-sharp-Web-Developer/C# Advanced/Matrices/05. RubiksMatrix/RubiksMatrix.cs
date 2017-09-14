using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ProblemsWithMatrices
{
    static void Main(string[] args)
    {
        var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var commandsCounter = int.Parse(Console.ReadLine());
        int row;
        int col;
        int moves;
        var matrix = new List<List<int>>();
        GenerateMatrix(matrix, rowAndCol);
        var result = new StringBuilder();
        bool rowOrNot = true;

        for (int i = 0; i < commandsCounter; i++)
        {
            var command = Console.ReadLine().Split();
            var direction = command[1];
            moves = int.Parse(command[2]);

            if (direction.Equals("left") || direction.Equals("right"))
            {
                row = int.Parse(command[0]);
                ShuffleMatrix(matrix, row, direction, moves, rowOrNot);
            }
            else
            {
                rowOrNot = false;
                col = int.Parse(command[0]);
                ShuffleMatrix(matrix, col, direction, moves, rowOrNot);
                rowOrNot = true;
            }
        }
        RearrangeMatrix(result, matrix);
        Console.WriteLine(result.ToString());
    }

    public static void RearrangeMatrix(StringBuilder result, List<List<int>> matrix)
    {
        int rows = matrix.Count;
        int cols;
        for (int i = 0; i < rows; i++)
        {
            cols = matrix[i].Count;
            for (int j = 0; j < cols; j++)
            {
                int initValue = i * cols + (j + 1);
                int currentValue = matrix[i][j];

                if (initValue != currentValue)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        var currentRow = matrix[k].ToArray();
                        int index = Array.IndexOf(currentRow, initValue);
                        if (index > -1)
                        {
                            matrix[k][index] = currentValue;
                            matrix[i][j] = initValue;
                            Console.WriteLine($"Swap ({i}, {j}) with ({k}, {index})");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No swap required");
                }
            }
        }
    }

    private static void ShuffleMatrix(List<List<int>> matrix, int rowOrCol, string direction, int moves, bool rowOrNot)
    {
        if (rowOrNot)
        {
            switch (direction)
            {
                case "left":
                    MoveRowToLeft(matrix, rowOrCol, moves);
                    break;
                case "right":
                    MoveRowToRight(matrix, rowOrCol, moves);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case "up":
                    MoveColUp(matrix, rowOrCol, moves);
                    break;
                case "down":
                    MoveColDown(matrix, rowOrCol, moves);
                    break;
                default:
                    break;
            }
        }
    }

    private static void MoveColDown(List<List<int>> matrix, int rowOrCol, int moves)
    {
        int holder;
        int col = rowOrCol;
        List<int> currentCol = new List<int>();

        for (int i = 0; i < matrix.Count; i++)
        {
            currentCol.Add(matrix[i][col]);
        }
        int lastIndex = currentCol.Count - 1;

        for (int i = 0; i < moves; i++)
        {
            holder = currentCol[lastIndex];
            currentCol.RemoveAt(lastIndex);
            currentCol.Insert(0, holder);
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i][col] = currentCol[i];
        }
    }

    private static void MoveColUp(List<List<int>> matrix, int rowOrCol, int moves)
    {
        int holder;
        int col = rowOrCol;
        List<int> currentCol = new List<int>();

        for (int i = 0; i < matrix.Count; i++)
        {
            currentCol.Add(matrix[i][col]);
        }

        for (int i = 0; i < moves; i++)
        {
            holder = currentCol[0];
            currentCol.RemoveAt(0);
            currentCol.Add(holder);
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i][col] = currentCol[i];
        }
    }

    private static void MoveRowToRight(List<List<int>> matrix, int row, int moves)
    {
        int holder = 0;
        int lastIndex = matrix[row].Count - 1;
        for (int i = 0; i < moves; i++)
        {
            holder = matrix[row][lastIndex];
            matrix[row].RemoveAt(lastIndex);
            matrix[row].Insert(0, holder);
        }
    }

    private static void MoveRowToLeft(List<List<int>> matrix, int row, int moves)
    {
        int holder = 0;
        for (int i = 0; i < moves; i++)
        {
            holder = matrix[row][0];
            matrix[row].RemoveAt(0);
            matrix[row].Add(holder);
        }
    }

    private static void GenerateMatrix(List<List<int>> matrix, int[] rowAndCol)
    {
        int num = 1;

        for (int row = 0; row < rowAndCol[0]; row++)
        {
            matrix.Add(new List<int>());
            for (int col = 0; col < rowAndCol[1]; col++)
            {
                matrix[row].Add(num);
                num++;
            }
        }
    }
}