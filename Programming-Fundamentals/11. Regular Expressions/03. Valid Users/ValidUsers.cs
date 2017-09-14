using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ValidUsers
{
    static void Main()
    {
        string line = Console.ReadLine();
        string splitter = @"\W+";
        string[] input = Regex.Replace(line, splitter, " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string pattern = @"(\b[A-Za-z]\w{2,24}\b)";
        Regex regex = new Regex(pattern);
        int sum = 0;
        string firstName = string.Empty;
        string secondName = string.Empty;
        var result = new List<string>();

        for (int i = 0; i < input.Length; i++)
        {
            if (regex.IsMatch(input[i]))
            {
                result.Add(input[i]);
            }
        }

        for (int i = 0; i < result.Count - 1; i++)
        {
            if (sum < result[i].Length + result[i + 1].Length)
            {
                sum = result[i].Length + result[i + 1].Length;
                firstName = result[i];
                secondName = result[i + 1];
            }
        }

        Console.WriteLine("{0}\n{1}", firstName, secondName);
    }
}