using System;
using System.Linq;

public static class CustomMinFunction
{
    public static void Main()
    {
        var setNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Func<double[], double> myFunc = ReturnsMinNumber;
        Console.WriteLine(myFunc(setNumbers));
    }
    public static double ReturnsMinNumber (double[] setNumbers)
    {
        double smallestNum = setNumbers.Min();
        return smallestNum;
    }
}