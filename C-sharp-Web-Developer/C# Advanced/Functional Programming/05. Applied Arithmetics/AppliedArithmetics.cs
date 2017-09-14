using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class AppliedArithmetics
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
        string command = Console.ReadLine();
        var result = new StringBuilder();
        Func<List<double>, List<double>> addFunc = AddOneToEachNumber;
        Func<List<double>, string> printAct = PrintNumbers;
        Func<List<double>, List<double>> multiplyFunc = MultiplyNumbers;
        Func<List<double>, List<double>> subtractFunc = SubtractNumbers;

        while (command != "end")
        {
            switch (command)
            {
                case "add": numbers = addFunc(numbers); break;
                case "multiply": numbers = multiplyFunc(numbers); break;
                case "subtract": numbers = subtractFunc(numbers); break;
                case "print": result.AppendLine(printAct(numbers)); break;
                default:
                    break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine(result);
    }

    public static List<double> AddOneToEachNumber(List<double> numbers)
    {
        List<double> newNumbers = new List<double>();

        for (int i = 0; i < numbers.Count; i++)
        {
            newNumbers.Add(numbers[i] + 1);
        }
        return newNumbers;
    }

    public static string PrintNumbers(List<double> numbers)
    {
        return string.Join(" ", numbers);
    }

    public static List<double> MultiplyNumbers(List<double> numbers)
    {
        var newNumbers = new List<double>();
        foreach (var num in numbers)
        {
            newNumbers.Add(num * 2);
        }
        return newNumbers;
    }

    public static List<double> SubtractNumbers(List<double> numbers)
    {
        var newNumbers = new List<double>();
        foreach (var num in numbers)
        {
            newNumbers.Add(num - 1);
        }
        return newNumbers;
    }
}