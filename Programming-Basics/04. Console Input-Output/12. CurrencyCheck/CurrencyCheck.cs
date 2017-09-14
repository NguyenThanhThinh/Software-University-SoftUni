using System;

class CurrencyCheck
{
    static void Main()
    {
        double rublesAmount = double.Parse(Console.ReadLine());
        double dollarsAmount = double.Parse(Console.ReadLine());
        double euroAmount = double.Parse(Console.ReadLine());
        double specialB = double.Parse(Console.ReadLine());
        double specialM = double.Parse(Console.ReadLine());

        double rublesInLv = (rublesAmount / 100) * 3.5;
        double dollarsInLv = dollarsAmount * 1.5;
        double euroInLv = euroAmount * 1.95;
        double specialBInLv = specialB / 2;
        double specialMInLv = specialM;

        double bestPriceOne = Math.Min(rublesInLv, dollarsInLv);
        double bestPriceTwo = Math.Min(euroInLv, specialBInLv);
        double finalBestPrice = Math.Min(bestPriceOne, bestPriceTwo);
        finalBestPrice = Math.Min(finalBestPrice, specialM);

        Console.WriteLine("{0:F2}", finalBestPrice);
    }
}