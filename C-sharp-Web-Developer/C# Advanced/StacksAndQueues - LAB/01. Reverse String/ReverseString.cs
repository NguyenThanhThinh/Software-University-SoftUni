using System;
using System.Collections.Generic;

public class ReverseString
{
    public static void Main()
    {
        string str = Console.ReadLine();
        var reverse = new Stack<char>();

        for (int i = 0; i < str.Length; i++)
        {
            reverse.Push(str[i]);
        }

        Console.WriteLine(string.Join("", reverse));
    }
}