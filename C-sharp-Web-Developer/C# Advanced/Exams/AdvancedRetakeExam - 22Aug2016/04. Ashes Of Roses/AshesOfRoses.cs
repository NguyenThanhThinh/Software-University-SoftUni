using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class AshesOfRoses
{
    public static void Main()
    {
        List<Roses> roses = new List<Roses>();
        string pattern = @"Grow\s<([A-Z]{1}[a-z]+)>\s<([A-z\d]+)>\s(\d+)(?!.)";

        string input = Console.ReadLine();

        while (input != "Icarus, Ignite!")
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            if (match.Success)
            {
                string region = match.Groups[1].Value;
                string color = match.Groups[2].Value;
                long amount = long.Parse(match.Groups[3].Value);

                Roses rose = new Roses();
                if (roses.Any(a => a.RegionName == region))
                {
                    int index = roses.FindIndex(a => a.RegionName == region);
                    if (roses[index].ColorAndAmount.ContainsKey(color))
                    {
                        roses[index].ColorAndAmount[color] += amount;
                    }
                    else
                    {
                        roses[index].ColorAndAmount[color] = amount;
                    }
                }
                else
                {
                    rose.RegionName = region;
                    rose.ColorAndAmount[color] = amount;
                    roses.Add(rose);
                }
            }

            input = Console.ReadLine();
        }

        var result = roses.OrderByDescending(a => a.ColorAndAmount.Sum(k => k.Value)).ThenBy(a => a.RegionName);

        foreach (var rose in result)
        {
            Console.WriteLine(rose.RegionName);
            foreach (var property in rose.ColorAndAmount.OrderBy(r => r.Value).ThenBy(r => r.Key))
            {
                Console.WriteLine($"*--{property.Key} | {property.Value}");
            }
        }
    }
}

public class Roses
{
    public string RegionName;
    public Dictionary<string, long> ColorAndAmount;

    public Roses()
    {
        ColorAndAmount = new Dictionary<string, long>();
    }
}
