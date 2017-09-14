using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<int>());
            matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToList();
        }

        string input = Console.ReadLine();
        var command = string.Empty;
        var removeType = string.Empty;
        var removePositionRowCol = string.Empty;
        var removePositionIndex = 0;

        var swap = new int[2];

        var insert = new int[2];

        while (input != "end")
        {
            var splitInput = input.Split();
            command = splitInput[0];

            switch (command)
            {
                case "remove":
                    removeType = splitInput[1];
                    removePositionRowCol = splitInput[2];
                    removePositionIndex = int.Parse(splitInput[3]);
                    RemoveElementsFromMatrix(matrix, removeType, removePositionRowCol, removePositionIndex);
                    break;
                case "swap":
                    swap[0] = int.Parse(splitInput[1]);
                    swap[1] = int.Parse(splitInput[2]);
                    SwapRowsInMatrix(matrix, swap);
                    break;
                case "insert":
                    insert[0] = int.Parse(splitInput[1]);
                    insert[1] = int.Parse(splitInput[2]);
                    InsertGivenNumInMatrix(matrix, insert);
                    break;
                default:
                    break;
            }
            input = Console.ReadLine();
        }

        Console.WriteLine();
        PrintMatrix(matrix);
    }

    private static void PrintMatrix(List<List<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }

    private static void InsertGivenNumInMatrix(List<List<int>> matrix, int[] insert)
    {
        int row = insert[0];
        int number = insert[1];
        matrix[row].Insert(0, number);
    }

    private static void SwapRowsInMatrix(List<List<int>> matrix, int[] swap)
    {
        int rowOne = swap[0];
        int rowTwo = swap[1];
        var rowOneBackUp = new int[matrix[rowOne].Count];
        matrix[rowOne].CopyTo(rowOneBackUp);

        matrix[rowOne] = matrix[rowTwo];
        matrix[rowTwo] = rowOneBackUp.ToList();
    }

    private static void RemoveElementsFromMatrix(List<List<int>> matrix, string removeType, string removePositionRowCol, int removePositionIndex)
    {
        if (removePositionRowCol == "row")
        {
            int row = removePositionIndex;
            switch (removeType)
            {
                case "positive":
                    matrix[row].RemoveAll(n => n >= 0);
                    break;
                case "negative":
                    matrix[row].RemoveAll(n => n < 0);
                    break;
                case "odd":
                    matrix[row].RemoveAll(n => n % 2 != 0);
                    break;
                case "even":
                    matrix[row].RemoveAll(n => n % 2 == 0);
                    break;
                default:
                    break;
            }
        }
        else
        {
            int col = removePositionIndex;
            RemoveElementsFromColAtMatrix(matrix, removeType, col);
        }
    }

    private static void RemoveElementsFromColAtMatrix(List<List<int>> matrix, string removeType, int col)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            switch (removeType)
            {
                case "positive":
                    if (matrix[i].Count - 1 >= col && matrix[i][col] >= 0)
                    {
                        matrix[i].RemoveAt(col);
                    }
                    break;
                case "negative":
                    if (matrix[i].Count - 1 >= col && matrix[i][col] < 0)
                    {
                        matrix[i].RemoveAt(col);
                    }
                    break;
                case "odd":
                    if (matrix[i].Count - 1 >= col && matrix[i][col] % 2 != 0)
                    {
                        matrix[i].RemoveAt(col);
                    }
                    break;
                case "even":
                    if (matrix[i].Count - 1 >= col && matrix[i][col] % 2 == 0)
                    {
                        matrix[i].RemoveAt(col);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}