using System;
using System.Collections.Generic;
using System.Text;

public class MathPotato
{
    public static void Main()
    {
        var kids = Console.ReadLine().Split();
        var number = int.Parse(Console.ReadLine());
        var kidsQueue = new Queue<string>(kids);
        var result = new StringBuilder();
        int cycle = 1;

        while (kidsQueue.Count > 1)
        {
            for (int i = 0; i < number - 1; i++)
            {
                string name = kidsQueue.Dequeue();
                kidsQueue.Enqueue(name);
            }

            if (IsPrime(cycle))
            {
                result.AppendLine($"Prime {kidsQueue.Peek()}");
            }
            else
            {
                result.AppendLine($"Removed {kidsQueue.Dequeue()}");
            }
            cycle++;
        }

        result.AppendLine($"Last is {kidsQueue.Dequeue()}");

        Console.WriteLine(result.ToString().Trim());
    }

    public static bool IsPrime(long number)
    {
        if (number <= 1)
            return false;
        if (number % 2 == 0)
            return number == 2;

        long N = (long)(Math.Sqrt(number) + 0.5);

        for (int i = 3; i <= N; i += 2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}