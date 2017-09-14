using System;

class ProgrTriangleOf55Starsam
{
    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            int count = i;
            for (int a = 0; a < count; a++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
