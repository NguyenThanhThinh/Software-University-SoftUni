using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class PopulationAggregation
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var countries = new SortedDictionary<string, int>();
        var cities = new Dictionary<string, long>();

        while (input != "stop")
        {
            var split = input.Split('\\');
            Regex regex = new Regex("([^0-9@#$&\\s]+)");
            MatchCollection firstMatch = regex.Matches(split[0]);
            MatchCollection secondMatch = regex.Matches(split[1]);

            var firstMatchToArray = from Match match in firstMatch select match.Value;
            string firstMatchToString = string.Join("", firstMatchToArray);

            var secondMatchToArray = from Match match in secondMatch select match.Value;
            string secondMatchToString = string.Join("", secondMatchToArray);

            string countryName = Char.IsUpper(firstMatchToString[0]) ?
                firstMatchToString : secondMatchToString;
            string cityName = Char.IsUpper(firstMatchToString[0]) ?
                secondMatchToString : firstMatchToString;

            if (!countries.ContainsKey(countryName))
            {
                countries[countryName] = 1;
            }
            else
            {
                countries[countryName] += 1;
            }

            cities[cityName] = long.Parse(split[2]);
            input = Console.ReadLine();
        }

        foreach (var country in countries)
        {
            Console.WriteLine($"{country.Key} -> {country.Value}");
        }

        var orderedCities = cities.OrderByDescending(p => p.Value).Take(3);

        foreach (var city in orderedCities)
        {
            Console.WriteLine($"{city.Key} -> {city.Value}");
        }
    }
}