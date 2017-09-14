using System;
using System.Linq;
using System.Text;

public class UnicodeCharacters
{
    public static void Main()
    {
        var text = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        var textAsHex = text.Select(x => ((int)x).ToString("X02")).ToArray();

        for (int i = 0; i < textAsHex.Length; i++)
        {
            result.Append($"\\u00{textAsHex[i].ToLower()}");
        }
        Console.WriteLine(result);
    }
}