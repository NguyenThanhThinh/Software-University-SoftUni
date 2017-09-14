using System;
using System.Collections.Generic;
using System.Linq;

public class CollectResources
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        int n = int.Parse(Console.ReadLine());
        string[] resources = new string[] { "stone", "gold", "wood", "food" };
        int highestSumOfCollectedResource = 0;
        HashSet<int> visitedIndexes = new HashSet<int>();

        //N times reading and going through different paths
        for (int i = 0; i < n; i++)
        {
            int collectedResources = 0;
            var indexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currentIndex = indexes[0];

            while (!visitedIndexes.Contains(currentIndex))
            {
                var splitResource = input[currentIndex].Split('_').ToArray();
                string resourceName = splitResource[0];
                int amount = splitResource.Count() > 1 ? int.Parse(splitResource[1]) : 1;

                if (resources.Contains(resourceName))
                {
                    collectedResources += amount;
                    visitedIndexes.Add(currentIndex);
                }

                if (currentIndex + indexes[1] >= input.Length)
                {
                    currentIndex = (indexes[1] % input.Length) == 0 ? currentIndex : (currentIndex + indexes[1]) % input.Length;
                }
                else
                {
                    currentIndex += indexes[1];
                }
            }
            visitedIndexes.Clear();

            if (collectedResources > highestSumOfCollectedResource)
            {
                highestSumOfCollectedResource = collectedResources;
            }
        }
        Console.WriteLine(highestSumOfCollectedResource);
    }
}