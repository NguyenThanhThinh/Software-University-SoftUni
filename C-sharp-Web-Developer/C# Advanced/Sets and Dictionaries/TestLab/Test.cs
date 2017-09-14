using System;
using System.Collections.Generic;
using System.Linq;

public class RadioactiveBunnies
{
    public static void Main()
    {
        var parking = new List<HashSet<int>>();
        for (int i = 0; i < 10; i++)
        {
            parking.Add(new HashSet<int>());
            parking[i].Add(0);
        }

        Console.WriteLine();
    }
}