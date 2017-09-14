using System;
using System.Numerics;

class CalculateFactorialFormula
{
    static void Main()
    {
        //n! / (k! * (n-k)!)
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        BigInteger holder = 1L;
        BigInteger secondHolder = 1L;
        BigInteger thirdHolder = 1;

        for (int i = 1; i <= n; i++)
        {
            holder *= i;
            if (i <= k)
            {
                secondHolder *= i;
            }
        }

        for (int i = 1; i <= n - k; i++)
        {
            thirdHolder *= i;
        }

        Console.WriteLine(holder / (secondHolder * thirdHolder));
    }
}