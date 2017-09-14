using System;
using System.Collections.Generic;

class RandomizeTheNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbersFromOneToN = new List<int>();
        int randomHolder = 0;

        for (int i = 1; i <= n; i++)
        {
            numbersFromOneToN.Add(i);
        }
        Random randomNumbers = new Random();

        while (numbersFromOneToN.Count != 0)
        {
            randomHolder = randomNumbers.Next(0, numbersFromOneToN.Count);
            Console.Write("{0} ", numbersFromOneToN[randomHolder]);
            numbersFromOneToN.RemoveAt(randomHolder);   
        }

        Console.WriteLine();
    }
}