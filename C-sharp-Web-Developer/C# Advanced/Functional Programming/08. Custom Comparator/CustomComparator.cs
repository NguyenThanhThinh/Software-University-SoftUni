using System;
using System.Linq;

public static class CustomComparator
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        numbers = numbers.OrderBy(a => a).OrderBy(n => Math.Abs(n % 2)).ToArray();
        
        //Array.Sort(numbers, (even, odd) =>
        //    {
        //        int riminderEven = Math.Abs(even % 2);
        //        int riminderOdd = Math.Abs(odd % 2);
        //        return riminderEven.CompareTo(riminderOdd);
        //    });
        
        Console.WriteLine(string.Join(" ", numbers));
    }
}   