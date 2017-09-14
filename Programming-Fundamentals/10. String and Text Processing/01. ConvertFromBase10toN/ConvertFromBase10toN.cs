using System;
using System.Text;
using System.Numerics;

public class ConvertFromBase10toN
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        long baseNum = long.Parse(input[0]);
        BigInteger number = BigInteger.Parse(input[1]);
        BigInteger residue = 0;

        StringBuilder convertedNumber = new StringBuilder();

        if (baseNum >= 2 && baseNum <= 10)
        {
            while (number != 0)
            {
                residue = number % baseNum;
                convertedNumber.Append(residue);
                number = number / baseNum;
            }
        }

        for (int i = convertedNumber.Length - 1; i >= 0; i--)
        {
            Console.Write("{0}", convertedNumber[i]);
        }
        Console.WriteLine();
    }
}