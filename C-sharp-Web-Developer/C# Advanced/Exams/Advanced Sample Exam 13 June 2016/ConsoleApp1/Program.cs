using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace iuni06
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> map = new SortedDictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            string method = "";
            string invoke = "";

            string pattern = @"([.])(.*?)\(";

            string pattern2 = @"([^a-zA-Z\.])([a-zA-Z0-9]+)\([a-zA-Z0-9]+\)";
            Regex regex = new Regex(pattern);
            Regex reg = new Regex(pattern2);
            string currentMethod = "";

            for (int j = 0; j < n; j++)
            {
                string line = Console.ReadLine();
                string[] input = line.Split();

                for (int i = 0; i < input.Length; i++)
                {
                    string current = input[i];

                    if (line.Contains("static"))
                    {
                        if (current == "static")
                        {
                            method = input[i + 2];
                            int index = method.IndexOf("(");
                            method = method.Substring(0, index);

                            if (!map.ContainsKey(method))
                            {
                                map.Add(method, new List<string>());
                                currentMethod = method;
                                method = "";
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (line == string.Empty)
                        {
                            break;
                        }
                        MatchCollection match = regex.Matches(line);
                        foreach (Match item in match)
                        {
                            invoke = item.Groups[2].Value;
                            map[currentMethod].Add(invoke);
                        }
                        Match mat = reg.Match(line);
                        if (mat.Success)
                        {
                            invoke = mat.Groups[2].Value;
                            map[currentMethod].Add(invoke);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            foreach (var item in map.OrderByDescending(x => x.Value.Count))
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
}
