using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class JediDreams
{
    public static void Main()
    {
        var text = new List<string>();
        int n = int.Parse(Console.ReadLine());
        var methods = new SortedDictionary<string, List<string>>();

        for (int i = 0; i < n; i++)
        {
            text.Add(Console.ReadLine());
        }

        string methodNamePattern = @"static\s\w+\s(\w+)";
        string invokedMethodPattern = @"\b\.[A-Za-z]+\(.*\)?";

        string invokeMethods = string.Empty;
        string lastMethodName = string.Empty;

        for (int i = 0; i < text.Count; i++)
        {
            bool toCheckForGeneralMethod = true;
            var regex = Regex.Match(text[i], methodNamePattern);
            if (regex.Success)
            {

                toCheckForGeneralMethod = false;
                string methodName = regex.Groups[1].Value;
                lastMethodName = methodName;
                if (!methods.ContainsKey(methodName))
                {
                    methods[methodName] = new List<string>();
                }
            }

            regex = Regex.Match(text[i], invokedMethodPattern);
            if (regex.Success)
            {
                toCheckForGeneralMethod = false;
                invokeMethods = regex.Value;
                string splitInvokedMethods = @"(?<=\.)([A-Za-z]+)";
                var matchAllMethodsOnCurrentLine = Regex.Match(invokeMethods, splitInvokedMethods);

                while (matchAllMethodsOnCurrentLine.Success)
                {
                    methods[lastMethodName].Add(matchAllMethodsOnCurrentLine.Value);
                    matchAllMethodsOnCurrentLine = matchAllMethodsOnCurrentLine.NextMatch();
                }
            }

            // I can improve this, as even if the row doesn't have any match I will go through all keys and try to match them
            if (toCheckForGeneralMethod)
            {
                foreach (var method in methods)
                {
                    var generalMethodRegex = Regex.Match(text[i], method.Key.ToString());
                    if (generalMethodRegex.Success)
                    {
                        methods[lastMethodName].Add(method.Key.ToString());
                    }
                }
            }
        }

        //foreach (var method in methods.OrderByDescending(m => m.Value.Count).ThenBy(y => y).ThenBy(m => m.Value))
        //{
        //    if (method.Value.Count == 0)
        //    {
        //        Console.WriteLine($"{method.Key} --> None");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value)}");
        //    }
        //}

        foreach (var item in methods.OrderByDescending(x => x.Value.Count))
        {
            Console.Write(item.Key + " -> " + item.Value.Count + " -> ");

            StringBuilder list = new StringBuilder();
            string result = "";
            foreach (var inner in item.Value.OrderBy(x => x))
            {
                list.Append(inner + ", ");
            }
            result = list.ToString();
            result = result.Substring(0, result.Length - 2);
            Console.WriteLine(result);
        }
    }
}