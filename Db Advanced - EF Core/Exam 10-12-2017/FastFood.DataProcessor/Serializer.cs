using System;
using System.IO;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Dto.Export.Category;
    using Dto.Export.Employee;
    using Models.Enums;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<OrderType>(orderType);

            var orders = context.Employees
                .Where(o => o.Name == employeeName)
                .Select(o => new OrderDto
                {
                    Name = o.Name,
                    Orders = o.Orders.Where(or => or.Type == type)
                    .Select(oi => new OrderItemsDto
                    {
                        Customer = oi.Customer,
                        Items = oi.OrderItems.Select(i => new ItemDto
                        {
                            Name = i.Item.Name,
                            Quantity = i.Quantity,
                            Price = i.Item.Price
                        }).ToList(),
                        TotalPrice = 0.0m
                    })
                   .ToList(),
                    TotalMade = 0.0m
                }).ToArray();


            foreach (var item in orders)
            {
                var currentOrders = item.Orders;

                foreach (var order in currentOrders)
                {
                    order.TotalPrice = order.Items.Sum(i => i.Price * i.Quantity);
                }
            }

            foreach (var order in orders)
            {
                order.Orders = order.Orders.OrderByDescending(o => o.TotalPrice).ThenByDescending(o => o.Items.Count).ToList();
                order.TotalMade = order.Orders.Sum(o => o.TotalPrice);
            }

            var serialize = JsonConvert.SerializeObject(orders.First(), Newtonsoft.Json.Formatting.Indented);

            return serialize;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var sb = new StringBuilder();

            var categoryNames = categoriesString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<CategoryDto> categories = new List<CategoryDto>();

            foreach (var category in categoryNames)
            {
                var categoryId = context.Categories.FirstOrDefault(c => c.Name == category).Id;

                var items = context.Items.Where(i => i.CategoryId == categoryId);

                var mostSoldItem = items.OrderByDescending(i => i.OrderItems.Sum(oi => oi.Quantity) * i.Price).First();

                var currentCategory = new CategoryDto
                {
                    Name = category,
                    MostPopularItem = new MostPopularItemDto
                    {
                        Name = mostSoldItem.Name,
                        TotalMade = ((mostSoldItem.OrderItems.Sum(o => o.Quantity)) * mostSoldItem.Price).ToString("F2"),
                        TimesSold = mostSoldItem.OrderItems.Sum(o => o.Quantity)
                    }
                };

                categories.Add(currentCategory);
            }

            var orderCategories = categories.OrderByDescending(c => decimal.Parse(c.MostPopularItem.TotalMade))
                .ThenByDescending(c => c.MostPopularItem.TimesSold).ToArray();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), orderCategories, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
    }
}