using System;
using System.Linq;
using System.Text;

public class FormattingNumbers
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        StringBuilder result = new StringBuilder();

        int a = int.Parse(input[0]);
        double b = double.Parse(input[1]);
        double c = double.Parse(input[2]);

        result.Append("|" + a.ToString("X").PadRight(10) + "|"
            + Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10) + "|" + b.ToString("0.00").PadLeft(10) + "|" + c.ToString("0.000").PadRight(10) + "|");
        Console.WriteLine(result);
    }
}