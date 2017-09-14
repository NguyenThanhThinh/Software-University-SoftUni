using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class LittleJohn
{
    public static void Main()
    {
        string pattern = @"(?<small>>-{5}>)|(?<medium>>{2}-{5}>)|(?<large>>{3}-{5}>{2})";
        Regex regex = new Regex(pattern);
        int smallArrow = 0;
        int mediumArrow = 0;
        int largeArrow = 0;

        for (int i = 0; i < 4; i++)
        {
            var input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            for (int p = 0; p < matches.Count; p++)
            {
                smallArrow = matches[p].Groups["small"].Success ? smallArrow + matches[p].Groups["small"].Captures.Count : smallArrow;
                mediumArrow = matches[p].Groups["medium"].Success ? mediumArrow + matches[p].Groups["medium"].Captures.Count : mediumArrow;
                largeArrow = matches[p].Groups["large"].Success ? largeArrow + matches[p].Groups["large"].Captures.Count : largeArrow;
            }
        }

        string num = smallArrow.ToString() + mediumArrow + largeArrow;
        var numInBin = Convert.ToString(int.Parse(num), 2);
        var numInBinReversed = numInBin.Reverse().ToArray();

        StringBuilder numReversed = new StringBuilder();

        for (int i = 0; i < numInBinReversed.Length; i++)
        {
            numReversed.Append(numInBinReversed[i]);
        }
        numInBin += numReversed.ToString();
        Console.WriteLine(Convert.ToInt32(numInBin, 2));
    }
}