using System;

class ThirdDigitIsSeven
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int holder = 0;

        holder = number / 100;
        if (holder % 10 == 7)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}