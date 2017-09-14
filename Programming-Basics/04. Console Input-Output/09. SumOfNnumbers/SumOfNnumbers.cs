using System;

class SumOfNnumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        double nNumbers = 0;

        for (int i = 0; i < n; i++)
        {
            nNumbers = double.Parse(Console.ReadLine());
            sum += nNumbers;
        }

        Console.WriteLine(sum);
    }
}