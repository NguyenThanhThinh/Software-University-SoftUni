using System;
using System.Collections.Generic;

public class SoftuniParty
{
    public static void Main()
    {
        var guests = new SortedSet<string>();
        var input = Console.ReadLine();

        while (!input.Equals("PARTY"))
        {
            guests.Add(input);
            input = Console.ReadLine();
        }

        input = Console.ReadLine();
        while (!input.Equals("END"))
        {
            guests.Remove(input);
            input = Console.ReadLine();
        }

        Console.WriteLine(guests.Count);
        foreach (var guest in guests)
        {
            Console.WriteLine(guest);
        }
    }
}