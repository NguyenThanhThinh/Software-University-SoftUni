using System;
using System.Linq;

public class DengarousFloor
{
    public static void Main()
    {
        var board = new string[8][];

        for (int i = 0; i < 8; i++)
        {
            board[i] = new string[8];
            board[i] = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }


        var command = Console.ReadLine();

        while (command != "END")
        {
            var symbol = command[0];
            var currentRow = int.Parse(command[1].ToString());
            var currentCol = int.Parse(command[2].ToString());
            var nextRow = int.Parse(command[4].ToString());
            var nextCol = int.Parse(command[5].ToString());

            if (!CheckIfThereIsSuchPiece(symbol, currentRow, currentCol, board))
            {
                Console.WriteLine("There is no such a piece!");
                command = Console.ReadLine();
                continue;
            }

            if (!CheckIfMoveIsValid(board, currentRow, currentCol, nextRow, nextCol))
            {
                Console.WriteLine("Invalid move!");
                command = Console.ReadLine();
                continue;
            }

            if (CheckIfMoveGoOutOfBoard(board, currentRow, currentCol, nextRow, nextCol))
            {
                Console.WriteLine("Move go out of board!");
                command = Console.ReadLine();
                continue;
            }

            board[currentRow][currentCol] = "x";
            board[nextRow][nextCol] = symbol.ToString();
            command = Console.ReadLine();
        }
    }

    private static bool CheckIfMoveGoOutOfBoard(string[][] board, int currentRow, int currentCol, int nextRow, int nextCol)
    {
        if (nextRow >= 8 || nextRow < 0 || nextCol < 0 || nextCol >= 8)
        {
            return true;
        }
        return false;
    }

    private static bool CheckIfMoveIsValid(string[][] board, int currentRow, int currentCol, int nextRow, int nextCol)
    {
        switch (board[currentRow][currentCol])
        {
            case "K":
                if (Math.Abs(nextRow - currentRow) > 1 || Math.Abs(nextCol - currentCol) > 1)
                {
                    return false;
                }
                break;
            case "R":
                if (currentRow != nextRow && currentCol != nextCol)
                {
                    return false;
                }
                break;
            case "B":
                if (Math.Abs(currentRow - nextRow) != Math.Abs(currentCol - nextCol))
                {
                    return false;
                }
                break;
            case "Q":
                if (currentRow != nextRow && currentCol != nextCol)
                {
                    if (Math.Abs(currentRow - nextRow) != Math.Abs(currentCol - nextCol))
                    {
                        return false;
                    }
                }
                break;
            case "P":
                if (currentRow - 1 != nextRow)
                {
                    return false;
                }
                if (currentCol != nextCol)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    private static bool CheckIfThereIsSuchPiece(char symbol, int currentRow, int currentCol, string[][] board)
    {
        if (board[currentRow][currentCol] != symbol.ToString())
        {
            return false;
        }
        return true;
    }
}