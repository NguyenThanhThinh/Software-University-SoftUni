using System;

public class CharacterMultiplier
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(); ;
        long totalSum = 0;

        string shorterString = string.Empty;
        string longerString = string.Empty;
        if (input[0].Length != input[1].Length)
        {
            shorterString = input[0].Length < input[1].Length ? input[0] : input[1];
            longerString = input[0].Length > input[1].Length ? input[0] : input[1];
        }
        else
        {
            shorterString = input[0];
            longerString = input[1];
        }

        for (int i = 0; i < shorterString.Length; i++)
        {
            totalSum += (int)shorterString[i] * (int)longerString[i];
        }

        for (int p = shorterString.Length; p < longerString.Length; p++)
        {
            totalSum += (int)longerString[p];
        }
        Console.WriteLine(totalSum);
    }
}