using System;
using System.Linq;
using _01.Generic_Box;

namespace _04.GenericSwapMethodStrings
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Type.Add(input);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap<string>(indexes);
            Console.WriteLine(box.ToString());
        }
    }
}