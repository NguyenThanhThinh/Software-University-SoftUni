using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CommandInterpreter
{
    static void Main()
    {
        var array = Console.ReadLine().Split(new char[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries).ToList();
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        while (input != "end")
        {
            var split = input.Split(new char[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var command = split[0];
            int start = 0;
            int count = 0;

            if (command == "reverse" || command == "sort")
            {
                start = int.Parse(split[2]);
                count = int.Parse(split[4]);
            }
            else
            {
                count = int.Parse(split[1]);
            }

            switch (command)
            {
                case "reverse":
                    if (start < 0 || count < 0 || start + count > array.Count)
                    {
                        result.AppendLine("Invalid input parameters.");
                    }
                    else
                    {
                        ReverseArray(array, start, count);
                    }
                    break;
                case "sort":
                    if (start < 0 || count < 0 || start + count > array.Count)
                    {
                        result.AppendLine("Invalid input parameters.");
                    }
                    else
                    {
                        SortArray(array, start, count);
                    }
                    break;
                case "rollLeft":
                    for (int i = 0; i < count; i++)
                    {
                        array = RollLeft(array);
                    }
                    break;
                case "rollRight":
                    for (int i = 0; i < count; i++)
                    {
                        array = RollRight(array);
                    }
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
        result.AppendLine("[" + string.Join(", ", array) + "]");
        Console.Write(result.ToString());
    }

    private static List<string> RollRight(List<string> array)
    {
        var rollArray = new string[array.Count];
        array.CopyTo(0, rollArray, 1, array.Count - 1);
        rollArray[0] = array[array.Count - 1];

        return rollArray.ToList();
    }

    private static List<string> RollLeft(List<string> array)
    {
        var rollArray = new string[array.Count];
        array.CopyTo(1, rollArray, 0, array.Count - 1);
        rollArray[array.Count - 1] = array[0];

        return rollArray.ToList();
    }

    public static void SortArray(List<string> array, int start, int count)
    {
        var sortPartial = array.Skip(start).Take(count).OrderBy(n => n).ToList();
        array.RemoveRange(start, count);
        array.InsertRange(start, sortPartial);
    }

    private static void ReverseArray(List<string> array, int start, int count)
    {
        array.Reverse(start, count);
    }
}