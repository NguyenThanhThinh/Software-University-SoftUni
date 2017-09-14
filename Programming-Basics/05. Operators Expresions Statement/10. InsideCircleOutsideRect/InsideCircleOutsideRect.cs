using System;

class InsideCircleOutsideRect
{
    static void Main(string[] args)
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double d = Math.Pow((1 - x), 2) + Math.Pow((1 - y), 2);

        if (d <= 1.5 * 1.5)
        {
            if (x < -1 || x > 5 || y > 1 || y < -1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            } 
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}