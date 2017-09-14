using System;
using System.Linq;

public class ItVillage
{
    private static int currentRow = 0;
    private static int currentCol = 0;
    private static int inn = 0;
    private static int skip = 0;
    private static bool win = false;

    public static void Main()
    {
        int coins = 50;
        var inputRows = Console.ReadLine().Split('|').Select(a => a.Trim()).ToArray();
        char[][] field = InitilizeField(inputRows);
        var startInput = Console.ReadLine().Split();
        currentRow = int.Parse(startInput[0].Trim()) - 1;
        currentCol = int.Parse(startInput[1].Trim()) - 1;
        var moves = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int innInGame = FindInnInGame(field);

        for (int i = 0; i < moves.Length; i++)
        {
            if (inn > 0)
            {
                coins += inn * 20;
            }
            skip = 0;
            int move = moves[i];
            CalculateNextPosition(move, field);
            CheckWhatTheCellIsAndPerformAction(field, ref coins);
            i += skip;
            if (win)
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                break;
            }
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                break;
            }
            if (inn == innInGame)
            {
                Console.WriteLine($"<p>You won! You own the village now! You have {coins} coins!<p>");
                break;
            }
            if (i + 1 >= moves.Length)
            {
                Console.WriteLine($"<p>You lost! No more moves! You have {coins} coins!<p>");
            }
        }
    }

    private static int FindInnInGame(char[][] field)
    {
        int counter = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (field[row][col].Equals('I'))
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    private static void CheckWhatTheCellIsAndPerformAction(char[][] field, ref int coins)
    {
        switch (field[currentRow][currentCol])
        {
            case 'P':
                coins -= 5;
                break;
            case 'I':
                if (coins >= 100)
                {
                    coins -= 100;
                    inn++;
                }
                else
                {
                    coins -= 10;
                }
                break;
            case 'F':
                coins += 20;
                break;
            case 'S':
                skip = 2;
                break;
            case 'V':
                coins *= 10;
                break;
            case 'N':
                win = true;
                break;
        }
    }

    private static void CalculateNextPosition(int move, char[][] field)
    {
        while (move != 0)
        {
            if (currentRow > 0 && currentCol == 0)
            {
                currentRow--;
            }
            else if (currentRow < 3 && currentCol == 3)
            {
                currentRow++;
            }
            else if (currentRow == 0 && currentCol < 3)
            {
                currentCol++;
            }
            else if (currentRow == 3 && currentCol > 0)
            {
                currentCol--;
            }
            move--;
        }
    }

    private static char[][] InitilizeField(string[] inputRows)
    {
        char[][] array = new char[4][];
        int colArray = 0;

        for (int row = 0; row < inputRows.Length; row++)
        {
            array[row] = new char[4]; 
            for (int col = 0; col < inputRows[row].Length; col++)
            {
                if (!inputRows[row][col].Equals(' '))
                {
                    array[row][colArray] = inputRows[row][col];
                    colArray++;
                }
            }
            colArray = 0;
        }
        return array;
    }
}