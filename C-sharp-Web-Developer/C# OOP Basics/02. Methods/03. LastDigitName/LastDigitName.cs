using System;

public class LastDigitName
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        var num = new Number(number);
        num.ReturnEnglishNameOfLastDigitInNum();
    }
}