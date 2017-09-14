using System;
using System.Linq;
using System.Security;

public class TextGravity
{
    private const char space = ' ';
    private static char[] invalidChars = new char[] { '<', '>', '&', '\"', '\'' };

    public static void Main()
    {
        int lineLenght = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        var rows = input.Length / lineLenght;
        if (input.Length % lineLenght != 0)
        {
            rows++;
        }
        var text = new char[rows, lineLenght];

        InitilizeArrayText(lineLenght, input, text);

        DropTextRowDown(text);

        PrintModifiedText(text);
    }

    private static void PrintModifiedText(char[,] text)
    {
        Console.Write("<table>");

        for (int row = 0; row < text.GetLength(0); row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < text.GetLength(1); col++)
            {
                if (invalidChars.Contains(text[row, col]))
                {
                    string xmlText = SecurityElement.Escape(text[row, col].ToString());
                    Console.Write($"<td>{xmlText}</td>");
                }
                else
                {
                    Console.Write($"<td>{text[row, col]}</td>");
                }
            }
            Console.Write("</tr>");
        }
        Console.WriteLine("</table>");
    }

    private static void DropTextRowDown(char[,] text)
    {
        char aboveCell = space;
        int moveRow = 0;

        for (int row = text.GetLength(0) - 1; row >= 1; row--)
        {
            moveRow = row - 1;
            for (int col = 0; col < text.GetLength(1); col++)
            {
                var cell = text[row, col];
                if (cell.Equals(space))
                {
                    aboveCell = text[moveRow, col];
                    while (moveRow - 1 >= 0 && aboveCell.Equals(space))
                    {
                        moveRow--;
                        aboveCell = text[moveRow, col];
                    }
                    text[row, col] = aboveCell;
                    text[moveRow, col] = space;
                    moveRow = row - 1;
                }
            }
        }
    }

    private static void InitilizeArrayText(int lineLenght, string input, char[,] text)
    {
        int row = 0;
        int col = 0;

        for (int i = 0; i < input.Length; i++)
        {
            text[row, col] = input[i];
            col++;
            if (col == lineLenght)
            {
                col = 0;
                row++;
            }
        }
        if (col != 0)
        {
            while (col != lineLenght)
            {
                text[row, col] = ' ';
                col++;
            }
        }
    }
}