using System;

class DevideBySevenAndFive
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (number % 7 == 0 && number % 5 == 0 && number != 0)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
        
    }
}