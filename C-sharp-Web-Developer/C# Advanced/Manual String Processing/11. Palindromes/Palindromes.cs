using System;
using System.Collections.Generic;
using System.Linq;

public class Palindromes
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '\t', '\n', '!' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        SortedSet<string> palindromes = new SortedSet<string>();
        bool equal = true;

        for (int i = 0; i < input.Length; i++)
        {
            var currentWord = input[i];
            int rightSide = currentWord.Length - 1;
            for (int left = 0; left < currentWord.Length / 2; left++, rightSide--)
            {
                if (!currentWord[left].Equals(currentWord[rightSide]))
                {
                    equal = false;
                    break;
                }
            }
            if (equal)
            {
                palindromes.Add(currentWord);
            }
            equal = true;
        }
        Console.WriteLine($"[{string.Join(", ", palindromes)}]");
    }
}