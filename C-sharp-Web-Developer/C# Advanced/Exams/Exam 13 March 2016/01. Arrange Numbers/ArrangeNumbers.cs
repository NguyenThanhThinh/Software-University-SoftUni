using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ArrangeNumbers
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        List<string> numbersInAlphabet = new List<string>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].Length == 1)
            {
                numbersInAlphabet.Add(ConvertNumberToTenInAlphabet(numbers[i]) + numbers[i]);
            }
            else
            {
                ConvertBiggerNumberInAlphabet(numbersInAlphabet, numbers[i]);
            }
        }
        numbersInAlphabet.Sort();
        PrintNumbers(numbersInAlphabet);
    }

    private static void PrintNumbers(List<string> numbersInAlphabet)
    {
        Queue<string> result = new Queue<string>();

        foreach (var num in numbersInAlphabet)
        {
            var t = num.First(a => char.IsDigit(a) == true);
            var c = num.IndexOf(t);
            result.Enqueue(num.Substring(c));
        }
        Console.WriteLine(string.Join(", ", result));
    }

    private static void ConvertBiggerNumberInAlphabet(List<string> numbersInAlphabet, string biggerNumber)
    {
        StringBuilder collector = new StringBuilder();
        for (int i = 0; i < biggerNumber.Length; i++)
        {
            collector.Append(ConvertNumberToTenInAlphabet(biggerNumber[i].ToString()));
        }
        collector.Append(biggerNumber);
        numbersInAlphabet.Add(collector.ToString());
    }

    private static string ConvertNumberToTenInAlphabet(string number)
    {
        switch (number)
        {
            case "0": return "zero";
            case "1": return "one";
            case "2": return "two";
            case "3": return "three";
            case "4": return "four";
            case "5": return "five";
            case "6": return "six";
            case "7": return "seven";
            case "8": return "eight";
            case "9": return "nine";

            default: return "failed";
        }
    }
}