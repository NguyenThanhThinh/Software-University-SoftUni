using System;
using FastFood.Data;
namespace FastFood.DataProcessor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Dto.Import;
    using Models;
    using Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (var employee in jsonEmployees)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                Position position = employees.FirstOrDefault(p => p.Position.Name == employee.Position)?.Position;

                if (position == null)
                {
                    position = new Position
                    {
                        Name = employee.Position
                    };
                }

                if (!IsValid(position))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Employee currentEmployee = new Employee
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Position = position
                };

                employees.Add(currentEmployee);
                sb.AppendLine(String.Format(SuccessMessage, currentEmployee.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var items = new List<Item>();

            foreach (var item in jsonItems)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                string itemName = item.Name;

                if (items.Any(n => n.Name == itemName))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = items.FirstOrDefault(c => c.Category.Name == item.Category)?.Category;

                if (category == null)
                {
                    category = new Category
                    {
                        Name = item.Category
                    };
                }

                Item currentItem = new Item
                {
                    Name = itemName,
                    Price = item.Price,
                    Category = category
                };

                items.Add(currentItem);
                sb.AppendLine(String.Format(SuccessMessage, currentItem.Name));
            }

            context.AddRange(items);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));

            var orderDto = (OrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var orders = new List<Order>();

            foreach (var order in orderDto)
            {
                if (!IsValid(order))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Employee employee = context.Employees.FirstOrDefault(e => e.Name == order.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var t = order.DateTime;
                DateTime dateTime = DateTime.ParseExact(order.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                OrderType type = Enum.Parse<OrderType>(order.Type);

                //•	If any of the order’s items do not exist, do not import the order.
                bool itemsExist = order.Items.All(i => context.Items.Any(it => it.Name == i.Name));

                if (!itemsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var orderItems = new List<OrderItem>();

                Order currentOrder = new Order
                {
                    Customer = order.Customer,
                    Employee = employee,
                    DateTime = dateTime,
                    Type = type
                };

                foreach (var oi in order.Items)
                {
                    var item = context.Items.FirstOrDefault(i => i.Name == oi.Name);

                    var orderItem = new OrderItem
                    {
                        Item = item,
                        Order = currentOrder,
                        Quantity = oi.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                currentOrder.OrderItems = orderItems;

                orders.Add(currentOrder);
                sb.AppendLine($"Order for {currentOrder.Customer} on {dateTime.ToString("dd/MM/yyyy HH:mm")} added");
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}