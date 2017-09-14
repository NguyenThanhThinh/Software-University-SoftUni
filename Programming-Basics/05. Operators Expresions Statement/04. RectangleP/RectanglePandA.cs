using System;

class RectanglePandA
{
    static void Main()
    {
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());

        decimal perimeter = 2 * (width + height);
        decimal area = width * height;

        Console.WriteLine("Perimeter is: {0} \nArea is: {1}", perimeter, area);
    }
}