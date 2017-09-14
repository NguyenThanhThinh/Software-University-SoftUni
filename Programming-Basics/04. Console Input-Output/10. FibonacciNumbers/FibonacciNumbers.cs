using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write("0 ");
       
        int addNumer = 1;
        int result = 0;
        int index = 0;

        for (int i = 0; i < n - 1; i++)
        {
            index = result;
            result += addNumer;
            Console.Write("{0} ", result);
            addNumer = index;
        }
        Console.WriteLine();
    }
}