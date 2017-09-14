using System;
using System.Collections.Generic;

public class MinerTask
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<string> inputList = new List<string>();
        Dictionary<string, int> resourceCollection = new Dictionary<string, int>();

        while (input != "stop")
        {
            inputList.Add(input);
            input = Console.ReadLine();
        }

        for (int i = 0; i < inputList.Count; i++)
        {
            if (i % 2 == 0)
            {
                if (!resourceCollection.ContainsKey(inputList[i]))
                {
                    resourceCollection.Add(inputList[i], 0);
                }
            }
            else
            {
                resourceCollection[inputList[i - 1]] += int.Parse(inputList[i]);
            }
        }

        foreach (var item in resourceCollection)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }
    }
}