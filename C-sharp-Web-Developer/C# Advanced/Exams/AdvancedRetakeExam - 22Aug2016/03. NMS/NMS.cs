using System;
using System.Collections.Generic;
using System.Text;

public class NMS
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var words = new List<string>();
        int lastIndex = 0;
        StringBuilder allWords = new StringBuilder();

        while (input != "---NMS SEND---")
        {
            allWords.Append(input);
            
            input = Console.ReadLine();
        }

        for (int i = 1; i < allWords.Length; i++)
        {
            if (char.ToLower(allWords[i]) < char.ToLower(allWords[i - 1]))
            {
                words.Add(allWords.ToString().Substring(lastIndex, i - lastIndex));
                lastIndex = i;
            }
            if (i + 1 == allWords.Length) //if something goes wrong to check this
            {
                words.Add(allWords.ToString().Substring(lastIndex));
            }
        }

        string separator = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < words.Count; i++)
        {
            result.Append(words[i]);
            if (i + 1 != words.Count)
            {
                result.Append(separator);
            }
        }
        Console.WriteLine(result);
    }
}