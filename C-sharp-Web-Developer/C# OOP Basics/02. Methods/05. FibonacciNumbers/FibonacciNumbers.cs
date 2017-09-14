using System;
using System.Collections.Generic;
using System.Linq;

public class FibonacciNumbers
{
    public static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        var fibNums = new Stack<long>();

        fibNums.Push(0);
        fibNums.Push(1);

        for (int i = 0; i < end - 2; i++)
        {
            long last = fibNums.Pop();
            long newNum = fibNums.Peek() + last;
            fibNums.Push(last);
            fibNums.Push(newNum);
        }
        
        var fibonacci = new Fibonacci(fibNums.ToList());
        Console.WriteLine(string.Join(", ", fibonacci.GetNumbersInRange(start, end)));
    }
}