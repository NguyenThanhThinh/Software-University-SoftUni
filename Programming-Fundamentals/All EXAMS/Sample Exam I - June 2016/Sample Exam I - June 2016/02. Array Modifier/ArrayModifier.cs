using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class ArrayModifier
{
    static void Main()
    {
        var intArray = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
        string command = Console.ReadLine();

        while (command != "end")
        {
            var splitCommand = command.Split(' ');

            int firstIndex = 0;
            int secondIndex = 0;

            if (splitCommand.Length > 1)
            {
                firstIndex = int.Parse(splitCommand[1]);
                secondIndex = int.Parse(splitCommand[2]);
            }

            switch (splitCommand[0])
            {
                case "swap":
                    intArray = SwapOperation(intArray, firstIndex, secondIndex);
                    break;
                case "multiply":
                    intArray = MultiplyOperation(intArray, firstIndex, secondIndex);
                    break;
                case "decrease":
                    intArray = DecreaseOperation(intArray, firstIndex, secondIndex);
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine(string.Join(", ", intArray));
    }

    private static List<BigInteger> DecreaseOperation(List<BigInteger> intArray, int firstIndex, int secondIndex)
    {
        //intArray.ForEach(a => a = a - 1);
        for (int i = 0; i < intArray.Count; i++)
        {
            intArray[i] -= 1;
        }
        return intArray;
    }

    private static List<BigInteger> MultiplyOperation(List<BigInteger> intArray, int firstIndex, int secondIndex)
    {
        BigInteger multipliedResult = intArray[firstIndex] * intArray[secondIndex];
        intArray[firstIndex] = multipliedResult;

        return intArray;
    }

    private static List<BigInteger> SwapOperation(List<BigInteger> intArray, int firstIndex, int secondIndex)
    {
        BigInteger holder = intArray[firstIndex];

        intArray[firstIndex] = intArray[secondIndex];
        intArray[secondIndex] = holder;

        return intArray;
    }
}