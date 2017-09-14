using System;
using System.Linq;

namespace _03.IntersectionOfCircles
{
    public class IntersectionOfCircles
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Point p1 = new Point(input[0], input[1]);
            Circle c1 = new Circle(p1, input[2]);


            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Point p2 = new Point(input[0], input[1]);
            Circle c2 = new Circle(p2, input[2]);

            if (Circle.Intersect(c1, c2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}