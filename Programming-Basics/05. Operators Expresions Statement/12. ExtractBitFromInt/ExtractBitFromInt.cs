using System;

class ExtractBitFromInt
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int numberRightP = number >> p;
        int bit = numberRightP & 1;
        Console.WriteLine(bit);

    }
}