using System;
using System.Numerics;

public class ConvertFromBaseNto10
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int baseNum = int.Parse(input[0]);
        string number = input[1];
        BigInteger currentValue = 0;
        BigInteger convertedNumber = 0;

        if (baseNum >= 2 && baseNum <= 10)
        {
            for (int i = 0; i < number.Length; i++)
            {
                var singleNumber = BigInteger.Parse(number[i].ToString());
                var multiplier = BigInteger.Pow(baseNum, number.Length - 1 - i);
                currentValue = singleNumber * multiplier;
                convertedNumber += currentValue;
            }
            Console.WriteLine(convertedNumber);
        }
    }
}