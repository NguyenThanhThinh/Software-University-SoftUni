using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    class AndreyAndBilliard
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var priceList = new Dictionary<string, decimal>();
            var clientOrders = new Dictionary<string, Dictionary<string, int>>();
            var clientBills = new SortedDictionary<string, Dictionary<string, decimal>>();

            for (int i = 0; i < n; i++)
            {
                var stockInput = Console.ReadLine().Split('-');
                priceList[stockInput[0]] = decimal.Parse(stockInput[1]);

            }

            string clients = Console.ReadLine();

            while (clients != "end of clients")
            {
                var orders = clients.Split(new char[] { '-', ',' });
                string name = orders[0];
                string product = orders[1];
                int quantity = int.Parse(orders[2]);

                if (!clientOrders.ContainsKey(name))
                {
                    clientOrders[name] = new Dictionary<string, int>();

                    if (priceList.ContainsKey(product))
                    {
                        clientOrders[name].Add(product, quantity);
                    }
                    else
                    {
                        clientOrders.Remove(name);
                    }
                }
                else
                {
                    if (priceList.ContainsKey(product))
                    {
                        if (clientOrders[name].ContainsKey(product))
                        {
                            clientOrders[name][product] += quantity;
                        }
                        else
                        {
                            clientOrders[name].Add(product, quantity);
                        }
                    }
                }
                clients = Console.ReadLine();
            }

            decimal totalBill = 0M;

            foreach (var client in clientOrders)
            {
                if (!clientBills.ContainsKey(client.Key))
                {
                    clientBills[client.Key] = new Dictionary<string, decimal>();
                }
                foreach (var order in client.Value)
                {
                    clientBills[client.Key].Add(order.Key, order.Value * priceList[order.Key]);
                    totalBill += order.Value * priceList[order.Key];
                }
            }

            foreach (var client in clientBills)
            {
                Console.WriteLine("{0}", client.Key);
                foreach (var product in client.Value)
                {
                    Console.WriteLine("-- {0} - {1}", product.Key, product.Value / priceList[product.Key]);
                }
                Console.WriteLine("Bill: {0:F2}", client.Value.Sum(m => m.Value));
            }
            Console.WriteLine("Total bill: {0:F2}", totalBill);
        }
    }
}