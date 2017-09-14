using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"([\D]+)(\d+)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        StringBuilder result = new StringBuilder();
        StringBuilder uniqueElements = new StringBuilder();

        foreach (Match item in matches)
        {
            string value = item.Groups[1].Value.ToUpper();
            int repeat = int.Parse(item.Groups[2].Value);
            uniqueElements.Append(value);
            result.Append(string.Concat(Enumerable.Repeat(value, repeat)));
        }
        int uniqueCharsCount = uniqueElements.ToString().Distinct().Count();

        Console.WriteLine($"Unique symbols used: {uniqueCharsCount}");
        Console.WriteLine(result);
    }
}