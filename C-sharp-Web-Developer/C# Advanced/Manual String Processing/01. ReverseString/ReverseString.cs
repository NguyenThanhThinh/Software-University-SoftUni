using System;
using System.Text;

public class ReverseString
{
    public static void Main()
    {
        var input = Console.ReadLine();

        StringBuilder reverseInput = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reverseInput.Append(input[i]);
        }
        Console.WriteLine(reverseInput.ToString());
    }
}