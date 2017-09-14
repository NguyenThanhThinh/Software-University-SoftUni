using System;

public class DateModifier
{
    public static void Main()
    {
        var firstDateInput = Console.ReadLine();
        var secondDateInput = Console.ReadLine();

        Console.WriteLine(DateModifierClass.DifferenceBetweenTwoDates(firstDateInput, secondDateInput));
    }
}