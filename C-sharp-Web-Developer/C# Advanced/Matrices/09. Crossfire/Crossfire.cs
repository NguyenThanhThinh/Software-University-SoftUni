using System;
using System.Collections.Generic;
using System.Linq;

public class Crossfire
{
    private const string space = " ";
    public static int[] rowCol = new int[2];

    public static void Main()
    {
        rowCol = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();
        var matrix = new List<List<string>>();
        InitilizeMatrix(rowCol, matrix);

        var input = Console.ReadLine();

        while (!input.Equals("Nuke it from orbit"))
        {
            var command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            MakeDamageToTheMatrix(matrix, command);

            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].TrueForAll(a => a.Equals(space)))
                {
                    matrix.RemoveAt(i);
                    i--;
                }
                else
                {
                    matrix[i].RemoveAll(n => n.Equals(space));
                }
            }

            input = Console.ReadLine();
        }

        PrintFinalMatrix(matrix);
    }

    private static void PrintFinalMatrix(List<List<string>> matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    private static void MakeDamageToTheMatrix(List<List<string>> matrix, int[] command)
    {
        int row = command[0];
        int col = command[1];
        int radius = command[2];

        bool inMatrix = IsTargetInTheMatrix(row, col, matrix);

        if (inMatrix)
        {
            TargetIsInMatrixMakeDamage(matrix, row, col, radius, "");
        }
        else
        {
            TargetIsOutsideOfMatrixRangeMakeDamage(matrix, row, col, radius);
        }
    }

    private static void TargetIsOutsideOfMatrixRangeMakeDamage(List<List<string>> matrix, int givenRow, int givenCol, int radius)
    {
        int row = givenRow;
        int col = givenCol;
        int newRadius = 0;

        string side = OnWhichSideIsTargetLocated(row, col, matrix);

        if (side.Equals("inMatrixButMayBeOnEmptyCell"))
        {
            TargetIsInMatrixMakeDamage(matrix, row, col, radius, side);
        }

        switch (side)
        {
            case "top":
                newRadius = 1 + (radius + row);
                if (newRadius > 0)
                {
                    TargetIsInMatrixMakeDamage(matrix, 0, col, newRadius, side);
                }
                break;
            case "down":
                newRadius = radius - (row - matrix.Count);
                if (newRadius > 0)
                {
                    TargetIsInMatrixMakeDamage(matrix, matrix.Count - 1, col, newRadius, side);
                }
                break;
            case "left":
                newRadius = 1 + (radius + col);
                if (newRadius > 0)
                {
                    TargetIsInMatrixMakeDamage(matrix, row, 0, newRadius, side);
                }
                break;
            case "right":
                newRadius = radius - (col - matrix[0].Count);
                if (newRadius > 0)
                {
                    TargetIsInMatrixMakeDamage(matrix, row, matrix[0].Count, newRadius, side);
                }
                break;
        }
    }

    private static string OnWhichSideIsTargetLocated(int row, int col, List<List<string>> matrix)
    {
        if (row < 0 && col >= 0 && col < matrix[0].Count)
        {
            return "top";
        }
        if (row >= matrix.Count && col >= 0 && col < matrix[0].Count)
        {
            return "down";
        }
        if (col < 0 && row >= 0 && row < matrix.Count)
        {
            return "left";
        }
        if (col >= matrix[0].Count)
        {
            return "right";
        }
        if (row >= 0 && row < rowCol[0] && col >= 0 && col < rowCol[1])
        {
            return "inMatrixButMayBeOnEmptyCell";
        }

        return "can't do damage to matrix";
    }

    private static void TargetIsInMatrixMakeDamage(List<List<string>> matrix, int givenRow, int givenCol, int radius, string side)
    {
        int moves = 0;
        int row = givenRow;
        int col = givenCol;

        //moves to left / making all these logical checks in all While's, except for the "moves", because if I'm outside the matrix
        //I can do damage just on one direction, so when I start at row/col = 0 I need to go through just one While, not all of them
        while (moves <= radius && side != "left" && side != "top" && side != "down")
        {
            if (IsTargetInTheMatrix(row, col, matrix))
            {
                matrix[row][col] = space;
            }
            col--;
            moves++;
        }
        moves = 0;
        col = givenCol;

        //moves to right
        while (moves <= radius && side != "right" && side != "top" && side != "down")
        {
            if (IsTargetInTheMatrix(row, col, matrix))
            {
                matrix[row][col] = space;
            }
            col++;
            moves++;
        }
        moves = 0;
        col = givenCol;

        //moves to up
        while (moves <= radius && side != "left" && side != "top" && side != "right")
        {
            if (IsTargetInTheMatrix(row, col, matrix))
            {
                matrix[row][col] = space;
            }
            row--;
            moves++;
        }
        moves = 0;
        row = givenRow;

        //moves to down
        while (moves <= radius && side != "left" && side != "right" && side != "down")
        {
            if (IsTargetInTheMatrix(row, col, matrix))
            {
                matrix[row][col] = space;
            }
            row++;
            moves++;
        }
    }

    private static bool IsTargetInTheMatrix(int row, int col, List<List<string>> matrix)
    {
        if (row < 0 || row >= matrix.Count || col < 0 || col >= matrix[row].Count)
        {
            return false;
        }

        return true;
    }

    private static void InitilizeMatrix(int[] rowCol, List<List<string>> matrix)
    {
        int index = 1;

        for (int row = 0; row < rowCol[0]; row++)
        {
            matrix.Add(new List<string>());
            for (int col = 0; col < rowCol[1]; col++)
            {
                matrix[row].Add(index.ToString());
                index++;
            }
        }
    }
}