using System;
using System.Collections.Generic;
using _01.Generic_Box;

namespace _03.GenericBoxInt
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(input));
            }

            boxes.ForEach(b => Console.WriteLine(b.ToString()));
        }
    }
}