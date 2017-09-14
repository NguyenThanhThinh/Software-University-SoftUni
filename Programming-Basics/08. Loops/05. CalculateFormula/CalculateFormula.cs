using System;

class CalculateFormula
{
    static void Main()
    {
        //S = 1 + 1!/x + 2!/x2 + … + n!/x^n
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());

        double sum = 1L;
        long holder = 1L;

        for (int i = 1; i <= n; i++)
        {
            holder *= i;
            sum += holder / (Math.Pow(x, i));
        }
        Console.WriteLine("{0:F5}", sum);
    }
}