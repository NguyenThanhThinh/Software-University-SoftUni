using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        long decimalNumber = 0L;

        for (int i = 0; i < binaryNumber.Length; i++)
        {
            decimalNumber += (long)(int.Parse(binaryNumber[binaryNumber.Length - 1 - i].ToString()) * Math.Pow(2, i));
        }

        Console.WriteLine(decimalNumber);
    }
}