using System;
using System.Collections.Generic;
using System.Linq;

//sorting must be fix in the end

public class CubicAssault
{
    private const int MaxValue = 1000000;

    public static void Main()
    {
        var input = Console.ReadLine();
        List<Assault> stats = new List<Assault>();
        var singleUnit = new Assault();

        while (input != "Count em all")
        {
            var tokens = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();

            string region = tokens[0];
            string meteorType = tokens[1];
            int count = int.Parse(tokens[2]);

            if (!stats.Any(a => a.Region == region))
            {
                singleUnit.Region = region;
                if (count >= MaxValue && meteorType != "Black")
                {
                    string newMeteorType = ChangeMeteorType(meteorType);
                    singleUnit.MeteorType[newMeteorType] += count / MaxValue;
                    count %= MaxValue;
                }

                singleUnit.MeteorType[meteorType] += count;

                stats.Add(singleUnit);
                singleUnit = new Assault();
            }
            else
            {
                int index = stats.FindIndex(a => a.Region == region);
                stats[index].MeteorType[meteorType] += count;

                if (stats[index].MeteorType[meteorType] >= MaxValue && meteorType != "Black")
                {
                    long newCount = stats[index].MeteorType[meteorType] / MaxValue;
                    stats[index].MeteorType[meteorType] = stats[index].MeteorType[meteorType] % MaxValue;
                    string newMeteorType = ChangeMeteorType(meteorType);
                    stats[index].MeteorType[newMeteorType] += newCount;

                    if (newMeteorType == "Red" && stats[index].MeteorType[newMeteorType] >= MaxValue)
                    {
                        newCount = stats[index].MeteorType[newMeteorType] / MaxValue;
                        stats[index].MeteorType[newMeteorType] = stats[index].MeteorType[newMeteorType] % MaxValue;
                        newMeteorType = "Black";
                        stats[index].MeteorType[newMeteorType] += newCount;
                    }
                }
            }
            input = Console.ReadLine();
        }
        Console.WriteLine();

        var order = stats.OrderByDescending(r => r.MeteorType["Black"])
        .ThenBy(n => n.Region.Length)
        .ThenBy(a => a.Region);

        foreach (var region in order)
        {
            Console.WriteLine(region.Region);
            foreach (var meteor in region.MeteorType.OrderByDescending(c => c.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
            }
        }
    }

    private static string ChangeMeteorType(string meteorType)
    {
        switch (meteorType)
        {
            case "Green": return "Red";
            case "Red": return "Black";
            default: return "Black";
        }
    }
}

public class Assault
{
    public string Region;
    public Dictionary<string, long> MeteorType;

    public Assault()
    {
        this.MeteorType = new Dictionary<string, long>();
        MeteorType["Black"] = 0L;
        MeteorType["Red"] = 0L;
        MeteorType["Green"] = 0L;
    }
}