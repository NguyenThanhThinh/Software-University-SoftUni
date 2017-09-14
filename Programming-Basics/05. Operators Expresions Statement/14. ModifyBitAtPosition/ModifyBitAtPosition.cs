using System;

class ModifyBitAtPosition
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        int mask = 0;
        int compareTheBits = 0;

        if (v == 1)
        {
            mask = v << position;
            compareTheBits = mask | number;
            Console.WriteLine(compareTheBits);
        }
        else
        {
            mask = 1 << position;
            compareTheBits = mask ^ number;
            Console.WriteLine(compareTheBits);
        }
    }
}