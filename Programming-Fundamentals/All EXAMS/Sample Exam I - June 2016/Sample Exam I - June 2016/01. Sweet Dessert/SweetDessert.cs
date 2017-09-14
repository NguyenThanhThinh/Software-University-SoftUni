using System;

class SweetDesert
{
    static void Main(string[] args)
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        int guests = int.Parse(Console.ReadLine());
        decimal priceOfBanana = decimal.Parse(Console.ReadLine());
        decimal priceOfEggs = decimal.Parse(Console.ReadLine());
        decimal priceOfBerries = decimal.Parse(Console.ReadLine());

        int portions = guests / 6;

        if (guests % 6 != 0)
        {
            portions++;
        }

        decimal priceOfBananaPerPortion = priceOfBanana * 2M;
        decimal priceOfEggsPerPortion = priceOfEggs * 4M;
        decimal priceOfBerriesPerPortion = priceOfBerries * 0.2M;

        decimal totalCost = (priceOfBananaPerPortion * portions) + (priceOfEggsPerPortion * portions) + (priceOfBerriesPerPortion * portions);

        if (totalCost <= cash)
        {
            Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", totalCost);
        }
        else
        {
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", totalCost - cash);
        }
    }
}