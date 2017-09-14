using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class BiggestTableRow
{
    public static void Main()
    {
        var line = Console.ReadLine();
        var pattern = @"<tr><td>([a-zA-z]+)<\/td><td>([0-9-\.]+?)<\/td><td>([0-9-\.]+?)<\/td><td>([0-9-\.]+?)<\/td><\/tr>";
        decimal value = 0M;
        bool tryParseValue = false;
        decimal biggestValue = decimal.MinValue;
        List<decimal> values = new List<decimal>();
        List<decimal> biggestValues = new List<decimal>();

        while (!line.Equals("</table>"))
        {
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                tryParseValue = decimal.TryParse(match.Groups[2].Value, out value);
                if (tryParseValue)
                {
                    values.Add(value);
                }

                tryParseValue = decimal.TryParse(match.Groups[3].Value, out value);
                if (tryParseValue)
                {
                    values.Add(value);
                }

                tryParseValue = decimal.TryParse(match.Groups[4].Value, out value);
                if (tryParseValue)
                {
                    values.Add(value);
                }

                if (values.Sum() > biggestValue && values.Count > 0)
                {
                    biggestValue = values.Sum();
                    biggestValues = new List<decimal>(values);
                }
                values.Clear();
            }
            line = Console.ReadLine();
        }

        if (biggestValue > decimal.MinValue)
        {
            Console.WriteLine($"{biggestValue:0.##} = {string.Join(" + ", biggestValues)}");
        }
        else
        {
            Console.WriteLine("no data");
        }
    }
}