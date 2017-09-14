using System;
using System.Linq;

class CountSymbols
{
    static void Main()
    {
        var test = Console.ReadLine().ToCharArray().ToList();

        var sort = test.GroupBy(i => i);
        var sortedDict = from entry in sort orderby entry.Key ascending select entry;

        foreach (var grp in sortedDict)
        {
            Console.WriteLine("{0} {1}", grp.Key, grp.Count());
        }
    }
}