using System;
using System.Linq;

class DecimalToBinary
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string binaryNumber = "";

        while (decimalNumber != 1)
        {
            binaryNumber += (decimalNumber % 2).ToString();
            decimalNumber /= 2;
        }

        binaryNumber += "1";

        char[] reversedBinaryNumber = binaryNumber.Reverse().ToArray();
        foreach (char num in reversedBinaryNumber)
        {
            Console.Write(num);
        }
        Console.WriteLine();
    }
}