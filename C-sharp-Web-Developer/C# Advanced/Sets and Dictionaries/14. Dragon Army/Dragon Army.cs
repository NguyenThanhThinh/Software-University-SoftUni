using System;
using System.Collections.Generic;
using System.Linq;

public class DragonArmy
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var dragonArmy = new Dictionary<string, SortedDictionary<string, List<long>>>();
        var totalStatsPerType = new Dictionary<string, List<long>>();
        var averageTotalStatsPerType = new Dictionary<string, List<double>>();

        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split(' ');
            string type = line[0];
            string name = line[1];
            int damage = ParseDamage(line[2]);
            int health = ParseHealth(line[3]);
            int armor = ParseArmor(line[4]);

            dragonArmy = FillData(type, name, damage, health, armor, dragonArmy);
            totalStatsPerType = CalculateTotalStatsPerType(type, damage, health, armor, totalStatsPerType);

        }
        //averageTotalStatsPerType = CalculateAverageStatsPerType(totalStatsPerType, dragonArmy);

        foreach (var value in dragonArmy)
        {
            Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", value.Key, value.Value.Select(x => x.Value[0]).Average(), value.Value.Select(x => x.Value[1]).Average(), value.Value.Select(x => x.Value[2]).Average());
            foreach (var type in dragonArmy[value.Key])
            {
                Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", type.Key, type.Value[0], type.Value[1], type.Value[2]);
            }
        }
    }

    // For some reason the calculation of Avarage don't work corectly, above in the code, instrad of showing the result using this method we use LINQ .Avarage

    //private static Dictionary<string, List<double>> CalculateAverageStatsPerType(Dictionary<string, List<long>> totalStatsPerType,
    //    Dictionary<string, SortedDictionary<string, List<long>>> dragonArmy)
    //{
    //    var averageStatsPerType = new Dictionary<string, List<double>>();
    //    List<int> numberOfDragonsPerType = new List<int>();
    //    double averageSum = 0.0d;

    //    foreach (var type in dragonArmy)
    //    {
    //        numberOfDragonsPerType.Add(type.Value.Count());
    //    }

    //    int p = 0;
    //    foreach (var stat in totalStatsPerType)
    //    {
    //        if (!averageStatsPerType.ContainsKey(stat.Key))
    //        {
    //            averageStatsPerType[stat.Key] = new List<double>();
    //        }

    //        for (int i = 0; i < 3; i++)
    //        {
    //            averageSum = (double)stat.Value[i] / numberOfDragonsPerType[p];
    //            averageStatsPerType[stat.Key].Add(averageSum);
    //        }
    //        p++;
    //    }
    //    return averageStatsPerType;

    //}

    private static Dictionary<string, List<long>> CalculateTotalStatsPerType(string type, int damage, int health, int armor,
        Dictionary<string, List<long>> totalStatsPerType)
    {
        if (!totalStatsPerType.ContainsKey(type))
        {
            totalStatsPerType[type] = new List<long>();
            totalStatsPerType[type].Add(damage);
            totalStatsPerType[type].Add(health);
            totalStatsPerType[type].Add(armor);
        }
        else
        {
            totalStatsPerType[type][0] += damage;
            totalStatsPerType[type][1] += health;
            totalStatsPerType[type][2] += armor;
        }
        return totalStatsPerType;
    }

    private static Dictionary<string, SortedDictionary<string, List<long>>> FillData(string type, string name, int damage, int health, int armor,
        Dictionary<string, SortedDictionary<string, List<long>>> dragonArmy)
    {
        if (!dragonArmy.ContainsKey(type))
        {
            dragonArmy[type] = new SortedDictionary<string, List<long>>();
            dragonArmy[type].Add(name, new List<long>());
            dragonArmy[type][name].Add(damage);
            dragonArmy[type][name].Add(health);
            dragonArmy[type][name].Add(armor);
        }
        else
        {
            if (!dragonArmy[type].ContainsKey(name))
            {
                dragonArmy[type].Add(name, new List<long>());
                dragonArmy[type][name].Add(damage);
                dragonArmy[type][name].Add(health);
                dragonArmy[type][name].Add(armor);
            }
            else
            {
                dragonArmy[type][name][0] = damage;
                dragonArmy[type][name][1] = health;
                dragonArmy[type][name][2] = armor;
            }
        }
        return dragonArmy;
    }

    private static int ParseArmor(string armor)
    {
        int intParse = 0;
        bool parse = int.TryParse(armor, out intParse);

        if (parse)
        {
            return intParse;
        }
        else
        {
            return 10;
        }
    }

    private static int ParseHealth(string health)
    {
        int intParse = 0;
        bool parse = int.TryParse(health, out intParse);

        if (parse)
        {
            return intParse;
        }
        else
        {
            return 250;
        }
    }

    private static int ParseDamage(string damage)
    {
        int intParse = 0;
        bool parse = int.TryParse(damage, out intParse);

        if (parse)
        {
            return intParse;
        }
        else
        {
            return 45;
        }
    }
}