using System;

namespace _01.Generic_Box
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            int result = 0;

            if (int.TryParse(input, out result))
            {
                var box = new Box<int>();
                box.Type = int.Parse(input);
                Console.WriteLine(box.ToString());
            }
            else
            {
                var box = new Box<string>();
                box.Type = input;
                Console.WriteLine(box.ToString());
            }
        }
    }
}