using System;
using System.Text;

class TrifonQuest
{
    static void Main(string[] args)
    {
        int health = int.Parse(Console.ReadLine());
        var dimension = Console.ReadLine().Split();
        int rows = int.Parse(dimension[0]);
        int cols = int.Parse(dimension[1]);
        string[,] rectangleMatrix = new string[rows, cols];
        int turnsCounter = 0;
        bool died = false;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < rows; i++)
        {
            var input = Console.ReadLine();
            for (int p = 0; p < input.Length; p++)
            {
                rectangleMatrix[i, p] = input[p].ToString();
            }
        }

        for (int i = 0; i < cols; i++)
        {
            if (i % 2 != 0 && died != true)
            {
                for (int p = rows - 1; p >= 0; p--)
                {
                    health = CurrentMove(rectangleMatrix, i, p, health, turnsCounter)[0];
                    turnsCounter = CurrentMove(rectangleMatrix, i, p, health, turnsCounter)[1];
                    turnsCounter++;
                    if (health <= 0)
                    {
                        died = true;
                        result.AppendLine($"Died at: [{p}, {i}]");
                        break;
                    }
                }
            }
            else if (i % 2 == 0 && died != true)
            {
                for (int p = 0; p < rows; p++)
                {
                    health = CurrentMove(rectangleMatrix, i, p, health, turnsCounter)[0];
                    turnsCounter = CurrentMove(rectangleMatrix, i, p, health, turnsCounter)[1];
                    turnsCounter++;
                    if (health <= 0)
                    {
                        died = true;
                        result.AppendLine($"Died at: [{p}, {i}]");
                        break;
                    }
                }
            }
        }

        if (health > 0)
        {
            result.AppendLine("Quest completed!");
            result.AppendLine($"Health: {health}");
            result.AppendLine($"Turns: {turnsCounter}");
        }

        Console.WriteLine(result.ToString());
    }

    private static int[] CurrentMove(string[,] rectangleMatrix, int i, int p, int health, int turnsCounter)
    {
        var result = new int[2];
        int number = 0;
        if (rectangleMatrix[p, i] == "F")
        {
            number = turnsCounter / 2;
            health -= number;
            result[0] = health;
            result[1] = turnsCounter;
        }
        else if (rectangleMatrix[p, i] == "H")
        {
            number = turnsCounter / 3;
            health += number;
            result[0] = health;
            result[1] = turnsCounter;
        }
        else if (rectangleMatrix[p, i] == "T")
        {
            turnsCounter += 2;
            result[0] = health;
            result[1] = turnsCounter;
        }
        else
        {
            result[0] = health;
            result[1] = turnsCounter;
        }

        return result;
    }
}