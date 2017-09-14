using System;

public class CountSubtringOccurrences
{
    public static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string substring = Console.ReadLine().ToLower();

        int counter = 0;
        int indexOfOccurrence = text.IndexOf(substring);

        while (indexOfOccurrence != -1)
        {
            counter++;
            indexOfOccurrence = text.IndexOf(substring, indexOfOccurrence + 1);
        }
        Console.WriteLine(counter);
    }
}