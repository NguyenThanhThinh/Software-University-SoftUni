using System;
using System.Linq;

public static class KnightsOfHonor
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Action<string[]> myAction = AddSirToName;
        myAction(input);
    }

    public static void AddSirToName(string[] input)
    {
        foreach (var name in input)
        {
            Console.WriteLine(string.Format($"Sir {name}"));
        }
    }
}