using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrainingLab
{
    static void Main()
    {
        //decimal heigh = decimal.Parse(Console.ReadLine());
        //decimal weigh = decimal.Parse(Console.ReadLine());
        //weigh *= 100;
        //heigh *= 100;

        //weigh -= 100;

        //int tables = (int)weigh / 70;
        //int seats = (int)heigh / 120;

        //int result = (tables * seats) - 3;
        //Console.WriteLine(result);

        int x = 6;
        Console.WriteLine(x |= 1);
        x = x | 6;
        Console.WriteLine(x);
    }
}
