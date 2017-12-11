using System;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    using System.Linq;

    public static class Bonus
    {
        public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
        {
            var item = context.Items.SingleOrDefault(i => i.Name == itemName);

            string result = String.Empty;

            if (item == null)
            {
                result = $"Item {itemName} not found!";
                return result;
            }

            result = $"{itemName} Price updated from ${item.Price:F2} to ${newPrice:F2}";

            item.Price = newPrice;

            context.SaveChanges();

            return result;
        }
    }
}