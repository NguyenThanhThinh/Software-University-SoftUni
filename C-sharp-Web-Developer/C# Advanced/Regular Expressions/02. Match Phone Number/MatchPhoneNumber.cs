using System;
using System.Text;
using System.Text.RegularExpressions;

public class MatchPhoneNumber
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"\+359([\s|-])2\1\d{3}\1\d{4}\b";
        Regex regex = new Regex(pattern);
        var result = new StringBuilder();

        while (input != "end")
        {
            bool match = regex.IsMatch(input);
            if (match)
            {
                result.AppendLine(input);
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(result);
    }
}