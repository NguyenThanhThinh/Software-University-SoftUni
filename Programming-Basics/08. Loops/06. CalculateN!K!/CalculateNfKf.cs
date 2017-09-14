using System;

class CalculateNfKf
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        double sum = 0d;
        long holder = 1;
        long holderTwo = 1;

        for (int i = 1; i <= n; i++)
        {
            holder *= i;
            if (i <= k)
            {
                holderTwo *= i;
            }
        }
        sum = holder / holderTwo;
        Console.WriteLine(sum);
    }
}