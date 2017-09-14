using System;
using System.Collections.Generic;
using System.Linq;

class Files
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var directiories = new Dictionary<string, Dictionary<string, long>>();

        for (int i = 0; i < n; i++)
        {
            var splitedLine = Console.ReadLine().Split('\\');
            var root = splitedLine[0];
            var extensionSize = splitedLine[splitedLine.Length - 1].Split(';');
            var extention = extensionSize[0];
            long size = long.Parse(extensionSize[1]);

            if (!directiories.ContainsKey(root))
            {
                directiories[root] = new Dictionary<string, long>();
                directiories[root][extention] = size;
            }
            else
            {
                directiories[root][extention] = size;
            }
        }

        var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var searchExtention = command[0];
        var searchInRoot = command[2];

        var result = directiories.Where(r => r.Key == searchInRoot);
        bool haveHits = false;

        foreach (var file in result)
        {
            foreach (var item in file.Value.OrderByDescending(z => z.Value).ThenBy(a => a.Key))
            {
                if (item.Key.EndsWith(searchExtention))
                {
                    Console.WriteLine($"{item.Key} - {item.Value} KB");
                    haveHits = true;
                }
            }
        }

        if (haveHits == false)
        {
            Console.WriteLine("No");
        }
    }
}