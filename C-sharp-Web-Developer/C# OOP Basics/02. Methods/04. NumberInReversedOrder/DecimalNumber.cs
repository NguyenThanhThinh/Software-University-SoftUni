using System;

public class DecimalNumber
{
    public static void ReverseNumber(string number)
    {
        string reversedNumber = string.Empty;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            reversedNumber += number[i];
        }
        Console.WriteLine(reversedNumber);
    }
}