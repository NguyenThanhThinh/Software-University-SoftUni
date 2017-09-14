using System;
using System.Collections.Generic;

class NighLife
{
    static void Main()
    {
        var data = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string input = Console.ReadLine();
        string[] separator = new string[3];

        while (input != "END")
        {
            separator = input.Split(';');
            string city = separator[0];
            string venue = separator[1];
            string performer = separator[2];

            if (!data.ContainsKey(city))
            {
                data.Add(city, new SortedDictionary<string, SortedSet<string>>());
            }

            if (!data[city].ContainsKey(venue))
            {
                data[city].Add(venue, new SortedSet<string>());
            }

            data[city][venue].Add(performer);
            input = Console.ReadLine();
        }

        foreach (var city in data)
        {
            Console.WriteLine(city.Key);
            foreach (var place in city.Value)
            {
                Console.WriteLine("->{0}: {1}", place.Key, (string.Join(",", place.Value)));
            }
        }
    }
}