using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

public class RectangleIntersection
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();
        int numberOfRectangles = input[0];
        int intersectionChecks = input[1];

        var rectangles = new List<Rectangles>();

        //Adding all Rectangles in a List
        for (int i = 0; i < numberOfRectangles; i++)
        {
            var rectangleInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rectangles.Add(new Rectangles(
                rectangleInfo[0],
                int.Parse(rectangleInfo[1]),
                int.Parse(rectangleInfo[2]),
                int.Parse(rectangleInfo[3]),
                int.Parse(rectangleInfo[4])
                ));
        }

        // Taking all intersection checks
        for (int i = 0; i < intersectionChecks; i++)
        {
            var rectangleIds = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            // checking the List of rectangles, and taking only these which ID is contained in the Array of "IDs" we want to check for each iteration
            bool isIntersect = CheckIfRectanglesIntersect(rectangles.Where(r => rectangleIds.Contains(r.Id)).ToArray());
            Console.WriteLine(isIntersect.ToString().ToLower());

        }
    }

    private static bool CheckIfRectanglesIntersect(params Rectangles[] rectangles)
    {
        bool intersect = true;

        //checking if we have more then to rectangles
        if (rectangles.Length > 1)
        {
            // starting from 1 so I can take every time the 1 behind
            for (int i = 1; i < rectangles.Length; i++)
            {
                
                Rectangle firstRec = new Rectangle(rectangles[i].CorX, rectangles[i].CorY, rectangles[i].Width, rectangles[i].Height);
                Rectangle secRec = new Rectangle(rectangles[i - 1].CorX, rectangles[i - 1].CorY, rectangles[i - 1].Width, rectangles[i - 1].Height);
                var checkIfIntersect = Rectangle.Intersect(firstRec, secRec);

                // Integrated Method which checks the Intersect condition
                if (!firstRec.IntersectsWith(secRec))
                {
                    intersect = false;
                    break;
                }

                // I saw this check in StackOverFlow, in certain condition it returns empty rectangle which means False  
                if (checkIfIntersect == Rectangle.Empty)
                {
                    intersect = false;
                    break;
                }
            }
        }
        // if we have just one rectangle to check is "intersected with itself". I tried to put throw new Exception here, but in Judge nothing changed
        if (rectangles.Length == 1)
        {
            return true;
        }

        return intersect;
    }
}