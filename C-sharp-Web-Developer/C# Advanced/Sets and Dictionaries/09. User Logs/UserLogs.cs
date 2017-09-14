using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UserLogs
{
    public static void Main()
    {
        var log = Console.ReadLine();
        var usernameAndIp = new Dictionary<string, Dictionary<string, int>>();

        while (log != "end")
        {
            var logSeparated = log.Split("= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var username = logSeparated[5];
            var iP = logSeparated[1];

            if (!usernameAndIp.ContainsKey(username))
            {
                usernameAndIp[username] = new Dictionary<string, int>();
                usernameAndIp[username].Add(iP, 1);
            }
            else
            {
                if (usernameAndIp[username].ContainsKey(iP))
                {
                    usernameAndIp[username][iP] += 1;
                }
                else
                {
                    usernameAndIp[username].Add(iP, 1);
                }
            }
            log = Console.ReadLine();
        }

        var orderedUsernameAndIp = usernameAndIp.OrderBy(n => n.Key);
        StringBuilder printResult = new StringBuilder();

        foreach (var user in orderedUsernameAndIp)
        {
            Console.WriteLine("{0}:", user.Key);
            foreach (var ip in user.Value)
            {
                printResult.AppendFormat("{0} => {1}, ", ip.Key, ip.Value);
            }
            printResult.Remove((printResult.Length - 2), 2);
            printResult.Insert(printResult.Length, '.');
            Console.WriteLine(printResult);
            printResult.Clear();
        }
    }
}