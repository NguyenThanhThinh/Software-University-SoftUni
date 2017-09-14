using System;
using _01.Generic_Box;

namespace _06.GenericCountMethodStrings
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Collection.Add(input);
            }

            var element = Console.ReadLine();
            Console.WriteLine(box.Compare(element));
        }
    }
}