using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

public class Events
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var events = new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();
        string pattern = @"^#([a-zA-Z]+):\s*@([a-zA-Z]+)\s*(\d{2}:\d{2})$";
        string name = string.Empty;
        string town = string.Empty;
        DateTime time = new DateTime();
      
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            Match match = Regex.Match(input, pattern);
            bool correctTime = false;

            if (match.Success)
            {
                correctTime = CheckIfTimeIsCorrect(match.Groups[3].Value);
                if (correctTime)
                {
                    name = match.Groups[1].Value;
                    town = match.Groups[2].Value;
                    time = DateTime.ParseExact(match.Groups[3].Value, "HH:mm", CultureInfo.InvariantCulture);
                }
            }

            if (correctTime)
            {
                PutTheInformationInTheDictionary(name, town, time, events);
            }
            correctTime = false;
        }

        var townCommands = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().OrderBy(z => z);

        foreach (var command in townCommands)
        {
            var result = events.Where(t => t.Key == command);
            foreach (var output in result)
            {
                int lineIndex = 1;
                Console.WriteLine($"{output.Key}:");
                foreach (var person in output.Value)
                {
                    var formattedEventTimes = person.Value
                            .OrderBy(v => v)
                            .Select(v => v.ToString("HH:mm"));
                    Console.WriteLine($"{lineIndex}. {person.Key} -> {string.Join(", ", formattedEventTimes)}");
                    lineIndex++;
                }
            }
        }
    }

    private static void PutTheInformationInTheDictionary(string name, string town, DateTime time, SortedDictionary<string, SortedDictionary<string, List<DateTime>>> events)
    {
        if (!events.ContainsKey(town))
        {
            events[town] = new SortedDictionary<string, List<DateTime>>();
            events[town][name] = new List<DateTime>();
            events[town][name].Add(time);
        }
        else
        {
            if (!events[town].ContainsKey(name))
            {
                events[town][name] = new List<DateTime>();
                events[town][name].Add(time);
            }
            else
            {
                events[town][name].Add(time);
            }
        }
    }

    private static bool CheckIfTimeIsCorrect(string time)
    {
        var splitTime = time.Split(':');
        if (int.Parse(splitTime[0]) > 23 || int.Parse(splitTime[1]) > 59)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}