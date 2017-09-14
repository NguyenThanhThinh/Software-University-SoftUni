using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class QueryMess
{
    public static void Main()
    {
        var line = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        var pairs = new Dictionary<string, List<string>>();
        string fieldName = string.Empty;
        string value = string.Empty;
        string pairsPattern = @"\??([^?=&]+?)=([^?=\n&]+)";
        string whitespacePattern = @"%20|\+";

        while (!line.Equals("END"))
        {
            line = Regex.Replace(line, whitespacePattern, " ");
            line = Regex.Replace(line, @"\s+", " ");
            Match match = Regex.Match(line, pairsPattern);
            while (match.Success)
            {
                fieldName = match.Groups[1].Value.Trim();
                value = match.Groups[2].Value.Trim();

                if (!pairs.ContainsKey(fieldName))
                {
                    pairs[fieldName] = new List<string>();
                }
                pairs[fieldName].Add(value);
                match = match.NextMatch();
            }

            foreach (var pair in pairs)
            {
                result.Append($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
            }
            pairs.Clear();
            result.AppendLine();

            line = Console.ReadLine();
        }
        Console.WriteLine(result);
    }
}