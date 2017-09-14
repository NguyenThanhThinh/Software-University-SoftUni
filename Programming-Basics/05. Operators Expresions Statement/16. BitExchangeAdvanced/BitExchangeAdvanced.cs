using System;

class BitExchangeAdvanced
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        bool runOrNot = true;
        long[] firstBits = new long[k];
        long[] secondBits = new long[k];

        long mask = 1;
        long holder = 0;

        if (p < 0 || q < 0 || p > 32 || q > 32 || p + k > 32 || q + k > 32)
        {
            Console.WriteLine("out of range");
            runOrNot = false;
        }
        else if (p > q)
        {
            if (q + k > p)
            {
                Console.WriteLine("overlapping");
                runOrNot = false;
            }
        }
        else if (q > p)
        {
            if (p + k > q)
            {
                Console.WriteLine("overlapping");
                runOrNot = false;
            }
        }

        if (runOrNot)
        {
            for (int i = 0, x = p, y = q; i < k; i++, x++, y++)
            {
                holder = number >> x;
                holder = mask & holder;
                firstBits[i] = holder;

                holder = number >> y;
                holder = mask & holder;
                secondBits[i] = holder;
            }

            for (int i = 0, x = p, y = q; i < k; i++, x++, y++)
            {
                if (p > q)
                {
                    mask = firstBits[i] << y;
                    if (firstBits[i] == 1)
                    {
                        number = number | mask;
                    }
                    else
                    {
                        mask = ~(1 << y);
                        number = number & mask;
                    }

                    mask = secondBits[i] << x;
                    if (secondBits[i] == 1)
                    {
                        number = number | mask;
                    }
                    else
                    {
                        mask = ~(1 << x);
                        number = number & mask;
                    }
                }
                else if (p < q)
                {
                    mask = firstBits[i] << y;
                    if (firstBits[i] == 1)
                    {
                        number = number | mask;
                    }
                    else
                    {
                        mask = ~(1 << y);
                        number = number & mask;
                    }

                    mask = secondBits[i] << x;
                    if (secondBits[i] == 1)
                    {
                        number = number | mask;
                    }
                    else
                    {
                        mask = ~(1 << x);
                        number = number & mask;
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}