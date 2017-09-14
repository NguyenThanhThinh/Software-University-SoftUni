using System;

class BiggerNumber
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            Console.WriteLine(firstNumber);
        }
        else if (secondNumber > firstNumber)
        {
            Console.WriteLine(secondNumber);
        }
        else
        {
            Console.WriteLine(firstNumber);
        }
    }
}