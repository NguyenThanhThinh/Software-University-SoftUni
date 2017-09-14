using System;
using System.Collections.Generic;
using System.Linq;

public class SieveOfEratosthenes
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var array = Enumerable.Range(2, n).ToArray();

        int prime = 2;
        int i = 0;
        while (prime * array[i] < array.Length)
        {

            i++;
        }
    }
}