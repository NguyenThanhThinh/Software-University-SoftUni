using System;
    class InchToCm
{
    static void Main()
    {
        Console.Write("inches = ");
        double inches = double.Parse(Console.ReadLine());

        double cm = inches * 2.54;

        Console.WriteLine("centimeters = {0}", cm);
    }
}
