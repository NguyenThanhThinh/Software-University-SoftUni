using System;
using System.Collections.Generic;
using System.Linq;

public class PrimeFactorization
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int backUpNumber = number;
        List<int> primeMultipliers = new List<int>();
        int divisor = 2;
        int lastNumber = 0;

        while (number > divisor)
        {
            if (number % divisor == 0)
            {
                primeMultipliers.Add(divisor);
                number /= divisor;
                lastNumber = number;
            }
            else
            {
                divisor++;
            }
        }
        primeMultipliers.Add(lastNumber);
        Console.WriteLine($"{backUpNumber} = {string.Join(" * ", primeMultipliers.OrderBy(n => n))}");
    }
}