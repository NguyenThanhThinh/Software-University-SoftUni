using System;
using System.Collections.Generic;
using _01.Generic_Box;

namespace _02.GenericBoxString
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                boxes.Add(new Box<string>(input));
            }

            boxes.ForEach(b => Console.WriteLine(b.ToString()));
        }
    }
}