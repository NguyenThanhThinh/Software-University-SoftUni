using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var stackNumbers = new Stack<int>();
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            stackNumbers.Push(numbers[i]);
        }

        for (int i = 0; i < input[1]; i++)
        {
            stackNumbers.Pop();
        }

        if (stackNumbers.Contains(input[2]))
        {
            Console.WriteLine("true");
        }
        else if (stackNumbers.Count != 0)
        {
            Console.WriteLine(stackNumbers.ToArray().Min());
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}