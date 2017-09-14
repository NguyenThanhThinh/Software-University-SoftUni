using System;

class Isosceles_Triangle
{
    static void Main()
    {
        char copyright = '©';

        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("   {0}", copyright);
            }
            if (i == 1)
            {
                Console.WriteLine("  {0} {1}", copyright,copyright);
            }
            if (i == 2)
            {
                Console.WriteLine(" {0}   {1}", copyright,copyright);
            }
            if (i == 3)
            {
                Console.WriteLine("{0} {1} {2} {3}",copyright,copyright,copyright,copyright);
            }
        }
    }
}

