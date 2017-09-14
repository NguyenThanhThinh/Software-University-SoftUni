using System;
using System.Linq;

class MinMaxAvarageOfNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Max = {0}", numbers.Max());
        Console.WriteLine("Min = {0}", numbers.Min());
        Console.WriteLine("Sum = {0}", numbers.Sum());
        Console.WriteLine("Avg = {0:F2}", numbers.Average());
    }
}