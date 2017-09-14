using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GreedyTimes
{
    public const string Gold = "Gold";
    public const string Gem = "Gem";
    public const string Money = "Cash";

    public static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        var items = Console.ReadLine().Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var bag = new Dictionary<string, Dictionary<string, long>>();
        long currentCapacity = 0;

        for (int i = 0; i < items.Length; i += 2)
        {
            string item = items[i];
            long itemValue = long.Parse(items[i + 1]);

            if (IsItemGold(item))
            {
                if (currentCapacity + itemValue <= bagCapacity)
                {
                    currentCapacity += itemValue;

                    if (!bag.ContainsKey(Gold))
                    {
                        bag[Gold] = new Dictionary<string, long>();
                        bag[Gold][Gold] = 0L;
                    }
                    bag[Gold][Gold] += itemValue;
                }
            }
            else if (IsItemGem(item))
            {
                if (currentCapacity + itemValue <= bagCapacity && GetTotalGem(bag) + itemValue <= GetTotalGold(bag))
                {

                    currentCapacity += itemValue;

                    if (!bag.ContainsKey(Gem))
                    {
                        bag[Gem] = new Dictionary<string, long>();
                        bag[Gem][item] = itemValue;
                    }
                    else
                    {
                        if (bag[Gem].ContainsKey(item))
                        {
                            bag[Gem][item] += itemValue;
                        }
                        else
                        {
                            bag[Gem][item] = itemValue;
                        }
                    }
                }
            }
            else if (IsItemMoney(item))
            {
                if (currentCapacity + itemValue <= bagCapacity && GetTotalMoney(bag) + itemValue <= GetTotalGem(bag))
                {

                    currentCapacity += itemValue;

                    if (!bag.ContainsKey(Money))
                    {
                        bag[Money] = new Dictionary<string, long>();
                        bag[Money][item] = itemValue;
                    }
                    else
                    {
                        if (bag[Money].ContainsKey(item))
                        {
                            bag[Money][item] += itemValue;
                        }
                        else
                        {
                            bag[Money][item] = itemValue;
                        }
                    }
                }
            }
        }

        var sb = new StringBuilder();

        foreach (var type in bag.OrderByDescending(t => t.Value.Sum(v => v.Value)))
        {
            sb.AppendLine($"<{type.Key}> ${type.Value.Sum(v => v.Value)}");
            foreach (var item in type.Value.OrderByDescending(t => t.Key).ThenBy(v => v.Value))
            {
                sb.AppendLine($"##{item.Key} - {item.Value}");
            }
        }

        Console.WriteLine(sb);
    }

    private static long GetTotalMoney(Dictionary<string, Dictionary<string, long>> bag)
    {
        long totalMoney = 0L;

        if (bag.ContainsKey(Money))
        {
            foreach (var currentMoney in bag[Money])
            {
                totalMoney += currentMoney.Value;
            }
        }

        return totalMoney;
    }

    private static long GetTotalGem(Dictionary<string, Dictionary<string, long>> bag)
    {
        long totalGems = 0L;

        if (bag.ContainsKey(Gem))
        {
            foreach (var currentGem in bag[Gem])
            {
                totalGems += currentGem.Value;
            }
        }

        return totalGems;
    }

    private static long GetTotalGold(Dictionary<string, Dictionary<string, long>> bag)
    {
        long totalGold = 0L;

        if (bag.ContainsKey(Gold))
        {
            totalGold = bag[Gold][Gold];
        }

        return totalGold;
    }

    public static bool IsItemGold(string item)
    {
        if (item.ToLower() == "gold")
        {
            return true;
        }
        return false;
    }

    public static bool IsItemGem(string item)
    {
        if (item.ToLower().EndsWith("gem") && item.Length > 3)
        {
            return true;
        }
        return false;
    }

    public static bool IsItemMoney(string item)
    {
        if (item.Length == 3)
        {
            return true;
        }
        return false;
    }
}