using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        StringBuilder wholeInput = new StringBuilder();
        StringBuilder finalResult = new StringBuilder();
        //replace any whitespace with single "space"
        var partInput = Regex.Replace(Console.ReadLine(), @"\s+", "\x20");

        while (!partInput.Equals("burp"))
        {
            wholeInput.Append(partInput);
            partInput = Regex.Replace(Console.ReadLine(), @"\s+", "\x20");
        }

        Match match = Regex.Match(wholeInput.ToString(), @"(\$|%|&|'){1}([^$%&']+)\1{1}");

        while (match.Success)
        {
            var capturedString = match.Groups[2].Value;
            int power = GiveCurrentSymbolAndReturnSpecificPower(match.Groups[1].Value);
            if (capturedString.Length > 0) // remove it in the end to check without it
            {
                GivePowerToCurrentCapturedString(finalResult, capturedString, power);
            }
            match = match.NextMatch();
            if (match.Success)
            {
                finalResult.Append(" ");
            }
        }
        Console.WriteLine(finalResult.ToString());
    }

    private static void GivePowerToCurrentCapturedString(StringBuilder finalResult, string capturedString, int power)
    {
        for (int i = 0; i < capturedString.Length; i++)
        {
            if (i % 2 == 0)
            {
                finalResult.Append(((char)(capturedString[i] + power)).ToString());
            }
            else
            {
                finalResult.Append(((char)(capturedString[i] - power)).ToString());
            }
        }
    }

    private static int GiveCurrentSymbolAndReturnSpecificPower(string value)
    {
        switch (value)
        {
            case "$":
                return 1;
            case "%":
                return 2;
            case "&":
                return 3;
            case "'":
                return 4;
        }
        return 0;
    }
}