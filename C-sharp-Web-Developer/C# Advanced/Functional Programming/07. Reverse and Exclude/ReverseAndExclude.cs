using System;
using System.Collections.Generic;
using System.Linq;

public static class ReverseAndExclude
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
        int divider = int.Parse(Console.ReadLine());
        Predicate<double> numDivider = n => n % divider != 0;
        Action<List<double>> reverseNumbers = ReverseNumbers;
        reverseNumbers(numbers);
        Func<List<double>, Predicate<double>, List<double>> divisibleNumbersFunc = FindDivisibleNumbersFunc;
        var foundedNumbers = divisibleNumbersFunc(numbers, numDivider);

        Console.WriteLine(string.Join(" ", foundedNumbers));
    }

    public static List<double> FindDivisibleNumbersFunc(List<double> numbers, Predicate<double> divisibleNumbersFunc)
    {
        var foundedNumbers = new List<double>();
        foundedNumbers = numbers.FindAll(divisibleNumbersFunc);
        return foundedNumbers;
    }
    
    public static void ReverseNumbers(List<double> numbers)
    {
        numbers.Reverse();
    }
}