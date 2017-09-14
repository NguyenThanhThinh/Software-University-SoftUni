using System;

public class PrimeChecker
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var number = new Number(num, false);

        Console.WriteLine($"{number.NextPrimeNumber()}, {number.Prime.ToString().ToLower()}");
    }
}