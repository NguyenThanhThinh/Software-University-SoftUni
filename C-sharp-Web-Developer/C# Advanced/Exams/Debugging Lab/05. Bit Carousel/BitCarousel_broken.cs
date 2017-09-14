namespace Debugging_BitCarousel
{
    using System;

    class BitCarousel_broken
    {
        static void Main()
        {
            byte number = byte.Parse(Console.ReadLine());
            byte rotations = byte.Parse(Console.ReadLine());
            byte result = 0;

            for (int i = 0; i < rotations; i++)
            {
                string direction = Console.ReadLine();

                if (direction == "right")
                {
                    int rightMostBit = number & 1;
                    number >>= 1;
                    result = number;
                    result |= (byte)(rightMostBit << 5);
                    number = result;
                }
                else if (direction == "left")
                {
                    int leftMostBit = (number >> 5) & 1;
                    number <<= 1;
                    number |= (byte)leftMostBit;
                    int mask = ~(3 << 6); //moving number 3 (0000 0011) 6 cels on left, so I can make the last 2 cells always 0, as we use 6 cells array
                    result = (byte)(number & mask);
                    number = result;
                }
            }
            Console.WriteLine(result);
        }
    }
}