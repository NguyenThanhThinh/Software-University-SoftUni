using System;
using System.Collections.Generic;

public class CountSymbols
{
    public static void Main()
    {
        var countSymbolsDic = new SortedDictionary<char, int>();
        var input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (!countSymbolsDic.ContainsKey(input[i]))
            {
                countSymbolsDic[input[i]] = 1;
            }
            else
            {
                countSymbolsDic[input[i]] += 1;
            }
        }

        foreach (var symbol in countSymbolsDic)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}