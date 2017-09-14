using System;

class GameOfNames
{
    static void Main(string[] args)
    {
        int linesNumber = int.Parse(Console.ReadLine());

        int points = 0;
        string name = string.Empty;
        int backUpPoints = 0;
        string backUpName = string.Empty;

        for (int i = 0; i < linesNumber; i++)
        {
            name = Console.ReadLine();
            points = int.Parse(Console.ReadLine());

            points = CalculatePoints(points, name);

            if (backUpPoints < points)
            {
                backUpPoints = points;
                backUpName = name;
            }
        }
        Console.WriteLine("The winner is {0} - {1} points", backUpName, backUpPoints);
    }

    private static int CalculatePoints(int points, string name)
    {
        int totalPoints = points;
        int charValue = 0;

        for (int i = 0; i < name.Length; i++)
        {
            charValue = (int)name[i];

            if (charValue % 2 == 0)
            {
                totalPoints += charValue;
            }
            else
            {
                totalPoints -= charValue;
            } 
        }
        return totalPoints;
    }
}