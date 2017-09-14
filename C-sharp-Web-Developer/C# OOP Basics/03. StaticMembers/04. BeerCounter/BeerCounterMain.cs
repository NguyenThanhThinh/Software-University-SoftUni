using System;
using System.Linq;

public class BeerCounterMain
{
    public static void Main()
    {
        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var getBeerInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            BeerCounter.BuyBeer(getBeerInfo[0]);
            BeerCounter.DrinkBeer(getBeerInfo[1]);
            input = Console.ReadLine();
        }

        Console.WriteLine($"{BeerCounter.BeerInStock} {BeerCounter.BeersDrankCount}");
    }
}