using System;
using System.Collections.Generic;
using System.Security;

public class ClearingCommands
{
    private static List<string[]> matrix = new List<string[]>();
    private const string space = " ";
    private static int currentRow = 0;
    private static int currentCol = 0;
    private static string currentCell = string.Empty;

    public static void Main()
    {
        var input = Console.ReadLine().Trim();
        string xmlText = string.Empty;
        int index = 0;

        while (!input.Equals("END"))
        {
            matrix.Add(new string[input.Length]);
            for (int i = 0; i < input.Length; i++)
            {
                matrix[index][i] = input[i].ToString();
            }
            index++;
            input = Console.ReadLine().Trim();
        }

        Move();
        Print();
    }

    private static void Print()
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.Write("<p>");
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(matrix[row][col]);
            }
            Console.WriteLine("</p>");
        }
    }

    private static void Move()
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                currentCell = matrix[row][col];
                if (IsThisDirection())
                {
                    currentRow = row;
                    currentCol = col;
                    string xmlText = SecurityElement.Escape(currentCell.ToString());
                    matrix[currentRow][col] = xmlText;
                    MakeParticularMove();
                }
            }
        }
    }

    private static void MakeParticularMove()
    {
        switch (currentCell)
        {
            case ">":
                for (int col = currentCol + 1; col < matrix[0].Length; col++)
                {
                    currentCell = matrix[currentRow][col];
                    if (IsThisDirection() || IsThisChangedDirection())
                    {
                        break;
                    }
                    else if (!currentCell.Equals(space))
                    {
                        matrix[currentRow][col] = space;
                    }
                }
                break;
            case "v":
                for (int row = currentRow + 1; row < matrix.Count; row++)
                {
                    currentCell = matrix[row][currentCol];
                    if (IsThisDirection() || IsThisChangedDirection())
                    {
                        break;
                    }
                    else if (!currentCell.Equals(space))
                    {
                        matrix[row][currentCol] = space;
                    }
                }
                break;
            case "^":
                for (int row = currentRow - 1; row >= 0; row--)
                {
                    currentCell = matrix[row][currentCol];
                    if (IsThisDirection() || IsThisChangedDirection())
                    {
                        break;
                    }
                    else if (!currentCell.Equals(space))
                    {
                        matrix[row][currentCol] = space;
                    }
                }
                break;
            case "<":
                for (int col = currentCol - 1; col >= 0; col--)
                {
                    currentCell = matrix[currentRow][col];
                    if (IsThisDirection() || IsThisChangedDirection())
                    {
                        break;
                    }
                    else if (!currentCell.Equals(space))
                    {
                        matrix[currentRow][col] = space;
                    }
                }
                break;
            default:
                break;
        }
    }

    private static bool IsThisDirection()
    {
        switch (currentCell)
        {
            case ">":
                currentCell = ">";
                return true;
            case "v":
                currentCell = "v";
                return true;
            case "^":
                currentCell = "^";
                return true;
            case "<":
                currentCell = "<";
                return true;
            default:
                return false;
        }
    }

    private static bool IsThisChangedDirection()
    {
        switch (currentCell)
        {
            case "&gt;":
                return true;
            case "&lt;":
                return true;
            default:
                return false;
        }
    }
}