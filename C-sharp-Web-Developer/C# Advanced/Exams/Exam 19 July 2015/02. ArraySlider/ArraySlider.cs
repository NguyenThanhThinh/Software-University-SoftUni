using System;
using System.Linq;
using System.Numerics;

public class ArraySlider
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
        var command = Console.ReadLine();
        int position = 0;

        while (!command.Equals("stop"))
        {
            var splitCommand = command.Split();
            int offset = int.Parse(splitCommand[0]);
            string operation = splitCommand[1];
            long operand = long.Parse(splitCommand[2]);
            position = FindCurrentPositionInNumbersArray(offset, numbers, ref position);

            switch (operation)
            {
                case "&":
                    numbers[position] &= operand;
                    break;
                case "|":
                    numbers[position] |= operand;
                    break;
                case "^":
                    numbers[position] ^= operand;
                    break;
                case "+":
                    numbers[position] += operand;
                    break;
                case "-":
                    numbers[position] -= operand;
                    break;
                case "*":
                    numbers[position] *= operand;
                    break;
                case "/":
                    numbers[position] /= operand;
                    break;
            }
            numbers[position] = numbers[position] < 0 ? 0 : numbers[position];
            command = Console.ReadLine();
        }
        Console.WriteLine($"[{string.Join(", ", numbers)}]");
    }

    private static int FindCurrentPositionInNumbersArray(int offset, BigInteger[] numbers, ref int position)
    {
        int currentIndex = position;

        if (offset > 0)
        {
            if (currentIndex + offset >= numbers.Length)
            {
                currentIndex = (offset % numbers.Length) == 0 ? currentIndex : (currentIndex + offset) % numbers.Length;
            }
            else
            {
                currentIndex += offset;
            }
            return currentIndex;
        }
        else if (offset < 0)
        {
            if (currentIndex + offset < 0)
            {
                var residue = Math.Abs(offset % numbers.Length);
                if (residue > currentIndex)
                {
                    currentIndex = (residue - currentIndex);
                    currentIndex = numbers.Length - currentIndex;
                }
                else
                {
                    currentIndex -= residue;
                }
            }
            else
            {
                currentIndex -= offset;
            }
            return currentIndex;
        }
        else
        {
            return 0;
        }
    }
}