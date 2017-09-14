using System;
using System.Linq;

public class BunkerBuster
{
    public static void Main()
    {
        var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] field = new int[dimentions[0]][];
        int destroyed = 0;

        for (int i = 0; i < dimentions[0]; i++)
        {
            field[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        var input = Console.ReadLine();
        while (!input.Equals("cease fire!"))
        {
            var bombCoordinate = input.Split();
            int bombRow = int.Parse(bombCoordinate[0]);
            int bombCol = int.Parse(bombCoordinate[1]);
            int bombPower = bombCoordinate[2][0];

            HitFieldWithCurrentBomb(field, bombRow, bombCol, bombPower, ref destroyed);
            input = Console.ReadLine();
        }
        Console.WriteLine($"Destroyed bunkers: {destroyed}");
        Console.WriteLine($"Damage done: {((decimal)destroyed / (dimentions[0] * dimentions[1])) * 100:F1} %");
    }

    private static void HitFieldWithCurrentBomb(int[][] field, int bombRow, int bombCol, int bombPower, ref int destroyed)
    {
        var halfBombPower = (int)Math.Ceiling(bombPower / 2d);

        if (IsItInTheField(bombRow, bombCol, field))
            if (field[bombRow][bombCol] > 0)
                field[bombRow][bombCol] -= bombPower;
                if (field[bombRow][bombCol] <= 0)
                    destroyed++;

        if (IsItInTheField(bombRow, bombCol - 1, field))
            if (field[bombRow][bombCol - 1] > 0)
                ChangeValueOfCurrentCell(bombRow, bombCol - 1, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow, bombCol + 1, field))
            if (field[bombRow][bombCol + 1] > 0)
                ChangeValueOfCurrentCell(bombRow, bombCol + 1, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow - 1, bombCol, field))
            if (field[bombRow - 1][bombCol] > 0)
                ChangeValueOfCurrentCell(bombRow - 1, bombCol, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow - 1, bombCol - 1, field))
            if (field[bombRow - 1][bombCol - 1] > 0)
                ChangeValueOfCurrentCell(bombRow - 1, bombCol - 1, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow - 1, bombCol + 1, field))
            if (field[bombRow - 1][bombCol + 1] > 0)
                ChangeValueOfCurrentCell(bombRow - 1, bombCol + 1, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow + 1, bombCol, field))
            if (field[bombRow + 1][bombCol] > 0)
                ChangeValueOfCurrentCell(bombRow + 1, bombCol, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow + 1, bombCol - 1, field))
            if (field[bombRow + 1][bombCol - 1] > 0)
                ChangeValueOfCurrentCell(bombRow + 1, bombCol - 1, field, ref destroyed, halfBombPower);

        if (IsItInTheField(bombRow + 1, bombCol + 1, field))
            if (field[bombRow + 1][bombCol + 1] > 0)
                ChangeValueOfCurrentCell(bombRow + 1, bombCol + 1, field, ref destroyed, halfBombPower);
    }

    private static void ChangeValueOfCurrentCell(int bombRow, int bombCol, int[][] field, ref int destroyed, int halfBombPower)
    {
        field[bombRow][bombCol] -= halfBombPower;
        destroyed += field[bombRow][bombCol] > 0 ? 0 : 1;
    }

    private static bool IsItInTheField(int bombRow, int bombCol, int[][] field)
    {
        if (bombRow >= 0 && bombCol >= 0 && bombRow < field.GetLength(0) && bombCol < field[0].Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}