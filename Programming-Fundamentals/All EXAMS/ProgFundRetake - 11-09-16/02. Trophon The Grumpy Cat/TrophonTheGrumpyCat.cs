using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var priceRatings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        int entryPoint = int.Parse(Console.ReadLine());
        string typeOfItems = Console.ReadLine();
        string typeOfPriceRatings = Console.ReadLine();
        long leftSum = 0L;
        long rightSum = 0L;

        if (typeOfItems.Equals("cheap"))
        {
            leftSum = CalculateLeftDamageCheap(typeOfPriceRatings, priceRatings, entryPoint);
            rightSum = CalculateRightDamageCheap(typeOfPriceRatings, priceRatings, entryPoint);
            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }

        }
        else if (typeOfItems.Equals("expensive"))
        {
            leftSum = CalculateLeftDamageExpensive(typeOfPriceRatings, priceRatings, entryPoint);
            rightSum = CalculateRightDamageExpensive(typeOfPriceRatings, priceRatings, entryPoint);
            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }
    }

    private static long CalculateRightDamageExpensive(string typeOfPriceRatings, List<long> priceRatings, int entryPoint)
    {
        long sum = 0L;

        switch (typeOfPriceRatings)
        {
            case "positive":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n > 0 && n >= priceRatings[entryPoint]).Sum();
                break;
            case "negative":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n < 0 && n >= priceRatings[entryPoint]).Sum();
                break;
            case "all":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n >= priceRatings[entryPoint]).Sum();
                break;
            default:
                sum = -1;
                break;
        }
        return sum;
    }

    private static long CalculateLeftDamageExpensive(string typeOfPriceRatings, List<long> priceRatings, int entryPoint)
    {
        long sum = 0L;

        switch (typeOfPriceRatings)
        {
            case "positive":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n > 0 && n >= priceRatings[entryPoint]).Sum();
                break;
            case "negative":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n < 0 && n >= priceRatings[entryPoint]).Sum();
                break;
            case "all":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n >= priceRatings[entryPoint]).Sum();
                break;
            default:
                sum = -1;
                break;
        }
        return sum;
    }

    private static long CalculateLeftDamageCheap(string typeOfPriceRatings, List<long> priceRatings, int entryPoint)
    {
        long sum = 0L;

        switch (typeOfPriceRatings)
        {
            case "positive":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n > 0 && n < priceRatings[entryPoint]).Sum();
                break;
            case "negative":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n < 0 && n < priceRatings[entryPoint]).Sum();
                break;
            case "all":
                sum = priceRatings.GetRange(0, entryPoint).Where(n => n < priceRatings[entryPoint]).Sum();
                break;
            default:
                sum = -1;
                break;
        }
        return sum;
    }

    private static long CalculateRightDamageCheap(string typeOfPriceRatings, List<long> priceRatings, int entryPoint)
    {
        long sum = 0L;

        switch (typeOfPriceRatings)
        {
            case "positive":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n > 0 && n < priceRatings[entryPoint]).Sum();
                break;
            case "negative":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n < 0 && n < priceRatings[entryPoint]).Sum();
                break;
            case "all":
                sum = priceRatings.GetRange(entryPoint, priceRatings.Count() - 1 - entryPoint).Where(n => n < priceRatings[entryPoint]).Sum();
                break;
            default:
                sum = -1;
                break;
        }
        return sum;
    }
}