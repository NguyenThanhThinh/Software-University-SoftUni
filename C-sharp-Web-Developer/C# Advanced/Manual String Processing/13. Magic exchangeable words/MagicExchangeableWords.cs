using System;
using System.Linq;

public class MagicExchangeableWords
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var str1 = input[0].ToList<char>();
        var str2 = input[1].ToList<char>();

        var str1Distinct = str1.Distinct().ToList();
        var str2DIstinct = str2.Distinct().ToList();

        if (str1Distinct.Count == str2DIstinct.Count)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}