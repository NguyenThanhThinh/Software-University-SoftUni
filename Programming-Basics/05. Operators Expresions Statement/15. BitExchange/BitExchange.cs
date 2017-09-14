using System;

class BitExchange
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long temporaryValue = 0;
        int[] bitsLow = new int[3];
        int[] bitsHigh = new int[3];

        for (int i = 0, x = 3; i < 3; i++, x++)
        {
            temporaryValue = number >> x;
            bitsLow[i] = (int)temporaryValue & 1;
        }

        for (int i = 0, y = 24; i < 3; i++, y++)
        {
            temporaryValue = number >> y;
            bitsHigh[i] = (int)temporaryValue & 1;
        }

        long maskLow = 0;
        long maskHight = 0;
        //Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        for (int i = 0, x = 3, y = 24; i < 3; i++, x++, y++)
        {
            maskLow = bitsLow[i];
            if (bitsLow[i] == 1)
            {
                maskLow = maskLow << y;
                number = number | maskLow;
                //Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            } 
            else
            {
                maskLow = 1;
                maskLow = ~(maskLow << y);
                number = number & maskLow;
                //Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            }

            maskHight = bitsHigh[i];

            if (bitsHigh[i] == 1)
            {
                maskHight = maskHight << x;
                number = number | maskHight;
                //Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            }
            else
            {
                maskHight = 1;
                maskHight = ~(maskHight << x);
                number = number & maskHight;
                //Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            }
        }
        Console.WriteLine(number);
    }
}