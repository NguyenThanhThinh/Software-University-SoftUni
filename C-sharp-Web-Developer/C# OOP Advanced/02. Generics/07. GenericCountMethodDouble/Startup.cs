using System;
using _01.Generic_Box;

namespace _07.GenericCountMethodDouble
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Collection.Add(input);
            }

            var element = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Compare(element));
        }
    }
}