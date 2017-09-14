using System;

class Exchange_Variables
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("Before: \na = {0} \nb = {1}", a, b);

        int c = 0;

        c = b;
        b = a;
        a = c;

        Console.WriteLine("After: \na = {0} \nb = {1}", a, b);
    }
}

