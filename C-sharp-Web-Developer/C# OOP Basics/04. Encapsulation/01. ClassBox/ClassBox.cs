using System;
using System.Linq;
using System.Reflection;

public class ClassBox
{
    public static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        var currentBox = new Box(lenght, width, height);

        GetAreasAndVolume(currentBox);
    }

    public static void GetAreasAndVolume(Box currentBox)
    {
        Console.WriteLine($"Surface Area - {currentBox.Surfacearea():F2}");
        Console.WriteLine($"Lateral Surface Area - {currentBox.LateralSurfacearea():F2}");
        Console.WriteLine($"Volume - {currentBox.Volume():F2}");
    }
}