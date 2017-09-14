using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class SurbianUnleashed
{
    static void Main()
    {
        string input = Console.ReadLine();
        var result = new Dictionary<string, Dictionary<string, BigInteger>>();
        BigInteger ticketsPrice = 0L;
        BigInteger ticketsCount = 0L;

        while (input != "End")
        {
            var separatedInput = input.Split(' ');

            if (separatedInput.Length >= 4)
            {
                string venue = GetVenue(separatedInput);
                string singer = GetSinger(separatedInput, venue);
                string ticketPriceString = separatedInput[separatedInput.Length - 2];
                string ticketCountString = separatedInput[separatedInput.Length - 1];
                bool parseWorked = checkIfParseWork(ticketPriceString, ticketCountString);

                if (parseWorked)
                {
                    ticketsPrice = BigInteger.Parse(separatedInput[separatedInput.Length - 2]);
                    ticketsCount = BigInteger.Parse(separatedInput[separatedInput.Length - 1]);
                }

                if (singer != "0" && venue != "0" && parseWorked)
                {
                    result = FillData(singer, venue, ticketsPrice, ticketsCount, result);
                }
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

    private static bool checkIfParseWork(string ticketsPrice, string ticketsCount)
    {
        BigInteger ticketPrice = 0L;
        BigInteger ticketCount = 0L;

        bool tryParsePrice = BigInteger.TryParse(ticketsPrice, out ticketPrice);
        bool tryParseCount = BigInteger.TryParse(ticketsCount, out ticketCount);

        if (tryParseCount && tryParsePrice)
        {
            return true;
        }
        else
        {
            return false;
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

    private static string GetSinger(string[] separatedInput, string venue)
    {
        string singer = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            if (venue != "0")
            {
                if (!separatedInput[i].StartsWith("@"))
                {
                    singer += separatedInput[i];
                    singer += " ";
                }
                else
                {
                    if (singer == string.Empty)
                    {
                        return "0";
                    }
                    else
                    {
                        singer = singer.TrimEnd(' ');
                        return singer;
                    }
                }
            }
        }
        return "0";
    }

    private static string GetVenue(string[] separatedInput)
    {
        for (int i = 1; i < 4; i++)
        {
            if (separatedInput[i].StartsWith("@"))
            {
                if (!Char.IsDigit(separatedInput[i + 1][0]))
                {
                    if (!Char.IsDigit(separatedInput[i + 2][0]))
                    {
                        return separatedInput[i] + " " + separatedInput[i + 1] + " " + separatedInput[i + 2];
                    }
                    else
                    {
                        return separatedInput[i] + " " + separatedInput[i + 1];
                    }
                }
                else
                {
                    return separatedInput[i];
                }
            }
        }
        return "0";
    }
}