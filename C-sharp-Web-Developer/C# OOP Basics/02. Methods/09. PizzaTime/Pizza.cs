using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Pizza
{
    public string name;
    public long group;

    public SortedDictionary<int, List<string>> PizzaMethod(params string[] names)
    {
        var pizzas = new SortedDictionary<int, List<string>>();

        foreach (var pizza in names)
        {
            Match match = Regex.Match(pizza, @"([0-9]+)(.+)");
            int currentGroup = int.Parse(match.Groups[1].Value);
            string name = match.Groups[2].Value;

            if (!pizzas.ContainsKey(currentGroup))
            {
                pizzas[currentGroup] = new List<string>();
            }
            pizzas[currentGroup].Add(name);
        }

        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"{pizza.Key} - {string.Join(", ", pizza.Value)}");
        }

        return pizzas;
    }
}