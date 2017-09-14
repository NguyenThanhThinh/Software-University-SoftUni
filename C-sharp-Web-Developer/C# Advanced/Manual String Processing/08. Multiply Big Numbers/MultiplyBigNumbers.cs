using System;

public class MultiplyBigNumbers
{
    public static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondnUmber = Console.ReadLine();
        int multipliedNumbers = 0;
        int num1 = 0;
        int num2 = int.Parse(secondnUmber);

        string result = string.Empty;
        int leftNum = 0;

        if (secondnUmber == "0")
        {
            Console.WriteLine(0);
        }
        else
        {
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                num1 = int.Parse(firstNumber[i].ToString());
                multipliedNumbers = num1 * num2;
                multipliedNumbers += leftNum;

                if (multipliedNumbers <= 9)
                {
                    result += multipliedNumbers;
                    leftNum = 0;
                }
                else
                {
                    result += multipliedNumbers.ToString()[1];
                    leftNum = int.Parse(multipliedNumbers.ToString()[0].ToString());
                }
            }

            if (leftNum > 0)
            {
                result += leftNum;
            }

            result = result.TrimEnd('0');

            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();
        }
    }
}