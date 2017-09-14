using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class WordCount
{
    public static void Main()
    {
        var wordCount = new Dictionary<string, int>();

        using (var readText = new StreamReader(@"../../text.txt"))
        {
            using (var readWords = new StreamReader(@"../../words.txt"))
            {
                string text = readText.ReadToEnd();

                string word = readWords.ReadLine();

                while (word != null)
                {
                    MatchCollection regex = Regex.Matches(text, $@"\b{word}\b", RegexOptions.IgnoreCase);
                    wordCount[word] = regex.Count;
                    word = readWords.ReadLine();
                }
            }
        }

        using (var write = new StreamWriter(@"../../results.txt"))
        {
            foreach (var word in wordCount.OrderByDescending(w => w.Value))
            {
                write.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}