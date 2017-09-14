using System;
using System.Collections.Generic;

public class DecimalToBinaryConverter
{
    public static void Main()
    {
        var numInDecimal = int.Parse(Console.ReadLine());
        var numInBinary = new Stack<int>();

        if (numInDecimal == 0)
        {
            Console.WriteLine(0);
            return;
        }

        while (numInDecimal > 0)
        {
            numInBinary.Push(numInDecimal % 2);
            numInDecimal = numInDecimal / 2;
        }
        Console.WriteLine(string.Join("", numInBinary));
    }
}