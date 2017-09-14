using System;
using System.Linq;

public class InsertionSort
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int holder = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            int p = i;
            while (p > 0 && numbers[p - 1] > numbers[p])
            {
                holder = numbers[p];
                numbers[p] = numbers[p - 1];
                numbers[p - 1] = holder;
                p--;
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}