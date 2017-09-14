using System;

class TrailingZeroesInNFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int holder = 0;
        
        for (int i = 5; n / i >= 1; i *= 5) //I took this formula from internet
        {
            holder += n / i;
        }

        Console.WriteLine(holder);
    }
}