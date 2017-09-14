using System;
using System.Text;

class UnicodeCharacter
{
    static void Main()
    {
        string input = Console.ReadLine();
        var inputToChars = input.ToCharArray();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < inputToChars.Length; i++)
        {
            result.Append("\\u" + ((int)inputToChars[i]).ToString("X4").ToLower());
        }
        Console.WriteLine(result);
    }
}