using System;
using System.Linq;
using System.IO;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        var input = File.ReadAllLines(@"../../input.txt");
        string longestNumber = string.Empty;
        int longestNumberLength = 1;
        int longestNumberLengthBackUp = 1;

        for (int i = 0; i < input.Length; i++)
        {
            var currentLine = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int p = 0; p < currentLine.Length; p++)
            {
                int currentNumber = int.Parse(currentLine[p]);
                for (int y = p + 1; y < currentLine.Length; y++)
                {
                    int nextNumber = int.Parse(currentLine[y]);
                    if (currentNumber == nextNumber)
                    {
                        longestNumberLength++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (longestNumberLength > longestNumberLengthBackUp)
                {
                    longestNumber = currentNumber.ToString();
                    longestNumberLengthBackUp = longestNumberLength;
                }
                longestNumberLength = 1;
            }

            File.AppendAllText(@"../../output.txt", string.Concat(Enumerable.Repeat(longestNumber + " ", longestNumberLengthBackUp)));
            File.AppendAllText(@"../../output.txt", Environment.NewLine);
            longestNumberLengthBackUp = 1;
        }
    }
}