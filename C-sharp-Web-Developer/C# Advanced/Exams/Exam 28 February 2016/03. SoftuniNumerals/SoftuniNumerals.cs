using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

public class SoftuniNumerals
{
    public static void Main()
    {
        string pattern = @"(aba|bcc|aa|cc|cdc)";
        string input = Console.ReadLine();

        Match match = Regex.Match(input, pattern);
        Queue<string> numbers = new Queue<string>();

        while (match.Success)
        {
            numbers.Enqueue(match.Value);
            match = match.NextMatch();
        }

        StringBuilder convertedNumber = new StringBuilder();

        while (numbers.Count > 0)
        {
            switch (numbers.Dequeue())
            {
                case "aa":
                    convertedNumber.Append("0");
                    break;
                case "aba":
                    convertedNumber.Append("1");
                    break;
                case "bcc":
                    convertedNumber.Append("2");
                    break;
                case "cc":
                    convertedNumber.Append("3");
                    break;
                case "cdc":
                    convertedNumber.Append("4");
                    break;
            }
        }

        BigInteger finalNumber = 0L;
        for (int i = 0; i < convertedNumber.Length; i++)
        {
            int pow = convertedNumber.Length - 1 - i;
            int currentNum = int.Parse(convertedNumber[i].ToString());
            BigInteger basePow = BigInteger.Pow(5, pow);
            finalNumber += (BigInteger)(currentNum * basePow);
        }
        Console.WriteLine(finalNumber);
    }
}