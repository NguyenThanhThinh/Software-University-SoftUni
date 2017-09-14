using System;
using System.Text.RegularExpressions;

public class ExtractEmails
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var pattern = @"(?<=\s)([A-Za-z]+(\.|-|_)*[A-Za-z]+)+@([A-Za-z]+-*[A-Za-z]+){1,}(\.[a-z]+(\.|-)?[a-z]+){1,}";
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input);

        foreach (Match email in matches)
        {
            Console.WriteLine(email);
        }
    }
}