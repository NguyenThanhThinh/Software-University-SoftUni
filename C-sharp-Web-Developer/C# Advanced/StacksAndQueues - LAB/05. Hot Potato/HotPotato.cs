using System;
using System.Collections.Generic;
using System.Text;

public class HotPotato
{
    public static void Main()
    {
        var kids = Console.ReadLine().Split();
        var number = int.Parse(Console.ReadLine());
        var kidsQueue = new Queue<string>(kids);
        var result = new StringBuilder();

        while (kidsQueue.Count > 1)
        {
            for (int i = 0; i < number - 1; i++)
            {
                string name = kidsQueue.Dequeue();
                kidsQueue.Enqueue(name);
            }
            result.AppendLine($"Removed {kidsQueue.Dequeue()}");
        }

        result.AppendLine($"Last is {kidsQueue.Dequeue()}");

        Console.WriteLine(result.ToString().Trim());
    }
}