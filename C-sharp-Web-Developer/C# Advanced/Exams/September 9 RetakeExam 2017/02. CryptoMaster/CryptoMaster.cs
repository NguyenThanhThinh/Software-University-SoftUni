using System;
using System.Collections.Generic;
using System.Linq;

public class CryptoMaster
{
    public static void Main()
    {
        var array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
        var checkedIndexes = new List<int>();

        int currentLengh = 0;
        int bestLengh = 0;
        int currentNumber = 0;
        int previousNumber = int.MinValue;
        int jumper = 0;

        for (int startIndex = 0; startIndex < array.Length; startIndex++)
        {

            for (int jumpIndex = 1; jumpIndex < array.Length; jumpIndex++)
            {
                jumper = jumpIndex;
                int currentIndex = startIndex;

                do
                {
                    currentNumber = array[currentIndex];

                    if (currentNumber > previousNumber)
                    {
                        previousNumber = currentNumber;
                        currentLengh++;
                        checkedIndexes.Add(currentIndex);
                    }
                    else
                    {
                        break;
                    }

                    currentIndex = NextIndex(currentIndex, jumper, array);
                } while (!checkedIndexes.Contains(currentIndex));

                if (currentLengh > bestLengh)
                {
                    bestLengh = currentLengh;
                }

                checkedIndexes.Clear();
                currentLengh = 0;
                previousNumber = int.MinValue;
            }
        }

        Console.WriteLine(bestLengh);
    }

    private static int NextIndex(int currentIndex, int jumper, int[] array)
    {
        if (currentIndex + jumper < array.Length)
        {
            return currentIndex + jumper;
        }
        else
        {
            int nextIndex = (currentIndex + jumper) % array.Length;
            return nextIndex;
        }
    }
}