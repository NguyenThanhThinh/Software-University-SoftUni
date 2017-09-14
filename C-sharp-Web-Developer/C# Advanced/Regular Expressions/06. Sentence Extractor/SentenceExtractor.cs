using System;
using System.Text.RegularExpressions;

public class SentenceExtractor
{
    public static void Main(string[] args)
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();
        string pattern = @"((?=\S)[^\n.!?]+\b" + word + @"\b[\s\w]+[.!?])";

        Regex regex = new Regex(pattern);
        MatchCollection specificSentences = regex.Matches(text);

        foreach (Match sentences in specificSentences)
        {
            Console.WriteLine(sentences);
        }
    }
}