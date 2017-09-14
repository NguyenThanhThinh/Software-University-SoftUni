using System;
using System.Text.RegularExpressions;

public class SeriesOfLetters
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            pattern = string.Format($"[{currentChar}]+");
            Regex regex = new Regex(pattern);
            input = regex.Replace(input, currentChar.ToString());
        }
        Console.WriteLine(input);
    }
}