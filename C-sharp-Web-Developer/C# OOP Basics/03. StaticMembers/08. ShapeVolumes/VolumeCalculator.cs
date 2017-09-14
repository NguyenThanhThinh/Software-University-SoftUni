using System;

public class VolumeCalculator
{
    public static string CalculateCubeVolume(Cube cube)
    {
        return string.Format($"{Math.Pow(cube.SideLenght, 3):F3}");
    }

    public static string CalculateCylinderVolume(Cylinder cylinder)
    {
        return string.Format($"{Math.PI * Math.Pow(cylinder.Radius, 2) * cylinder.Height:F3}");
    }

    public static string CalculateTriangularPrismVolume(TriangularPrism triangularPrism)
    {
        return string.Format($"{(triangularPrism.BaseSide / 2) * triangularPrism.Height * triangularPrism.Length:F3}");
    }
}