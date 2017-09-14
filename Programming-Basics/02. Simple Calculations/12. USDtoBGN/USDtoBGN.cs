using System;

class USDtoBGN
{
    static void Main()
    {
        double oneUSD = 1.79549;
        double usd = Double.Parse(Console.ReadLine());
        double bgn = 0d;
        bgn = usd * oneUSD;

        Console.WriteLine(Math.Round(bgn, 2));
    }
}

