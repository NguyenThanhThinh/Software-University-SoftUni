using System;

class MagicWand
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3 * n + 2;
        int countDotsMinus = 3;
        int dotsInCenter = 0;

        //Console.WriteLine("First Part");
        Console.Write(new string('.', (width - 1) / 2));
        Console.Write("*");
        Console.WriteLine(new string('.', (width - 1) / 2));

        //Console.WriteLine("Second Part");
        for (int i = 0; i <= n - 3; i++)
        {
            Console.Write(new string('.', (width - countDotsMinus) / 2));
            Console.Write("*");
            Console.Write(new string('.', 1 + dotsInCenter));
            Console.Write("*");
            Console.WriteLine(new string('.', (width - countDotsMinus) / 2));

            if (((width - countDotsMinus) / 2) == n)
            {
                i = n;
            }

            countDotsMinus += 2;
            dotsInCenter += 2;
        }

        //Console.WriteLine("Third Part");
        Console.Write(new string('*', n));
        Console.Write(new string('.', width - (2*n)));
        Console.WriteLine(new string('*', n));

        //Console.WriteLine("Fourt Part");
        int dotsInBeginning = 1;

        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.Write(new string('.', dotsInBeginning));
            Console.Write("*");
            Console.Write(new string('.', width - ((dotsInBeginning * 2) + 2)));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsInBeginning));
            dotsInBeginning++;
        }

        //Console.WriteLine("Fifth Part");
        int dotBeginningLast = (((width - (n + 6)) / 2) - 1) / 2;
        int count = 0;

        for (int i = 1; i <= dotBeginningLast + 1; i++)
        {
            Console.Write(new string('.', dotBeginningLast - count));
            Console.Write("*");
            Console.Write(new string('.', dotBeginningLast + 1));
            Console.Write("*");
            Console.Write(new string('.', count));
            Console.Write("*");
            Console.Write(new string('.', n));
            Console.Write("*");
            Console.Write(new string('.', count));
            Console.Write("*");
            Console.Write(new string('.', dotBeginningLast + 1));
            Console.Write("*");
            Console.WriteLine(new string('.', dotBeginningLast - count));

            count++;
        }

        //Console.WriteLine("Sixth Part");
        Console.Write(new string('*', (((((width - (n + 2)) / 2)) - 1) / 2) + 1));
        Console.Write(new string('.', (((((width - (n + 2)) / 2)) - 1) / 2)));
        Console.Write("*");
        Console.Write(new string('.', n));
        Console.Write("*");
        Console.Write(new string('.', (((((width - (n + 2)) / 2)) - 1) / 2)));
        Console.WriteLine(new string('*', (((((width - (n + 2)) / 2)) - 1) / 2) + 1));

        //Console.WriteLine("Seventh Part");
        for (int i = 0; i < n; i++)
        {
            Console.Write(new string ('.', n));
            Console.Write("*");
            Console.Write(new string('.', n));
            Console.Write("*");
            Console.WriteLine(new string('.', n));
        }

        //Console.WriteLine("Eight Part");
        Console.Write(new string ('.', n));
        Console.Write(new string('*', n + 2));
        Console.WriteLine(new string('.', n));
    }
}