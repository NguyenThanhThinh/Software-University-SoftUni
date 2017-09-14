using System;
using System.Text;

class ReverseNumber
{
    static void Main()
    {
        string number = Console.ReadLine();

        ReverseGivenNumber(number);
    }

    private static void ReverseGivenNumber(string number)
    {
        StringBuilder reversedNumber = new StringBuilder();

        for (int i = number.Length - 1; i >= 0; i--)
        {
            reversedNumber.Append(number[i]);
        }

        Console.WriteLine(reversedNumber);
    }
}