using System;
using System.Text;

public class ShapeVolumes
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var result = new StringBuilder();

        while (!input.Equals("End"))
        {
            var takeData = input.Split();
            string shape = takeData[0];

            // Creating new objects which I do not save anywhere, and use them as parameter so I can stick to the assignment and use these objects somehow
            switch (shape)
            {
                case "Cube":
                    double sideLenght = double.Parse(takeData[1]);
                    result.AppendLine(VolumeCalculator.CalculateCubeVolume(new Cube(sideLenght)));
                    break;
                case "Cylinder":
                    double radius = double.Parse(takeData[1]);
                    double height = double.Parse(takeData[2]);
                    result.AppendLine(VolumeCalculator.CalculateCylinderVolume(new Cylinder(radius, height)));
                    break;
                case "TrianglePrism":
                    double baseSide = double.Parse(takeData[1]);
                    double triangleHeight = double.Parse(takeData[2]);
                    double length = double.Parse(takeData[3]);
                    result.AppendLine(
                        VolumeCalculator.CalculateTriangularPrismVolume(new TriangularPrism(baseSide, triangleHeight, length)));
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}