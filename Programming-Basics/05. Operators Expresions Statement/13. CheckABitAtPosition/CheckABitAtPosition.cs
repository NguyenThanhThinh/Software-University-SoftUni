using System;

class CheckABitAtPosition
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int numberRightP = number >> p;
        bool isValueOne = true;
        int bit = numberRightP & 1;

        if (bit == 1)
        {
            Console.WriteLine(isValueOne);
        }
        else
        {
            isValueOne = false;
            Console.WriteLine(isValueOne);
        }
    }
}