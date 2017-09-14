using System;
using System.Collections.Generic;

public class ReverseNumbersWithStack
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Stack<string> numbers = new Stack<string>();

        foreach (var item in input)
        {
            numbers.Push(item);
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}