using System;
using System.Collections.Generic;
using System.Linq;

public class Parachute
{
    public static void Main()
    {
        var line = Console.ReadLine();
        List<char[]> matrix = new List<char[]>();
        int left = 0;
        int right = 0;
        int rowPerson = 0;
        int colPerson = 0;

        while (!line.Equals("END"))
        {
            matrix.Add(line.ToCharArray());
            line = Console.ReadLine();
        }

        FindPersonLocation(matrix, ref rowPerson, ref colPerson);
        rowPerson++;

        for (int i = rowPerson; i < matrix.Count; i++)
        {
            left = matrix[i].Count(l => l.ToString().Equals("<"));
            right = matrix[i].Count(l => l.ToString().Equals(">"));

            if (left == right)
            {
                if (CheckCurrentPosition(matrix, rowPerson, colPerson))
                {
                    break;
                }
            }
            else if (left > right)
            {
                colPerson -= (left - right);
                if (CheckCurrentPosition(matrix, rowPerson, colPerson))
                {
                    break;
                }
            }
            else
            {
                colPerson += (right - left);
                if (CheckCurrentPosition(matrix, rowPerson, colPerson))
                {
                    break;
                }
            }
            rowPerson++;
        }
    }

    private static bool CheckCurrentPosition(List<char[]> matrix, int rowPerson, int colPerson)
    {
        char[] cliff = new char[] { '/', '\\', '|' };

        if (matrix[rowPerson][colPerson].Equals('_'))
        {
            Console.WriteLine("Landed on the ground like a boss!");
            Console.WriteLine($"{rowPerson} {colPerson}");
            return true;
        }
        else if (matrix[rowPerson][colPerson].Equals('~'))
        {
            Console.WriteLine("Drowned in the water like a cat!");
            Console.WriteLine($"{rowPerson} {colPerson}");
            return true;
        }
        else if (cliff.Contains(matrix[rowPerson][colPerson]))
        {
            Console.WriteLine("Got smacked on the rock like a dog!");
            Console.WriteLine($"{rowPerson} {colPerson}");
            return true;
        }
        return false;
    }

    private static void FindPersonLocation(List<char[]> matrix, ref int rowPerson, ref int colPerson)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            if (matrix[row].Contains('o'))
            {
                rowPerson = row;
                for (int col = 0; col < matrix[rowPerson].Length; col++)
                {
                    if (matrix[rowPerson][col].Equals('o'))
                    {
                        colPerson = col;
                        break;
                    }
                }
            }
        }
    }
}