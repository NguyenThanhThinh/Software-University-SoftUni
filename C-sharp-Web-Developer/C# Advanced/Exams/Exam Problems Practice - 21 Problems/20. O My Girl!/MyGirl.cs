using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class MyGirl
{
    public static void Main()
    {
        var key = Console.ReadLine();
        var cryptedMsg = Console.ReadLine();
        var decryptedMsg = string.Empty;
        string pattern = GeneratePattern(key);
        var wholeCryptedMsg = new StringBuilder();

        while (!cryptedMsg.Equals("END"))
        {
            wholeCryptedMsg.Append(cryptedMsg);
            cryptedMsg = Console.ReadLine();
        }

        Match match = Regex.Match(wholeCryptedMsg.ToString(), pattern);

        while (match.Success)
        {
            decryptedMsg += match.Groups[1].Value;
            match = match.NextMatch();
        }

        var finalDecryptedMsg = Regex.Replace(decryptedMsg, @"\s+", "\x20");
        Console.WriteLine(finalDecryptedMsg);
    }

    private static string GeneratePattern(string key)
    {
        string firstChar = key[0].ToString();
        string lastChar = key[key.Length - 1].ToString();
        List<string> specialChars = new List<string>();
        specialChars = FindSpecialCharsInKey(key);
        var leftPattern = new StringBuilder();
        var rightPattern = new StringBuilder();
        if (!(char.IsLetter(firstChar[0]) || char.IsDigit(firstChar[0])))
        {
            leftPattern.Append("\\" + firstChar);
            rightPattern.Append(firstChar);
        }
        else
        {
            leftPattern.Append(firstChar);
            rightPattern.Append(firstChar);
        }

        for (int i = 1; i < key.Length - 1; i++)
        {
            if (specialChars.Contains(key[i].ToString()))
            {
                leftPattern.Append("\\" + key[i].ToString());
                rightPattern.Append("\\" + key[i].ToString());
            }
            else
            {
                if (char.IsLetter(key[i]))
                {
                    if (char.IsLower(key[i]))
                    {
                        leftPattern.Append("[a-z]*");
                        rightPattern.Append("[a-z]*");
                    }
                    else
                    {
                        leftPattern.Append("[A-Z]*");
                        rightPattern.Append("[A-Z]*");
                    }
                }
                else
                {
                    leftPattern.Append("[0-9]*");
                    rightPattern.Append("[0-9]*");
                }
            }
        }

        if (!(char.IsLetter(lastChar[0]) || char.IsDigit(lastChar[0])))
        {
            leftPattern.Append("\\" + lastChar);
            rightPattern.Append(lastChar);
        }
        else
        {
            leftPattern.Append(lastChar);
            rightPattern.Append(lastChar);
        }
        leftPattern.Append("(.{2,6})");
        var newPattern = leftPattern.Append(rightPattern.ToString()).ToString();

        return newPattern;
    }

    private static List<string> FindSpecialCharsInKey(string key)
    {
        var chars = new List<string>();

        for (int i = 0; i < key.Length; i++)
        {
            if (!(char.IsDigit(key[i]) || char.IsLetter(key[i])))
            {
                chars.Add(key[i].ToString());
            }
        }
        return chars;
    }
}