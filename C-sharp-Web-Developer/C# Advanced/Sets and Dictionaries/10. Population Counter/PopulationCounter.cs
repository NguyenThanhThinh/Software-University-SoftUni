using System;
using System.Collections.Generic;
using System.Linq;

public class PopulationCounter
{
    public static void Main()
    {
        string line = Console.ReadLine();
        var finalStatistic = new Dictionary<string, Dictionary<string, long>>();
        var populationByCountry = new Dictionary<string, long>();

        while (line != "Report" && line != "report")
        {
            var lineSeparated = line.Split('|');
            string city = lineSeparated[0];
            string country = lineSeparated[1];
            long populationByCity = long.Parse(lineSeparated[2]);

            if (!finalStatistic.ContainsKey(country))
            {
                finalStatistic[country] = new Dictionary<string, long>();
            }
            finalStatistic[country].Add(city, populationByCity);

            line = Console.ReadLine();
        }

        var result = finalStatistic.OrderByDescending(c => c.Value.Sum(d => d.Value));
        Console.WriteLine();

        foreach (var country in result)
        {
            Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Sum(d => d.Value));

            foreach (var city in country.Value.OrderByDescending(n => n.Value))
            {
                Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
            }
        }
    }
}