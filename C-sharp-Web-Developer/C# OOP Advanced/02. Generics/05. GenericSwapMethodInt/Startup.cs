using System;
using System.Linq;
using _01.Generic_Box;

namespace _05.GenericSwapMethodInt
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Type.Add(input);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap<int>(indexes);
            Console.WriteLine(box.ToString());
        }
    }
}