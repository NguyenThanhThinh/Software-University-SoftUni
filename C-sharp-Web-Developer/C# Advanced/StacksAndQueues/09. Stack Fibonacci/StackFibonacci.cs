using System;
using System.Collections.Generic;

//program is working, but Judge gives 0/100 I don't know why
public class StackFibonacci
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        if (n <= 1)
        {
            Console.WriteLine(n);
            return;
        }

        var fibonacci = new Queue<long>();
        fibonacci.Enqueue(1);
        fibonacci.Enqueue(1);
        for (int i = 0; i < n - 2; i++)
        {
            var num = fibonacci.Dequeue() + fibonacci.Peek();
            fibonacci.Enqueue(num);
        }

        fibonacci.Dequeue();
        Console.WriteLine(fibonacci.Dequeue());
    }
}