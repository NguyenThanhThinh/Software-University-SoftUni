using System;
using System.Collections.Generic;
using System.Linq;

class CommandInterpreter
{
    static void Main()
    {
        var collection = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var command = Console.ReadLine();

        while (command != "end")
        {
            var separateCommand = command.Split(' ');

            switch (separateCommand[0])
            {
                case "reverse":
                    int intStart = int.Parse(separateCommand[2]);
                    int intCount = int.Parse(separateCommand[4]);
                    bool outOfRange = (intStart < 0 || intStart >= collection.Count || intCount < 0 || intStart + intCount >= collection.Count);
                    if (outOfRange)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        collection = ReverseTheCollection(collection, intStart, intCount);
                    }
                    break;

                case "sort":
                    intStart = int.Parse(separateCommand[2]);
                    intCount = int.Parse(separateCommand[4]);
                    bool outOfRangeSecond = (intStart < 0 || intStart >= collection.Count || intCount < 0 || intStart + intCount >= collection.Count);
                    if (outOfRangeSecond)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        collection = SortTheCollection(collection, intStart, intCount);
                    }
                    break;

                case "rollLeft":
                    collection = RollLeftCollection(collection, separateCommand[1]);
                    break;

                case "rollRight":
                    collection = RollRightCollection(collection, separateCommand[1]);
                    break;
                default:
                    break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", collection));
    }

    private static List<string> RollRightCollection(List<string> collection, string count)
    {
        int intCount = int.Parse(count);
        List<string> rolledRight = new List<string>(collection);

        for (int i = 0; i < collection.Count; i++)
        {
            int index = i;
            for (int p = 0; p < intCount; p++)
            {
                if (index < collection.Count - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
            rolledRight.RemoveAt(index);
            rolledRight.Insert(index, collection[i]);
        }
        return rolledRight;
    }

    private static List<string> RollLeftCollection(List<string> collection, string count)
    {
        List<string> rolledLeft = new List<string>(collection);
        int intCount = int.Parse(count);

        for (int i = collection.Count - 1; i >= 0; i--)
        {
            int index = i;
            for (int p = 0; p < intCount; p++)
            {
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    index = collection.Count - 1;
                }
            }
            rolledLeft.RemoveAt(index);
            rolledLeft.Insert(index, collection[i]);
        }
        return rolledLeft;
    }

    private static List<string> SortTheCollection(List<string> collection, int start, int count)
    {
        var piece = collection.GetRange(start, count);
        piece.Sort();
        collection.RemoveRange(start, count);
        collection.InsertRange(start, piece);
        return collection;
    }

    private static List<string> ReverseTheCollection(List<string> collection, int start, int count)
    {
        var piece = collection.GetRange(start, count);
        piece.Reverse();
        collection.RemoveRange(start, count);
        collection.InsertRange(start, piece);
        return collection;
    }
}