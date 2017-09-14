using System;
using System.Text;
using System.Globalization;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal totalPrice = 0m;
        StringBuilder coffeePrices = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            decimal priceCapsule = decimal.Parse(Console.ReadLine());
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            long capsulesCount = long.Parse(Console.ReadLine());

            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            decimal currentPrice = (decimal)(daysInMonth * capsulesCount) * priceCapsule;
            totalPrice += currentPrice;

            coffeePrices.AppendLine($"The price for the coffee is: ${currentPrice:F2}");
        }
        Console.Write(coffeePrices);
        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}