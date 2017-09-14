using System;
using System.Linq;

namespace _04.Froggy
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}