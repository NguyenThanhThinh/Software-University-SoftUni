using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Numbers
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var avarageNumber = input.Average();

        var finalResult = input.OrderByDescending(n => n).TakeWhile(n => n > avarageNumber).Take(5);

        if (finalResult.Count() == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(string.Join(" ", finalResult));
        }
    }
}

