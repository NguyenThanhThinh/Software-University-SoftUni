using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

public class UppurcaseWords
{
    private static char[] invalidChars = new char[] { '\"', '\'', '&', '<', '>' };

    public static void Main()
    {
        var line = Console.ReadLine();
        var result = new StringBuilder();
        //var pattern = @"[\.,-\/#!$%\^&\*;:{}=\-_`~()@\+\?><\[\]\+0-9]?(?<![a-zA-Z])([A-Z]+)\d*(?![a-zA-Z])[\.,-\/#!$%\^&\*;:{}=\-_`~()@\+\?><\[\]\+0-9]?";
        var pattern = @"(?<![a-zA-Z])([A-Z]+)(?![a-zA-Z])";

        while (!line.Equals("END"))
        {
            Match match = Regex.Match(line, pattern);

            while (match.Success)
            {
                var word = match.Groups[1].Value;
                var replacePattern = @"(?<![a-zA-Z])(" + $"{word}" + @")(?![a-zA-Z])";
                var reversedWord = ReverseWord(word);
                if (word.Equals(reversedWord))
                {
                    var doubledWord = DoubleWordLetters(word);
                    var replacedWholeMatch = Matcher(match, doubledWord);
                    line = Regex.Replace(line, replacePattern, replacedWholeMatch);
                }
                else
                {
                    var replacedWholeMatch = Matcher(match, reversedWord);
                    line = Regex.Replace(line, replacePattern, replacedWholeMatch);
                }
                match = match.NextMatch();
            }
            result.AppendLine(line);
            line = Console.ReadLine();
        }

        var test = result.ToString();

        // this here needs to be modifed, because when I replace 1 invalid char, it is replaced by a group of others, and this group contains again 
        // some on the invalid chars and that way it double replace it.
        for (int i = 0; i < invalidChars.Length; i++)
        {
            string xmlText = SecurityElement.Escape(invalidChars[i].ToString());

            test = test.Replace(invalidChars[i].ToString(), xmlText);
        }
        Console.WriteLine(test);
    }

    private static string DoubleWordLetters(string word)
    {
        var doubledWord = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
        {
            doubledWord.Append(word[i]);
            doubledWord.Append(word[i]);
        }
        return doubledWord.ToString();
    }

    private static string ReverseWord(string word)
    {
        StringBuilder reversedWord = new StringBuilder();

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversedWord.Append(word[i]);
        }

        return reversedWord.ToString();
    }

    // this code is founded in stackoverflow and is used to replace just 1 single group
    static string Matcher(Match m, string replacedText)
    {
        var group = m.Groups[1];
        var startIndex = group.Index - m.Index;
        var length = group.Length;
        var original = m.Value;
        var prior = original.Substring(0, startIndex);
        var trailing = original.Substring(startIndex + length);
        return string.Concat(prior, replacedText, trailing);
    }
}

