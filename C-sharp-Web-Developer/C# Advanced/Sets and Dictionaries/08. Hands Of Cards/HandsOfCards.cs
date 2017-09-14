using System;
using System.Collections.Generic;
using System.Linq;

public class HandOfCards
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var cardsPower = GetCardsPower();
        var cardsType = GetCardsType();
        var peopleValue = new Dictionary<string, HashSet<int>>();

        while (input != "JOKER")
        {
            var separatedInput = input.Split(':');
            var name = separatedInput[0];
            var cards = separatedInput[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cards.Length; i++)
            {
                var powerSymbol = (cards[i]).Substring(0, cards[i].Length - 1);
                var symbolType = cards[i].Substring(cards[i].Length - 1, 1);
                var sum = cardsPower[powerSymbol] * cardsType[symbolType];

                if (!peopleValue.ContainsKey(name))
                {
                    peopleValue[name] = new HashSet<int>();
                }
                peopleValue[name].Add(sum);
            }
            input = Console.ReadLine();
        }

        foreach (var value in peopleValue)
        {
            Console.WriteLine("{0}: {1}", value.Key, value.Value.Sum());
        }
    }

    private static Dictionary<string, int> GetCardsPower()
    {
        var cardsPower = new Dictionary<string, int>();
        for (int i = 2; i <= 10; i++)
        {
            cardsPower.Add(i.ToString(), i);
        }

        cardsPower["J"] = 11;
        cardsPower["Q"] = 12;
        cardsPower["K"] = 13;
        cardsPower["A"] = 14;

        return cardsPower;
    }

    private static Dictionary<string, int> GetCardsType()
    {
        var cardsType = new Dictionary<string, int>();

        cardsType["S"] = 4;
        cardsType["H"] = 3;
        cardsType["D"] = 2;
        cardsType["C"] = 1;

        return cardsType;
    }
}