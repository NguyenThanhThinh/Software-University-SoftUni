using System;
using System.Text.RegularExpressions;

public class SumOfAllValues
{
    public static void Main()
    {
        var keysString = Console.ReadLine();
        var textString = Console.ReadLine();

        var startKey = string.Empty;
        var endKey = string.Empty;

        var keysStringPattern = @"^([a-zA-Z_]+)(?=[0-9]).+(?<=[0-9])([a-zA-Z_]+)$";
        Match keysStringMatch = Regex.Match(keysString, keysStringPattern);
        decimal totalSum = 0M;

        if (keysStringMatch.Success)
        {
            startKey = keysStringMatch.Groups[1].Value;
            endKey = keysStringMatch.Groups[2].Value;

            var textStringValuesPattern = $@"{startKey}([0-9\.]+){endKey}";
            Match valuesMatch = Regex.Match(textString, textStringValuesPattern);

            while (valuesMatch.Success)
            {
                totalSum += decimal.Parse(valuesMatch.Groups[1].Value);
                valuesMatch = valuesMatch.NextMatch();
            }

            if (totalSum == 0)
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
            else
            {
                Console.WriteLine($"<p>The total value is: <em>{totalSum:0.##}</em></p>");
            }
        }
        else
        {
            Console.WriteLine("<p>A key is missing</p>");
        }
    }
}