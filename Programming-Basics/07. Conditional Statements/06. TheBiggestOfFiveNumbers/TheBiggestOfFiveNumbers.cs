using System;

class TheBiggestOfFiveNumbers
{
    static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        double fourtNumber = double.Parse(Console.ReadLine());
        double fifthNumber = double.Parse(Console.ReadLine());

        if ((firstNumber > secondNumber) && (firstNumber > thirdNumber) && (firstNumber > fourtNumber) && (firstNumber > fifthNumber))
        {
            Console.WriteLine(firstNumber);
        }
        else if ((secondNumber > firstNumber) && (secondNumber > thirdNumber) && (secondNumber > fourtNumber) && (secondNumber > fifthNumber))
        {
            Console.WriteLine(secondNumber);
        }
        else if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber) && (thirdNumber > fourtNumber) && (thirdNumber > fifthNumber))
        {
            Console.WriteLine(thirdNumber);
        }
        else if ((fourtNumber > firstNumber) && (fourtNumber > secondNumber) && (fourtNumber > thirdNumber) && (fourtNumber > fifthNumber))
        {
            Console.WriteLine(fourtNumber);
        }
        else
        {
            Console.WriteLine(fifthNumber);
        }
    }
}