using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Files
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var directories = new Dictionary<string, SortedDictionary<string, long>>();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            var root = input.Substring(0, input.IndexOf('\\'));
            var filename = input.Substring(input.LastIndexOf('\\') + 1, (input.IndexOf(';') - input.LastIndexOf('\\')) - 1);
            var size = long.Parse(input.Substring(input.IndexOf(';') + 1, ((input.Length - 1) - input.IndexOf(';')) ));

            if (!directories.ContainsKey(root))
            {
                directories[root] = new SortedDictionary<string, long>();
                directories[root][filename] = size;
            }
            else
            {
                directories[root][filename] = size;
            }
        }

        string searchCriteria = Console.ReadLine();

        var fileType = searchCriteria.Substring(0, searchCriteria.IndexOf(' '));
        var location = searchCriteria.Substring(searchCriteria.LastIndexOf(' ') + 1, (searchCriteria.Length - searchCriteria.LastIndexOf(' ') - 1));

        foreach (var root in directories)
        {
            foreach (var type in root.Value.OrderByDescending(p => p.Value))
            {
                var currentFile = type.Key;
                var currentFileType = currentFile.Substring(currentFile.LastIndexOf('.') + 1, currentFile.Length - currentFile.LastIndexOf('.') - 1);
                if (root.Key == location && currentFileType == fileType)
                {
                    result.AppendLine($"{currentFile} - {type.Value} KB");
                }
            }
        }

        if (result.Length == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(result.ToString());
        }
    }
}