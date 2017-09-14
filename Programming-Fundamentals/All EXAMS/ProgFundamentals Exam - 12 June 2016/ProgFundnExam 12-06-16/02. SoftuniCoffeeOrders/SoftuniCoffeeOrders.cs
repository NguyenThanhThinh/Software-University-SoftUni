using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


class SoftuniCoffeeOrders
{
    static void Main(string[] args)
    {
        int orders = int.Parse(Console.ReadLine());
        decimal pricePerCapsule = 0M;
        DateTime orderDate = new DateTime();
        int capsuleCount = 0;
        int daysInMonth = 0;
        decimal totalPrice = 0M;
        decimal currentPrice = 0M;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < orders; i++)
        {
            pricePerCapsule = decimal.Parse(Console.ReadLine());
            orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            capsuleCount = int.Parse(Console.ReadLine());
            daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            currentPrice = (daysInMonth * capsuleCount) * pricePerCapsule;
            result.AppendLine($"The price for the coffee is: ${currentPrice:F2}");
            totalPrice += currentPrice;
        }

        result.AppendLine($"Total: ${totalPrice:F2}");

        Console.WriteLine(result.ToString());
    }
}

