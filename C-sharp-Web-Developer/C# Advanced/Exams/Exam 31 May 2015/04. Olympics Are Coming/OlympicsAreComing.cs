using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class OlympicsAreComing
{
    public static void Main()
    {
        var input = Regex.Replace(Console.ReadLine(), @"\s+", "\x20").Split('|');
        var winsByCountry = new Dictionary<string, int>();
        var stats = new Dictionary<string, List<string>>();

        while (!input[0].Equals("report"))
        {
            string name = input[0].Trim();
            string country = input[1].Trim();

            if (!stats.ContainsKey(country))
            {
                stats[country] = new List<string>();
                stats[country].Add(name);
                winsByCountry[country] = 1;
            }
            else
            {
                if (stats[country].Contains(name))
                {
                    winsByCountry[country]++;
                }
                else
                {
                    stats[country].Add(name);
                    winsByCountry[country]++;
                }
            }
            input = Regex.Replace(Console.ReadLine(), @"\s+", "\x20").Split('|');
        }

        var orderedWinsByCountry = winsByCountry.OrderByDescending(c => c.Value);

        foreach (var country in orderedWinsByCountry)
        {
            Console.WriteLine($"{country.Key} ({stats[country.Key].Count} participants): {country.Value} wins");
        }
    }
}