using System;
using System.Collections.Generic;
using System.Linq;

public class SetsOfElements
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var setOne = new HashSet<string>();
        var setTwo = new HashSet<string>();
        string num;

        for (int i = 0; i < input[0]; i++)
        {
            num = Console.ReadLine();
            setOne.Add(num);
        }
        for (int i = 0; i < input[1]; i++)
        {
            num = Console.ReadLine();
            setTwo.Add(num);
        }

        var combine = setOne.Intersect(setTwo);

        Console.WriteLine(string.Join(" ", combine));
    }
}