using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SoftUniCoffeeSupplies
{
    static void Main(string[] args)
    {
        var delimiters = Console.ReadLine().Split();
        var coffeeTypesAndPersonsName = new Dictionary<string, List<string>>();
        var coffeeTypeAndQuantity = new Dictionary<string, long>();
        var result = new StringBuilder();

        string input = Console.ReadLine();
        int quantity = 0;
        string coffeeType = string.Empty;

        while (input != "end of info")
        {
            if (input.Contains(delimiters[0]))
            {
                var splitInput = input.Split(new string[] { delimiters[0] }, StringSplitOptions.RemoveEmptyEntries);
                string name = splitInput[0];
                coffeeType = splitInput[1];

                if (!coffeeTypesAndPersonsName.ContainsKey(coffeeType))
                {
                    coffeeTypesAndPersonsName[coffeeType] = new List<string>();
                    coffeeTypesAndPersonsName[coffeeType].Add(name);
                }
                else
                {
                    coffeeTypesAndPersonsName[coffeeType].Add(name);
                }

                if (!coffeeTypeAndQuantity.ContainsKey(coffeeType))
                {
                    coffeeTypeAndQuantity[coffeeType] = 0;
                }
                input = Console.ReadLine();
            }
            else if (input.Contains(delimiters[1]))
            {
                var splitInput = input.Split(new string[] { delimiters[1] }, StringSplitOptions.RemoveEmptyEntries);
                coffeeType = splitInput[0];
                quantity = 0;
                bool quantityAvailability = int.TryParse(splitInput[1], out quantity);

                coffeeTypeAndQuantity[coffeeType] += quantity;

                input = Console.ReadLine();
            }
        }
        input = Console.ReadLine();

        while (input != "end of week")
        {
            CalculateHowMuchCoffeeLeft(input, coffeeTypeAndQuantity, coffeeTypesAndPersonsName, result);
            input = Console.ReadLine();
        }

        CheckWhichCoffeeIsEmpty(coffeeTypeAndQuantity, result);
        FirstReport(result, coffeeTypeAndQuantity);
        SecondReport(result, coffeeTypeAndQuantity, coffeeTypesAndPersonsName);

        Console.WriteLine(result.ToString());
    }

    private static void SecondReport(StringBuilder result, Dictionary<string, long> coffeeTypeAndQuantity, Dictionary<string, List<string>> coffeeTypesAndPersonsName)
    {
        var coffeeLeft = coffeeTypeAndQuantity.Where(c => c.Value > 0).OrderBy(q => q.Key);
        var coffeeLeftAndPeople = new SortedDictionary<string, List<string>>();

        foreach (var person in coffeeTypesAndPersonsName)
        {
            foreach (var coffee in coffeeLeft)
            {
                if (coffeeTypesAndPersonsName.ContainsKey(coffee.Key))
                {
                    var names = coffeeTypesAndPersonsName[coffee.Key];
                    coffeeLeftAndPeople[coffee.Key] = new List<string>();
                    coffeeLeftAndPeople[coffee.Key] = names.OrderByDescending(n => n).ToList();
                }
            }
        }
        result.AppendLine("For:");

        foreach (var person in coffeeLeftAndPeople)
        {
            for (int i = 0; i < person.Value.Count; i++)
            {
                result.AppendLine($"{person.Value[i]} {person.Key}");
            }
        }
    }

    private static void FirstReport(StringBuilder result, Dictionary<string, long> coffeeTypeAndQuantity)
    {
        var coffeeLeft = coffeeTypeAndQuantity.Where(c => c.Value > 0).OrderByDescending(q => q.Value);
        result.AppendLine("Coffee Left:");
        foreach (var coffee in coffeeLeft)
        {
            result.AppendLine($"{coffee.Key} {coffee.Value}");
        }
    }

    private static void CheckWhichCoffeeIsEmpty(Dictionary<string, long> coffeeTypeAndQuantity, StringBuilder result)
    {
        foreach (var coffee in coffeeTypeAndQuantity)
        {
            if (coffee.Value <= 0)
            {
                result.AppendLine($"Out of {coffee.Key}");
            }
        }
    }

    private static void CalculateHowMuchCoffeeLeft(string input, Dictionary<string, long> coffeeTypeAndQuantity,
        Dictionary<string, List<string>> coffeeTypesAndPersonsName, StringBuilder result)
    {
        string name = input.Split()[0];
        int drinkQuantity = int.Parse(input.Split()[1]);

        string currentCoffeeType = coffeeTypesAndPersonsName.Where(n => n.Value.Contains(name)).First().Key;
        coffeeTypeAndQuantity[currentCoffeeType] -= drinkQuantity;
    }
}