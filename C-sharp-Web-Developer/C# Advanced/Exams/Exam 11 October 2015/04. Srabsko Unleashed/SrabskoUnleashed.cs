using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

class SurbianUnleashed
{
    static void Main()
    {
        string input = Console.ReadLine();
        var result = new Dictionary<string, Dictionary<string, BigInteger>>();
        BigInteger ticketsPrice = 0L;
        BigInteger ticketsCount = 0L;

        string pattern = @"^(([^\s\d]+\x20){1,3})@(([^\s\d]+\x20){1,3})(\d+\x20)(\d+)$";

        while (input != "End")
        {
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string venue = match.Groups[3].Value.Trim();
                string singer = match.Groups[1].Value.Trim();
                ticketsPrice = BigInteger.Parse(match.Groups[5].Value.Trim());
                ticketsCount = BigInteger.Parse(match.Groups[6].Value.Trim());
                result = FillData(singer, venue, ticketsPrice, ticketsCount, result);
            }
            input = Console.ReadLine();
        }

        foreach (var venue in result)
        {
            Console.WriteLine(venue.Key.TrimStart('@'));
            foreach (var singer in venue.Value.OrderByDescending(n => n.Value))
            {
                Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
            }
        }
    }

    private static Dictionary<string, Dictionary<string, BigInteger>> FillData(string singer, string venue, BigInteger ticketsPrice, BigInteger ticketsCount,
        Dictionary<string, Dictionary<string, BigInteger>> resultBackUp)
    {
        BigInteger money = ticketsCount * ticketsPrice;
        if (!resultBackUp.ContainsKey(venue))
        {
            resultBackUp[venue] = new Dictionary<string, BigInteger>();
            resultBackUp[venue].Add(singer, money);
        }
        else
        {
            if (!resultBackUp[venue].ContainsKey(singer))
            {
                resultBackUp[venue].Add(singer, money);
            }
            else
            {
                resultBackUp[venue][singer] += money;
            }
        }
        return resultBackUp;
    }
}