using System;
using System.Collections.Generic;

class BitExchangeAdvanced
{
    static void Main(string[] args)
    {
        string number = Console.ReadLine();
        uint p = uint.Parse(Console.ReadLine());
        uint q = uint.Parse(Console.ReadLine());
        uint kLength = uint.Parse(Console.ReadLine());

        uint n = 0;
        bool outOfRange = true;
        uint closestBit = (p > q) ? q : p;
        uint longestBit = (p > q) ? p : q;
        outOfRange = uint.TryParse(number, out n);

        if (outOfRange && (p >= 0) && (q >= 0) && (p + kLength <= 32) && (q + kLength <= 32) && (kLength <= 32))
        {
            n = uint.Parse(number);
        }
        else
        {
            Console.WriteLine("out of range");
            return;

        }

        bool overlapping = false;
        overlapping = (closestBit + kLength) > longestBit;
        if (overlapping)
        {
            Console.WriteLine("overlapping");
            return;
        }

        List<string> numberInBits = new List<string>();
        string converedNumber = Convert.ToString(n, 2).PadLeft(32, '0');
        List<string> firstValueOfBits = new List<string>();
        List<string> secondValueOfBits = new List<string>();

        for (int i = 0; i < converedNumber.Length; i++)
        {
            numberInBits.Add(converedNumber[i].ToString());
        }
        numberInBits.Reverse();

        uint nRightBit = 0;
        uint bitValue = 0;
        int OneMorePositionBack = 0;

        for (uint i = closestBit; i < closestBit + kLength; i++)
        {
            nRightBit = n >> (int)closestBit + OneMorePositionBack;
            bitValue = nRightBit & 1;
            firstValueOfBits.Add(bitValue.ToString());
            OneMorePositionBack++;
        }

        OneMorePositionBack = 0;
        for (uint i = longestBit; i < longestBit + kLength; i++)
        {
            nRightBit = n >> (int)longestBit + OneMorePositionBack;
            bitValue = nRightBit & 1;
            secondValueOfBits.Add(bitValue.ToString());
            OneMorePositionBack++;
        }

        int countingPosition = 0;
        for (uint i = closestBit; i < closestBit + kLength; i++)
        {
            numberInBits.RemoveAt((int)i);
            numberInBits.Insert((int)i, secondValueOfBits[countingPosition]);
            countingPosition++;
        }
        countingPosition = 0;


        for (uint i = longestBit; i < longestBit + kLength; i++)
        {
            numberInBits.RemoveAt((int)i);
            numberInBits.Insert((int)i, firstValueOfBits[countingPosition]);
            countingPosition++;
        }

        Console.WriteLine(converedNumber);
        string convertedResult = "";

        for (int i = numberInBits.Count - 1; i >= 0; i--)
        {
            Console.Write(numberInBits[i]);
            convertedResult += numberInBits[i];
        }

        Console.WriteLine();
        uint finalResult = Convert.ToUInt32(convertedResult, 2);
        Console.WriteLine(finalResult);
    }
}