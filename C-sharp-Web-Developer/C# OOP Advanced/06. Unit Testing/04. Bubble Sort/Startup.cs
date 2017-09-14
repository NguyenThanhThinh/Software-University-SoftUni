using System;

namespace _04.Bubble_Sort
{
    public class Startup
    {
        public static void Main()
        {
            Bubble bubble = new Bubble(new int[] { 4, 51, 9, 42, 7 });
            Console.WriteLine(string.Join(", ", bubble.Sort()));
        }
    }
}