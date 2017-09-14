using System;

class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double holder = 0d;

        if (firstNumber > secondNumber)
        {
            holder = firstNumber;
            firstNumber = secondNumber;
            secondNumber = holder;

            Console.WriteLine("{0} {1}", firstNumber, secondNumber); 
        }

        else
        {
            Console.WriteLine("{0} {1}", firstNumber, secondNumber);
        }
    }
}