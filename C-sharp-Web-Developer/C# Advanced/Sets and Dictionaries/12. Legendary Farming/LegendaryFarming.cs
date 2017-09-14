using System;
using System.Collections.Generic;
using System.Linq;

public class LegendaryFarming
{
    public static void Main()
    {
        var keyMaterials = KeyMaterials();
        var junk = new SortedDictionary<string, int>();

        while (ToContinue(keyMaterials))
        {
            var input = Console.ReadLine().Split(' ');
            for (int i = 1; i < input.Length; i += 2)
            {
                var material = input[i].ToLower();
                var materialValue = int.Parse(input[i - 1]);
                if (material == "shards" || input[i].ToLower() == "fragments" || input[i].ToLower() == "motes")
                {
                    keyMaterials[material] += materialValue;
                }
                else
                {
                    if (!junk.ContainsKey(material))
                    {
                        junk[material] = materialValue;
                    }
                    else
                    {
                        junk[material] += materialValue;
                    }
                }

                if (!ToContinue(keyMaterials))
                {
                    break;
                }
            }
        }

        string keyMaterialObtained = KeyMaterialObtained(keyMaterials);
        string itemObtained = ItemObtained(keyMaterialObtained);
        keyMaterials[keyMaterialObtained] -= 250;

        Console.WriteLine("{0} obtained!", itemObtained);

        foreach (var material in keyMaterials.OrderByDescending(n => n.Value).ThenBy(m => m.Key))
        {
            Console.WriteLine("{0}: {1}", material.Key, material.Value);
        }

        foreach (var material in junk)
        {
            Console.WriteLine("{0}: {1}", material.Key, material.Value);
        }
    }

    private static string ItemObtained(string keyMaterialObtained)
    {
        switch (keyMaterialObtained)
        {
            case "shards":
                return "Shadowmourne";
            case "fragments":
                return "Valanyr";
            case "motes":
                return "Dragonwrath";
            default:
                break;
        }
        return "0";
    }

    private static string KeyMaterialObtained(Dictionary<string, int> keyMaterials)
    {
        foreach (var item in keyMaterials)
        {
            if (item.Value >= 250)
            {
                return item.Key;
            }
        }
        return "0";
    }

    private static bool ToContinue(Dictionary<string, int> keyMaterials)
    {
        foreach (var item in keyMaterials)
        {
            if (item.Value >= 250)
            {
                return false;
            }
        }
        return true;
    }

    private static Dictionary<string, int> KeyMaterials()
    {
        var keyMaterials = new Dictionary<string, int>();
        keyMaterials["shards"] = 0;
        keyMaterials["fragments"] = 0;
        keyMaterials["motes"] = 0;
        return keyMaterials;
    }
}