using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ShmoogleCounter
{
    public static void Main()
    {
        var currentLine = Console.ReadLine();
        var intNames = new Dictionary<int, List<string>>();
        var doubleNames = new Dictionary<int, List<string>>();

        var variablePattern = @"(\bdouble\b|\bint\b)\s*([a-z]{1,}[a-zA-Z]*)";
        var newScopePattern = @"(public|static|private)(static)*";
        var ifScopePattern = @"(if\s(.+)|\belse\b)";
        int scopeNumber = 0;

        while (!currentLine.Equals("//END_OF_CODE"))
        {
            if (Regex.Match(currentLine, newScopePattern).Success || Regex.Match(currentLine, ifScopePattern).Success)
            {
                scopeNumber++;
            }

            Match match = Regex.Match(currentLine, variablePattern);
            if (match.Success && match.Groups[1].Value.ToLower().Equals("double"))
            {
                string name = match.Groups[2].Value;
                if (!doubleNames.ContainsKey(scopeNumber))
                {
                    doubleNames[scopeNumber] = new List<string>();
                }
                if (!doubleNames[scopeNumber].Contains(name))
                {
                    doubleNames[scopeNumber].Add(name);
                }
            }
            else if (match.Success && match.Groups[1].Value.ToLower().Equals("int"))
            {
                string name = match.Groups[2].Value;

                if (!intNames.ContainsKey(scopeNumber))
                {
                    intNames[scopeNumber] = new List<string>();
                }
                if (!intNames[scopeNumber].Contains(name))
                {
                    intNames[scopeNumber].Add(name);

                }
            }
            currentLine = Console.ReadLine();
        }
        Console.WriteLine();

        List<string> doubleResult = new List<string>();
        foreach (var doubleName in doubleNames)
        {
            foreach (var output in doubleName.Value)
            {
                doubleResult.Add(output);
            }
        }

        List<string> intResult = new List<string>();
        foreach (var intName in intNames)
        {
            foreach (var output in intName.Value)
            {
                intResult.Add(output);
            }
        }

        if (doubleResult.Count > 0)
        {
            Console.WriteLine($"Doubles: {string.Join(", ", doubleResult.OrderBy(n => n))}");
        }
        else
        {
            Console.WriteLine($"Doubles: None");
        }

        if (intResult.Count > 0)
        {
            Console.WriteLine($"Ints: {string.Join(", ", intResult.OrderBy(n => n))}");
        }
        else
        {
            Console.WriteLine($"Ints: None");
        }
    }
}