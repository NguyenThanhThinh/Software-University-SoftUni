using System;

public class Startup
{
    public static void Main()
    {
        var scale = new Scale<string>("a", "b");
        Console.WriteLine(scale.GetHavier());
    }
}