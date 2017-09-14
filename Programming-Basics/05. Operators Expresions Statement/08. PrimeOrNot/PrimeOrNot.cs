using System;

class PrimeOrNot
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool primeOrNot = true;

        if (number <= 0)
        {
            Console.WriteLine("false");
        }
        else
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    primeOrNot = false;
                    break;
                }
            }
            Console.WriteLine(primeOrNot);
        }
    }
}