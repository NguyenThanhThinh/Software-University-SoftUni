using System;
using System.Text;

public class SumBigNumbers
{
    public static void Main()
    {
        StringBuilder firstNumber = new StringBuilder();
        StringBuilder secondNumber = new StringBuilder();
        firstNumber.Append(Console.ReadLine());
        secondNumber.Append(Console.ReadLine());

        var longerValueLenght = firstNumber.Length < secondNumber.Length ? secondNumber.Length : firstNumber.Length;
        var shorterValueLenght = firstNumber.Length > secondNumber.Length ? secondNumber.Length : firstNumber.Length;
        string addZeroes = new string('0', longerValueLenght - shorterValueLenght);

        if (firstNumber.Length < secondNumber.Length)
        {
            firstNumber.Insert(0, addZeroes);
        }
        else
        {
            secondNumber.Insert(0, addZeroes);
        }

        StringBuilder result = new StringBuilder();
        int sum = 0;
        string sumToAdd = string.Empty;

        for (int i = firstNumber.Length - 1; i >= 0; i--)
        {
            string numberOne = firstNumber[i].ToString();
            string numberTwo = secondNumber[i].ToString();
            sum += int.Parse(numberOne) + int.Parse(numberTwo);

            if (sum <= 9)
            {
                result.Append(sum.ToString());
                sum = 0;
            }
            else
            {
                sumToAdd = sum.ToString()[1].ToString();
                result.Append(sumToAdd);
                sum = 1;
            }
        }

        if (sum == 1)
        {
            result.Append(sum);
        }

        string print = string.Empty;
        for (int i = result.Length - 1; i >= 0; i--)
        {
            print += result[i];
        }
        Console.WriteLine(print.TrimStart('0'));
    }
}