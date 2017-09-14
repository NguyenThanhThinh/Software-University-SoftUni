using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RectangleIntersectionMain
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var rectangles = new Dictionary<string, Rectangle>();
        var sb = new StringBuilder();

        for (int i = 0; i < input[0]; i++)
        {
            var rectangleInfo = Console.ReadLine().Split();
            string id = rectangleInfo[0];
            double width = double.Parse(rectangleInfo[1]);
            double height = double.Parse(rectangleInfo[2]);
            double horizontal = double.Parse(rectangleInfo[3]);
            double vertical = double.Parse(rectangleInfo[4]);

            rectangles[id] = new Rectangle()
            {
                Id = id,
                Width = width,
                Height = height,
                Horizontal = horizontal,
                Vertical = vertical
            };
        }

        for (int i = 0; i < input[1]; i++)
        {
            var checksInput = Console.ReadLine().Split();
            string firstId = checksInput[0];
            string secondId = checksInput[1];

            if (rectangles[firstId].CheckIfRectanglesIntersect(rectangles[secondId]))
            {
                sb.AppendLine("true");
            }
            else
            {
                sb.AppendLine("false");
            }
        }

        Console.WriteLine(sb);
    }
}