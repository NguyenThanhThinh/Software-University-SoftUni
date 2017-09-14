using System;

class BiggerNumber
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        BiggerInteger(firstNumber, secondNumber);
    }

    private static void BiggerInteger(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            Console.WriteLine(firstNumber);
        }
        else
        {
            Console.WriteLine(secondNumber);
        }
    }
}