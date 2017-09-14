using System;

class MatrixOfNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ", i);
            for (int p = 0, x = i + 1; p < n - 1; p++, x++)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine();
        }
    }
}