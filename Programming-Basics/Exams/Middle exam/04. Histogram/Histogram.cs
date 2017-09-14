using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Histogram
{
    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());

        int[] allNumbers = new int[numbersCount];
        double p1 = 0;
        double p2 = 0;
        double p3 = 0;
        double p4 = 0;
        double p5 = 0;

        for (int i = 0; i < allNumbers.Length; i++)
        {
            allNumbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < allNumbers.Length; i++)
        {
            if (allNumbers[i] < 200)
            {
                p1++;
            }
            else if (allNumbers[i] <= 399)
            {
                p2++;
            }
            else if (allNumbers[i] <= 599)
            {
                p3++;
            }
            else if (allNumbers[i] <= 799)
            {
                p4++;
            }
            else
            {
                p5++;
            }
        }

        p1 = p1 / numbersCount * 100;
        p2 = p2 / numbersCount * 100;
        p3 = p3 / numbersCount * 100;
        p4 = p4 / numbersCount * 100;
        p5 = p5 / numbersCount * 100;

        Console.WriteLine("{0:F2}%", p1);
        Console.WriteLine("{0:F2}%", p2);
        Console.WriteLine("{0:F2}%", p3);
        Console.WriteLine("{0:F2}%", p4);
        Console.WriteLine("{0:F2}%", p5);
    }
}
