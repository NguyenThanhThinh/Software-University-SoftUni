using System;
using System.Numerics;

class CharacterMultiplier
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        string str1 = input[0];
        string str2 = input[1];
        BigInteger sum = 0;
        bool whichStrIsLonger = str1.Length > str2.Length ? true : false;

        if (str1.Length == str2.Length)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                sum += (int)str1[i] * (int)str2[i];
            }
        }
        else
        {
            for (int i = 0; i < (str1.Length < str2.Length ? str1.Length : str2.Length); i++)
            {
                sum += (int)str1[i] * (int)str2[i];
            }
            for (int p = (str1.Length < str2.Length ? str1.Length : str2.Length); p < (str1.Length > str2.Length ? str1.Length : str2.Length); p++)
            {
                if (whichStrIsLonger)
                {
                    sum += (int)str1[p];
                }
                else
                {
                    sum += (int)str2[p];
                }
            }
        }
        Console.WriteLine(sum);
    }
}