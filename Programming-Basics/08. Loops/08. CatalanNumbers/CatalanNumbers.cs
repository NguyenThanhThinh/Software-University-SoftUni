using System;
using System.Numerics;

class CatalanNumbers
{
    // (2n)! / (n + 1)!n!
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger firstHolder = 1;
        BigInteger secondHolder = 1;
        BigInteger thirdHolder = 1;

        for (int i = 1; i <= n * 2; i++)
        {
            firstHolder *= i;

            if (n + 1 >= i)
            {
                secondHolder *= i;
            }
            if (n >= i)
            {
                thirdHolder *= i;
            }
        }

        Console.WriteLine(firstHolder / (secondHolder * thirdHolder));
    }
}