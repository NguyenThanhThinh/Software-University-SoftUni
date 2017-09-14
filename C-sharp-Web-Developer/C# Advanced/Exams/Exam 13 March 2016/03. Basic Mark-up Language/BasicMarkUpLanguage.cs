using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class BasicMarkUpLanguage
{
    public static void Main()
    {
        string pattern = @"<\s*([a-zA-Z]+)\s*(.*?""(\d)"")*.+?""(.+)*""";

        string input = Console.ReadLine();
        string command = string.Empty;
        int value = 0;
        string content = string.Empty;

        StringBuilder result = new StringBuilder();
        int counter = 1;

        while (input != "<stop/>")
        {
            Match match = Regex.Match(input, pattern);

            command = match.Groups[1].Value;
            if (command.Equals("repeat"))
            {
                value = int.Parse(match.Groups[3].Value);
                content = match.Groups[4].Value;
            }
            else
            {
                content = match.Groups[4].Value;
            }

            switch (command)
            {
                case "inverse":
                    if (content.Count() > 0)
                    {
                        result.AppendLine(InverseString(content, counter));
                        counter++;
                    }
                    break;
                case "reverse":
                    if (content.Count() > 0)
                    {
                        result.AppendLine(ReverseString(content, counter));
                        counter++;
                    }
                    break;
                case "repeat":
                    if (content.Count() > 0)
                    {
                        result.Append(RepeatString(content, ref counter, value));
                    }
                    break;
            }
            input = Console.ReadLine();
        }
        Console.Write(result);
    }

    private static string RepeatString(string content, ref int counter, int value)
    {
        StringBuilder repeatedString = new StringBuilder();

        for (int i = 0; i < value; i++)
        {
            repeatedString.AppendLine($"{counter}. {content}");
            counter++;
        }
        return repeatedString.ToString();
    }

    private static string InverseString(string content, int counter)
    {
        StringBuilder inversedString = new StringBuilder();
        inversedString.Append($"{counter}. ");
        for (int i = 0; i < content.Length; i++)
        {
            char current = char.IsLower(content[i]) ? char.ToUpper(content[i]) : char.ToLower(content[i]);
            inversedString.Append(current.ToString());
        }
        return inversedString.ToString();
    }

    private static string ReverseString(string content, int counter)
    {
        StringBuilder reversedStrng = new StringBuilder();
        reversedStrng.Append($"{counter}. ");

        for (int i = content.Length - 1; i >= 0; i--)
        {
            reversedStrng.Append(content[i]);
        }
        return reversedStrng.ToString();
    }
}