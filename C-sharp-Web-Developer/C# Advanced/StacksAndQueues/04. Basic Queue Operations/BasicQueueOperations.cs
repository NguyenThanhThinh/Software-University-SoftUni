using System;
using System.Collections.Generic;
using System.Linq;

public class BasicQueueOperations
{
    public static void Main()
    {
        var inputCommands = Console.ReadLine().Split();
        Queue<int> numbers = new Queue<int>();
        int n = int.Parse(inputCommands[0]);
        int dequeue = int.Parse(inputCommands[1]);
        int numToCheck = int.Parse(inputCommands[2]);

        var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < inputNumbers.Length; i++)
        {
            numbers.Enqueue(inputNumbers[i]);
        }

        for (int i = 0; i < dequeue; i++)
        {
            numbers.Dequeue();
        }

        if (numbers.Count > 0)
        {
            if (numbers.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}