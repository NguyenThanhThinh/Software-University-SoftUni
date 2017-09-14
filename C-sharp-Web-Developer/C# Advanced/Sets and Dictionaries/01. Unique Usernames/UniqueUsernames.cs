using System;
using System.Collections.Generic;

public class UniqueUsernames
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var usernames = new HashSet<string>();

        for (int i = 0; i < n; i++)
        {
            var name = Console.ReadLine();
            usernames.Add(name);
        }

        Console.WriteLine();
        foreach (var name in usernames)
        {
            Console.WriteLine(name);
        }
    }
}