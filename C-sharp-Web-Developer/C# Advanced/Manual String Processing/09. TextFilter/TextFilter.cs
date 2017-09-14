using System;
using System.Linq;

public class TextFilter
{
    public static void Main()
    {
        var bannedList = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        string text = Console.ReadLine();

        for (int i = 0; i < bannedList.Count(); i++)
        {
            text = text.Replace(bannedList[i], new string('*', bannedList[i].Length));
        }
        Console.WriteLine(text);
    }
}