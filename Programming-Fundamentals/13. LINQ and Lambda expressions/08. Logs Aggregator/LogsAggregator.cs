using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LogsAggregator
{
    static void Main()
    {
        int numberLines = int.Parse(Console.ReadLine());
        var logs = new SortedDictionary<string, SortedDictionary<string, long>>();

        for (int i = 0; i < numberLines; i++)
        {
            var separateLine = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string ip = separateLine[0];
            string user = separateLine[1];
            long duration = long.Parse(separateLine[2]);

            if (!logs.ContainsKey(user))
            {
                logs[user] = new SortedDictionary<string, long>();
                logs[user].Add(ip, duration);

            }
            else
            {
                if (!logs[user].ContainsKey(ip))
                {
                    logs[user].Add(ip, duration);
                }
                else
                {
                    logs[user][ip] += duration;
                }
            }
        }

        Console.WriteLine();
        StringBuilder listOfIPs = new StringBuilder();

        foreach (var user in logs)
        {
            Console.Write(user.Key + ": ");
            Console.Write(user.Value.Sum(n => n.Value) + " [");
            foreach (var ip in user.Value)
            {
                listOfIPs.Append(ip.Key + ", ");

            }
            listOfIPs.Remove(listOfIPs.Length - 2, 2);
            Console.Write(listOfIPs);
            Console.WriteLine("]");
            listOfIPs.Clear();
        }
    }
}