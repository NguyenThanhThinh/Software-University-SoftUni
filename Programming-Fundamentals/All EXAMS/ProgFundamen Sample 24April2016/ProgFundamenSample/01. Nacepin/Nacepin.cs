using System;

class Nacepin
{
    static void Main(string[] args)
    {
        double usPrice = double.Parse(Console.ReadLine());
        double usWeight = double.Parse(Console.ReadLine());
        double ukPrice = double.Parse(Console.ReadLine());
        double ukWeight = double.Parse(Console.ReadLine());
        double chPrice = double.Parse(Console.ReadLine());
        double chWeight = double.Parse(Console.ReadLine());

        double usPriceResult = (usPrice / 0.58d) / usWeight;
        double ukPriceResult = (ukPrice / 0.41d) / ukWeight;
        double chPriceResult = (chPrice * 0.27d) / chWeight;

        double highestPrice = 0d;
        double lowestPrice = 0d;

        highestPrice = Math.Max(Math.Max(usPriceResult, ukPriceResult), chPriceResult);
        lowestPrice = Math.Min(Math.Min(usPriceResult, ukPriceResult), chPriceResult);

        if (lowestPrice == usPriceResult)
        {
            Console.WriteLine("US store. {0:F2} lv/kg", lowestPrice);
            Console.WriteLine("Difference {0:F2} lv/kg", highestPrice - lowestPrice);
        }
        else if (lowestPrice == ukPriceResult)
        {
            Console.WriteLine("UK store. {0:F2} lv/kg", lowestPrice);
            Console.WriteLine("Difference {0:F2} lv/kg", highestPrice - lowestPrice);
        }
        else
        {
            Console.WriteLine("Chinese store. {0:F2} lv/kg", lowestPrice);
            Console.WriteLine("Difference {0:F2} lv/kg", highestPrice - lowestPrice);
        }
    }
}