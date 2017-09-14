using System;
using System.Text;
using System.Text.RegularExpressions;

public class MatchFullName
{
    public static void Main()
    {
        string pattern = @"\b([A-Z][a-z]+)\x20([A-Z][a-z]+)\b";
        string input = Console.ReadLine();
        Regex regex = new Regex(pattern);
        var result = new StringBuilder();

        while (input != "end")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                result.AppendLine(input);
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(result);
    }
}