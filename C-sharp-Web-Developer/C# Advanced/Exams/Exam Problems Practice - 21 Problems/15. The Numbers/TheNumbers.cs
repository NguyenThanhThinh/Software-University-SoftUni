using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TheNumbers
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var digitPattern = @"[0-9]+";
        List<string> digits = new List<string>();
        List<string> hexDigits = new List<string>();
        Match match = Regex.Match(input, digitPattern);

        while (match.Success)
        {
            digits.Add(match.Value);

            match = match.NextMatch();
        }

        for (int i = 0; i < digits.Count; i++)
        {
            var hexDigit = long.Parse(digits[i]).ToString("X4");
            hexDigits.Add("0x" + hexDigit);
        }

        Console.WriteLine(string.Join("-", hexDigits));
    }
}