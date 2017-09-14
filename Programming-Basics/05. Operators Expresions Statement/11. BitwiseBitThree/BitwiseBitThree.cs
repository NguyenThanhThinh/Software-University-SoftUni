using System;

class BitwiseBitThree
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = 3;
        int numberRightP = number >> p;
        int bit = numberRightP & 1;
        Console.WriteLine(bit);

    }
}