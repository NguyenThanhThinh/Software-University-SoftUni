using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ArrayManipulator
{
    public static StringBuilder output = new StringBuilder();

    static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToList();
        var line = Console.ReadLine();

        while (line != "end")
        {
            var separateLine = line.Split();
            var command = separateLine[0];

            switch (command)
            {
                case "exchange":
                    int index = int.Parse(separateLine[1]);
                    if (index < 0 || index >= array.Count)
                    {
                        output.AppendLine("invalid index");
                        //Console.WriteLine("invalid index");
                    }
                    else
                    {
                        array = ExchangeArray(array, index);
                    }
                    break;
                case "max":
                    string elementMax = GetMaxOrMinOddOrEvenIndexOfElement(array, separateLine);
                    if (elementMax == string.Empty)
                    {
                        output.AppendLine("No matches");
                    }
                    else
                    {
                        output.AppendLine(elementMax);
                        //Console.WriteLine(elementMax);
                    }
                    break;
                case "min":
                    string elementMin = GetMaxOrMinOddOrEvenIndexOfElement(array, separateLine);
                    if (elementMin == string.Empty)
                    {
                        output.AppendLine("No matches");
                    }
                    else
                    {
                        output.AppendLine(elementMin);
                        //Console.WriteLine(elementMin);
                    }
                    break;
                case "first":
                    var firstElements = GetFirstOrLastOddOrEvenElements(array, separateLine);
                    if (!(firstElements.Count == 0))
                    {
                        output.AppendLine("[" + string.Join(", ", firstElements) + "]");
                    }
                    break;
                case "last":
                    var lastElements = GetFirstOrLastOddOrEvenElements(array, separateLine);
                    if (!(lastElements.Count == 0))
                    {
                        output.AppendLine("[" + string.Join(", ", lastElements) + "]");
                    }
                    break;
                default:
                    break;
            }
            line = Console.ReadLine();
        }
        output.AppendLine("[" + string.Join(", ", array) + "]");
        Console.WriteLine(output);
    }

    private static List<string> GetFirstOrLastOddOrEvenElements(List<int> array, string[] separateLine)
    {
        string firstOrLast = separateLine[0];
        int count = int.Parse(separateLine[1]);
        string oddOrEven = separateLine[2];
        List<string> result = new List<string>();

        if (count > array.Count)
        {
            output.AppendLine("Invalid count");
            return result;
        }

        if (oddOrEven == "odd")
        {
            var oddNumbers = array.Where(o => o % 2 != 0);
            int oddNumbersCount = oddNumbers.Count();
            if (firstOrLast == "first")
            {
                if (oddNumbersCount == 0)
                {
                    output.AppendLine("[]");
                }
                else
                {
                    var firstOddNumbers = oddNumbers.Take(count).Select(a => a.ToString()).ToList();
                    return firstOddNumbers;
                }
            }
            else if (firstOrLast == "last")
            {
                if (oddNumbersCount == 0)
                {
                    output.AppendLine("[]");
                }
                else
                {
                    if (count > oddNumbersCount)
                    {
                        return oddNumbers.Select(a => a.ToString()).ToList();
                    }
                    else
                    {
                        var lenght = oddNumbersCount - count;
                        return oddNumbers.Skip(lenght).Take(count).Select(a => a.ToString()).ToList();
                    }
                }
            }
        }
        else if (oddOrEven == "even")
        {
            var evenNumbers = array.Where(o => o % 2 == 0);
            int evenNumbersCount = evenNumbers.Count();
            if (firstOrLast == "first")
            {
                if (evenNumbersCount == 0)
                {
                    output.AppendLine("[]");
                }
                else
                {
                    var firstEvenNumbers = evenNumbers.Take(count).Select(a => a.ToString()).ToList();
                    return firstEvenNumbers;
                }
            }
            else if (firstOrLast == "last")
            {
                if (evenNumbersCount == 0)
                {
                    output.AppendLine("[]");
                }
                else
                {
                    if (count > evenNumbersCount)
                    {
                        return evenNumbers.Select(a => a.ToString()).ToList();
                    }
                    else
                    {
                        var lenght = evenNumbersCount - count;
                        return evenNumbers.Skip(lenght).Take(count).Select(a => a.ToString()).ToList();
                    }
                }
            }
        }
        return result;
    }

    private static string GetMaxOrMinOddOrEvenIndexOfElement(List<int> array, string[] separateLine)
    {
        string oddOrEven = separateLine[1];
        string maxOrMin = separateLine[0];

        if (oddOrEven == "odd")
        {
            var oddNumbers = array.Where(o => o % 2 != 0);
            int numberOfElements = oddNumbers.Count();

            if (numberOfElements == 0)
            {
                return string.Empty;
            }
            else
            {
                if (maxOrMin == "max")
                {
                    var maxOddNumber = oddNumbers.Max();
                    return array.LastIndexOf(maxOddNumber).ToString();
                }
                else if (maxOrMin == "min")
                {
                    var maxOddNumber = oddNumbers.Min();
                    return array.LastIndexOf(maxOddNumber).ToString();
                }
            }
        }
        else if (oddOrEven == "even")
        {
            var evenNumbers = array.Where(e => e % 2 == 0);
            int numberOfElements = evenNumbers.Count();

            if (numberOfElements == 0)
            {
                return string.Empty;
            }
            else
            {
                if (maxOrMin == "max")
                {
                    var maxEvenNumber = evenNumbers.Max();
                    return array.LastIndexOf(maxEvenNumber).ToString();
                }
                else if (maxOrMin == "min")
                {
                    var maxEvenNumber = evenNumbers.Min();
                    return array.LastIndexOf(maxEvenNumber).ToString();
                }
            }
        }
        return "-1";
    }

    private static List<int> ExchangeArray(List<int> array, int index)
    {
        var firstPart = array.Take(index + 1).ToList();
        array.RemoveRange(0, index + 1);
        array.AddRange(firstPart);
        return array;
    }
}