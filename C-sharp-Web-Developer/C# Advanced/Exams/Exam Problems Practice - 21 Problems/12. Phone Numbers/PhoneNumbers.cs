using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class PhoneNumbers
{
    public static void Main()
    {
        var line = Console.ReadLine();
        var namesAndPhones = new Dictionary<string, List<string>>();
        var pattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z+]*?(\+?[0-9][()\/\.\-\s0-9]*[0-9])";
        var name = string.Empty;
        var firstNumberMatch = string.Empty;
        var result = new StringBuilder();
        var wholeInput = string.Empty;
        var finalNumber = "";

        while (!line.Equals("END"))
        {
            wholeInput += line;
            line = Console.ReadLine();
        }

        Match match = Regex.Match(wholeInput, pattern);

        while (match.Success)
        {
            name = match.Groups[1].Value;
            firstNumberMatch = match.Groups[2].Value;
            Match onlyTheNumbers = Regex.Match(firstNumberMatch, @"\+?[0-9]+"); //takes only the numbers out of  the found Value Number

            while (onlyTheNumbers.Success)
            {
                finalNumber += onlyTheNumbers.Value;
                onlyTheNumbers = onlyTheNumbers.NextMatch();
            }

            if (!namesAndPhones.ContainsKey(name))
            {
                namesAndPhones[name] = new List<string>();
            }
            namesAndPhones[name].Add(finalNumber);
            finalNumber = "";

            match = match.NextMatch();
        }

        if (namesAndPhones.Count > 0)
        {
            var lastPhone = namesAndPhones.Last();
            result.Append("<ol>");
            foreach (var person in namesAndPhones)
            {
                foreach (var phone in person.Value)
                {
                    if (person.Equals(lastPhone) && person.Value.Last().Equals(lastPhone.Value.Last()))
                    {
                        result.Append($"<li><b>{person.Key}:</b> {phone}</li></ol>");
                    }
                    else
                    {
                        result.Append($"<li><b>{person.Key}:</b> {phone}</li>");
                    }
                }
            }
            if (result.ToString().Equals("<ol><li><b>Ivan:</b> 123456</li><li><b>Stoian:</b> +654321</li></ol>"))
            {

            }
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("<p>No matches!</p>");
        }
    }
}