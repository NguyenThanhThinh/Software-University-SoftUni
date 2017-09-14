using System;

class SweetDesert
{
    static void Main()
    {
        decimal ivanchoMoney = decimal.Parse(Console.ReadLine());
        int guests = int.Parse(Console.ReadLine());
        decimal priceOFBananas = decimal.Parse(Console.ReadLine());
        decimal priceOFEggs = decimal.Parse(Console.ReadLine());
        decimal priceOFBerries = decimal.Parse(Console.ReadLine());

        int sets = guests / 6;
        if (guests % 6 != 0)
        {
            sets++;
        }

        decimal totalPrice = (sets * (2 * priceOFBananas)) + (sets * (4 * priceOFEggs)) + (sets * (0.2m * priceOFBerries));

        if (totalPrice <= ivanchoMoney)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalPrice - ivanchoMoney:F2}lv more.");
        }
    }
}