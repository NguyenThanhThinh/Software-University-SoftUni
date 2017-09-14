using System;
using System.Text;
using System.Linq;

public class MatrixShuffle
{
    public static char[] punctuationSigns = new char[] { ' ', '.', '!', '?', ',', '\'' };

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var input = Console.ReadLine();

        char[,] spiralMatrix = new char[n, n];
        int index = 0;
        int manipulateMoves = 0;

        int globalCol = 0;
        int globalRow = 0;

        while (index < n * n)
        {
            for (int col = 0; col < spiralMatrix.GetLength(1) - manipulateMoves; globalCol++, col++, index++)
            {
                spiralMatrix[globalRow, globalCol] = input[index];
            }

            manipulateMoves++;

            for (int row = 0; row < spiralMatrix.GetLength(0) - manipulateMoves; globalRow++, row++, index++)
            {
                spiralMatrix[globalRow + 1, globalCol - 1] = input[index];
            }
            globalCol--;

            for (int col = 0; col < spiralMatrix.GetLength(1) - manipulateMoves; globalCol--, col++, index++)
            {
                spiralMatrix[globalRow, globalCol - 1] = input[index];
            }

            manipulateMoves++;

            for (int row = 0; row < spiralMatrix.GetLength(0) - manipulateMoves; globalRow--, row++, index++)
            {
                spiralMatrix[globalRow - 1, globalCol] = input[index];
            }
            globalCol++;
        }

        var formedString = new StringBuilder();
        ChessboardPattern(formedString, spiralMatrix);

        if (IsPalindrome(formedString))
        {
            Console.WriteLine($"<div style='background-color:#4FE000'>{formedString.ToString()}</div>");
        }
        else
        {
            Console.WriteLine($"<div style='background-color:#E0000F'>{formedString.ToString()}</div>");
        }
    }

    private static bool IsPalindrome(StringBuilder formedString)
    {
        var formedStringWithoutSpaces = RemoveSpaces(formedString);
        int n = formedStringWithoutSpaces.Length;

        for (int i = 0; i < (n / 2); ++i)
        {
            if (char.ToLower(formedStringWithoutSpaces[i]) != char.ToLower(formedStringWithoutSpaces[n - i - 1]))
            {
                return false;
            }
        }
        return true;
    }

    private static string RemoveSpaces(StringBuilder formedString)
    {
        var stringWithoutSpaces = new StringBuilder();

        for (int i = 0; i < formedString.Length; i++)
        {
            if (!punctuationSigns.Contains(formedString[i]))
            {
                stringWithoutSpaces.Append(formedString[i]);
            }
        }
        return stringWithoutSpaces.ToString();
    }

    private static void ChessboardPattern(StringBuilder formedString, char[,] spiralMatrix)
    {
        int manipulateCol = 0;
        char currentChar = ' ';

        for (int row = 0; row < spiralMatrix.GetLength(0); row++)
        {
            for (int col = manipulateCol; col < spiralMatrix.GetLength(1); col += 2)
            {
                currentChar = spiralMatrix[row, col];
                if (char.IsLetter(currentChar) || punctuationSigns.Contains(currentChar))
                {
                    formedString.Append(currentChar);
                }
            }
            if (manipulateCol == 0)
            {
                manipulateCol = 1;
            }
            else
            {
                manipulateCol = 0;
            }
        }

        manipulateCol = 1;
        for (int row = 0; row < spiralMatrix.GetLength(0); row++)
        {
            for (int col = manipulateCol; col < spiralMatrix.GetLength(1); col += 2)
            {
                currentChar = spiralMatrix[row, col];
                if (char.IsLetter(currentChar) || punctuationSigns.Contains(currentChar))
                {
                    formedString.Append(spiralMatrix[row, col]);
                }
            }
            if (manipulateCol == 0)
            {
                manipulateCol = 1;
            }
            else
            {
                manipulateCol = 0;
            }
        }
    }
}