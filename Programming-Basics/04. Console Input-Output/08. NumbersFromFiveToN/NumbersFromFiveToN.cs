using System;

class NumbersFromFiveToN
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int count = 1;

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine(count);
            count++;
        }
    }
}