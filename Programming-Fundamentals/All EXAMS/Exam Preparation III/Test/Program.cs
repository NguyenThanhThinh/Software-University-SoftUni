using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = Console.ReadLine().Split().ToList();

            var test2 = Console.ReadLine().Split().ToList();

            test2 = test;
            test.RemoveAt(0);
            Console.WriteLine();
        }
    }
}
