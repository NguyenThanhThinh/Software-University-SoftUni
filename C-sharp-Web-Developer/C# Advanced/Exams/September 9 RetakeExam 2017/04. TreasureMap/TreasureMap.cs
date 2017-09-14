using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class TreasureMap
{
    public static List<string> firstCapture = new List<string>();
    public static List<string> nameOfStreet = new List<string>();
    public static List<string> streetNumberAndPass = new List<string>();
    public static string firstCapturePattern = @"([#][^#]*?[!])|([!][^!]*?[#])";
    public static string nameOfStreenPattern = @"(?<![0-9A-Za-z])[A-Za-z]{4}(?![0-9A-Za-z])";
    public static string streetNumberAndPassPattern = @"(\d{3})-(\d{4}|\d{6})";

    public static string globalPattern =
            @"[#].*((?<![0-9A-Za-z])[A-Za-z]{4}(?![0-9A-Za-z])).*(\d{3})-(\d{4}|\d{6})[!]|[!].*((?<![0-9A-Za-z])[A-Za-z]{4}(?![0-9A-Za-z])).*(\d{3})-(\d{4}|\d{6})[#]";

    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var result = new StringBuilder();

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, globalPattern);

            foreach (Match current in matches)
            {
                var name = current.Groups[1];
            }
        }



        Console.WriteLine(result);
    }

    private static int GetFirstCaptureNeededIndex()
    {
        return (firstCapture.Count / 2);
    }

    private static void GetAddressAndPassword(string input, StringBuilder result)
    {
        if (Regex.IsMatch(input, nameOfStreenPattern) && Regex.IsMatch(input, streetNumberAndPassPattern))
        {
            var streetNameMatches = Regex.Matches(input, nameOfStreenPattern);
            var streetNumberAndPassword = Regex.Matches(input, streetNumberAndPassPattern);

            var wantedStreetName = streetNameMatches[0].Value;
            var wantedStreetNumberAndPassword = streetNumberAndPassword[streetNumberAndPassword.Count - 1].Value.Split('-');
            var wantedStreetNumber = wantedStreetNumberAndPassword[0];
            var wantedPassword = wantedStreetNumberAndPassword[1];

            result.AppendLine($"Go to str. {wantedStreetName} {wantedStreetNumber}. Secret pass: {wantedPassword}.");
        }
    }

    private static void GetFirstCaptures(string input)
    {
        Regex regex = new Regex(firstCapturePattern);

        var matches = regex.Matches(input);

        if (matches.Count > 0)
        {
            foreach (Match currentMatch in matches)
            {
                firstCapture.Add(currentMatch.Value);
            }
        }
    }
}