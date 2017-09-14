using System;
using System.Linq;

class LadyBugs
{
    static void Main(string[] args)
    {
        int sizeField = int.Parse(Console.ReadLine());
        int[] field = new int[sizeField];
        var indexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n >= 0 && n < field.Length)
            .ToArray();
        var direction = Console.ReadLine();
        field = FillTheLadyBugs(indexes, sizeField);

        while (direction != "end")
        {
            var commands = direction.Split();
            int currentIndex = int.Parse(commands[0]);
            string flyDirection = commands[1];
            int nextIndex = int.Parse(commands[2]);

            if (flyDirection == "right")
            {
                field = FLyToRight(field, currentIndex, nextIndex);
            }
            else if (flyDirection == "left")
            {
                field = FlyToLeft(field, currentIndex, nextIndex);
            }
            direction = Console.ReadLine();
        }
        Console.WriteLine(string.Join(" ", field));
    }

    private static int[] FlyToLeft(int[] field, int currentIndex, int nextIndex)
    {
        long decreaseIndex = (currentIndex - nextIndex);
        bool inRange = true;

        while (inRange)
        {
            if (currentIndex >= 0 && currentIndex < field.Length && decreaseIndex >= 0 && decreaseIndex < field.Length)
            {
                if (field[currentIndex] == 0)
                {
                    break;
                }
                if (field[decreaseIndex] != 1)
                {
                    field[decreaseIndex] = 1;
                    field[currentIndex] = 0;
                    break;
                }
                else
                {
                    decreaseIndex -= nextIndex;
                }
            }
            else
            {
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 0;
                }
                inRange = false;
            }
        }
        return field;
    }

    private static int[] FLyToRight(int[] field, int currentIndex, int nextIndex)
    {
        long increaseIndex = (currentIndex + nextIndex);
        bool inRange = true;

        while (inRange)
        {
            if (increaseIndex < field.Length && currentIndex >= 0 && increaseIndex >= 0 && currentIndex < field.Length)
            {
                if (field[currentIndex] == 0)
                {
                    break;
                }
                if (field[increaseIndex] != 1)
                {
                    field[increaseIndex] = 1;
                    field[currentIndex] = 0;
                    break;
                }
                else
                {
                    increaseIndex += nextIndex;
                }
            }
            else
            {
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 0;
                }
                inRange = false;
            }
        }
        return field;
    }

    private static int[] FillTheLadyBugs(int[] indexes, int sizeField)
    {
        int[] ladyBugs = new int[sizeField];

        for (int i = 0; i < indexes.Length; i++)
        {
            int index = indexes[i];
            ladyBugs[index] = 1;
        }
        return ladyBugs;
    }
}