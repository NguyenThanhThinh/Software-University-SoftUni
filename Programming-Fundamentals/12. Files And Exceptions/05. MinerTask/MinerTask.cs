using System;
using System.Collections.Generic;
using System.IO;

class MinerTask
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines(@"../../input.txt");
        var collectedResource = new Dictionary<string, int>();
        string resourceName = string.Empty;
        int quantity = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                resourceName = input[i];
            }
            else
            {
                quantity = int.Parse(input[i]);
            }

            if (!collectedResource.ContainsKey(resourceName))
            {
                collectedResource[resourceName] = 0;
            }
            else
            {
                collectedResource[resourceName] += quantity;
            }
        }

        foreach (var resource in collectedResource)
        {
            File.AppendAllText(@"../../output.txt", resource.Key + " -> " + resource.Value + Environment.NewLine);
        }
    }
}