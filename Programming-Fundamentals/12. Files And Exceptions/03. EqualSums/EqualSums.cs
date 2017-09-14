using System;
using System.Linq;
using System.IO;

class EqualSums
{
    static void Main()
    {
        var input = File.ReadAllLines(@"../../input.txt");
        int leftSum = 0;
        int rightSum = 0;
        bool isThereEqualSum = false;

        for (int i = 0; i < input.Length; i++)
        {
            var currentLine = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int p = 0; p < currentLine.Length; p++)
            {
                if (currentLine.Length == 1)
                {
                    File.AppendAllText(@"../../output.txt", "0" + Environment.NewLine);
                    isThereEqualSum = true;
                }
                else
                {
                    leftSum = LeftSum(currentLine, i, p);
                    rightSum = RightSum(currentLine, i, p);

                    if (leftSum == rightSum)
                    {
                        File.AppendAllText(@"../../output.txt", p.ToString() + Environment.NewLine);
                        isThereEqualSum = true;
                    }
                }
            }
            if (isThereEqualSum == false)
            {
                File.AppendAllText(@"../../output.txt", "no" + Environment.NewLine);
            }
            isThereEqualSum = false;
        }
    }

    private static int RightSum(string[] currentLine, int i, int p)
    {
        int sum = 0;
        if (p == currentLine.Length - 1)
        {
            return 0;
        }
        else
        {
            for (int x = p + 1; x < currentLine.Length; x++)
            {
                sum += int.Parse(currentLine[x]);
            }
            return sum;
        }
    }

    private static int LeftSum(string[] currentLine, int i, int p)
    {
        int sum = 0;
        if (p == 0)
        {
            return 0;
        }
        else
        {
            for (int x = 0; x < p; x++)
            {
                sum += int.Parse(currentLine[x]);
            }
            return sum;
        }
    }
}
