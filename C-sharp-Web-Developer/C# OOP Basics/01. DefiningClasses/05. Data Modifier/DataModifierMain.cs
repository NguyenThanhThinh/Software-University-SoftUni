using System;

public class DataModifierMain
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        var dateModifier = new DateModifier();
        dateModifier.CalculateDifferenceBetweenTwoDates(firstDate, secondDate);

        Console.WriteLine(dateModifier.DifferenceBetweenTwoDates);
    }
}