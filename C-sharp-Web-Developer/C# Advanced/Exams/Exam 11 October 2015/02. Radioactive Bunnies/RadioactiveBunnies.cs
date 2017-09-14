using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RadioactiveMutantVampireBunnies
{
    static void Main(string[] args)
    {
        var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var row = dimentions[0];
        var col = dimentions[1];
        var bunnyField = new char[row][];
        int[] currentPlayerRowAndCol = new int[2];
        Queue<int> currentBunniesPositions = new Queue<int>();
        var result = new StringBuilder();

        for (int i = 0; i < row; i++)
        {
            bunnyField[i] = new char[col];
            var line = Console.ReadLine().ToCharArray();
            bunnyField[i] = line;
            if (line.Contains('P'))
            {
                currentPlayerRowAndCol[0] = i;
                currentPlayerRowAndCol[1] = Array.IndexOf(line, 'P');
            }
        }

        var directions = Console.ReadLine();
        bool[] aliveOrEscaped = new bool[] { true, false };
        bool gameEnded = false;

        for (int i = 0; i < directions.Length; i++)
        {
            switch (directions[i])
            {
                case 'U':
                    MovePlayerUp(bunnyField, row, col, currentPlayerRowAndCol, aliveOrEscaped, currentBunniesPositions);
                    break;
                case 'D':
                    MovePlayerDown(bunnyField, row, col, currentPlayerRowAndCol, aliveOrEscaped, currentBunniesPositions);
                    break;
                case 'L':
                    MovePlayerLeft(bunnyField, row, col, currentPlayerRowAndCol, aliveOrEscaped, currentBunniesPositions);
                    break;
                case 'R':
                    MovePlayerRight(bunnyField, row, col, currentPlayerRowAndCol, aliveOrEscaped, currentBunniesPositions);
                    break;
                default:
                    break;
            }
            gameEnded = CheckIfPlayerIsAliveOrEscaped(aliveOrEscaped, currentPlayerRowAndCol, result);
            if (gameEnded)
            {
                break;
            }
        }
        PrintFinalBunnyField(bunnyField, row, col);
        Console.WriteLine(result.ToString());
    }

    private static void MovePlayerRight(char[][] bunnyField, int row, int col, int[] currentPlayerRowAndCol, bool[] aliveOrEscaped, Queue<int> currentBunniesPositions)
    {
        currentBunniesPositions = ALocateCurrentBunniesPositions(bunnyField, row, col);
        SpradeBunnies(currentBunniesPositions, bunnyField, row, col);

        if (currentPlayerRowAndCol[1] + 1 < col)
        {
            if (bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1] + 1] == 'B')
            {
                aliveOrEscaped[0] = false;
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[1]++;
            }
            else
            {
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[1]++;
                bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] = 'P';
            }
        }
        else
        {
            aliveOrEscaped[1] = true;
            MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
        }
    }

    private static void MovePlayerDown(char[][] bunnyField, int row, int col, int[] currentPlayerRowAndCol, bool[] aliveOrEscaped, Queue<int> currentBunniesPositions)
    {
        currentBunniesPositions = ALocateCurrentBunniesPositions(bunnyField, row, col);
        SpradeBunnies(currentBunniesPositions, bunnyField, row, col);

        if (currentPlayerRowAndCol[0] + 1 < row)
        {
            if (bunnyField[currentPlayerRowAndCol[0] + 1][currentPlayerRowAndCol[1]] == 'B')
            {
                aliveOrEscaped[0] = false;
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[0]++;
            }
            else
            {
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[0]++;
                bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] = 'P';
            }
        }
        else
        {
            aliveOrEscaped[1] = true;
            MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
        }
    }

    private static void MovePlayerLeft(char[][] bunnyField, int row, int col, int[] currentPlayerRowAndCol, bool[] aliveOrEscaped,
        Queue<int> currentBunniesPositions)
    {
        currentBunniesPositions = ALocateCurrentBunniesPositions(bunnyField, row, col);
        SpradeBunnies(currentBunniesPositions, bunnyField, row, col);

        if (currentPlayerRowAndCol[1] - 1 >= 0)
        {
            if (bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1] - 1] == 'B')
            {
                aliveOrEscaped[0] = false;
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[1]--;
            }
            else
            {
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[1]--;
                bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] = 'P';
            }
        }
        else
        {
            aliveOrEscaped[1] = true;
            MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
        }
    }

    private static void MovePlayerUp(char[][] bunnyField, int row, int col, int[] currentPlayerRowAndCol, bool[] aliveOrEscaped,
        Queue<int> currentBunniesPositions)
    {
        currentBunniesPositions = ALocateCurrentBunniesPositions(bunnyField, row, col);

        SpradeBunnies(currentBunniesPositions, bunnyField, row, col);

        if (currentPlayerRowAndCol[0] - 1 >= 0)
        {
            if (bunnyField[currentPlayerRowAndCol[0] - 1][currentPlayerRowAndCol[1]] == 'B')
            {
                aliveOrEscaped[0] = false;
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[0]--;
            }
            else
            {
                MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
                currentPlayerRowAndCol[0]--;
                bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] = 'P';
            }
        }
        else
        {
            aliveOrEscaped[1] = true;
            MakeCellDotIfItsNotBunny(bunnyField, currentPlayerRowAndCol);
        }
    }

    private static void MakeCellDotIfItsNotBunny(char[][] bunnyField, int[] currentPlayerRowAndCol)
    {
        if (bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] != 'B')
        {
            bunnyField[currentPlayerRowAndCol[0]][currentPlayerRowAndCol[1]] = '.';
        }
    }

    private static Queue<int> ALocateCurrentBunniesPositions(char[][] bunnyField, int row, int col)
    {
        Queue<int> currentBunniesPositions = new Queue<int>();
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (bunnyField[r][c] == 'B')
                {
                    currentBunniesPositions.Enqueue(r);
                    currentBunniesPositions.Enqueue(c);
                }
            }
        }
        return currentBunniesPositions;
    }

    private static void SpradeBunnies(Queue<int> currentBunniesPositions, char[][] bunnyField, int row, int col)
    {
        while (currentBunniesPositions.Count != 0)
        {
            int currentRow = currentBunniesPositions.Dequeue();
            int currentCol = currentBunniesPositions.Dequeue();

            if (currentRow - 1 >= 0 && bunnyField[currentRow - 1][currentCol] != 'B')
            {
                bunnyField[currentRow - 1][currentCol] = 'B';
            }
            if (currentRow + 1 < row && bunnyField[currentRow + 1][currentCol] != 'B')
            {
                bunnyField[currentRow + 1][currentCol] = 'B';
            }
            if (currentCol - 1 >= 0 && bunnyField[currentRow][currentCol - 1] != 'B')
            {
                bunnyField[currentRow][currentCol - 1] = 'B';
            }
            if (currentCol + 1 < col && bunnyField[currentRow][currentCol + 1] != 'B')
            {
                bunnyField[currentRow][currentCol + 1] = 'B';
            }
        }
    }

    private static bool CheckIfPlayerIsAliveOrEscaped(bool[] aliveOrEscaped, int[] currentPlayerRowAndCol, StringBuilder result)
    {
        if (!aliveOrEscaped[0])
        {
            result.Append($"dead: {currentPlayerRowAndCol[0]} {currentPlayerRowAndCol[1]}");
            return true;
        }
        if (aliveOrEscaped[1])
        {
            result.Append($"won: {currentPlayerRowAndCol[0]} {currentPlayerRowAndCol[1]}");
            return true;
        }
        return false;
    }

    private static void PrintFinalBunnyField(char[][] bunnyField, int row, int col)
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Console.Write(bunnyField[r][c]);
            }
            Console.WriteLine();
        }
    }
}