using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace User_Logs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            //string[] line;
            //while (true)
            //{
            //    line = Console.ReadLine().Split(' ');
            //    if (line[0] == "end")
            //        break;

            //    string ip = line[0].Split('=')[1];
            //    string user = line[2].Split('=')[1];

            //    if (!users.ContainsKey(user))
            //    {
            //        users.Add(user, new Dictionary<string, int>());
            //    }

            //    int oldCount = 0;
            //    users[user].TryGetValue(ip, out oldCount);
            //    users[user][ip] = oldCount + 1;
            //}

            //foreach (KeyValuePair<string, Dictionary<string, int>> entry in users)
            //{
            //    Console.WriteLine(entry.Key + ": ");
            //    int i = 1;
            //    int countIps = entry.Value.Count;
            //    foreach (KeyValuePair<string, int> entry2 in entry.Value)
            //    {
            //        Console.Write("{0} => {1}{2}", entry2.Key, entry2.Value, ((i < countIps) ? ", " : "." + Environment.NewLine));
            //        i++;
            //    }
            //}

            Console.WriteLine(int.MaxValue);
            bool az = false;

            if (double.MaxValue < 100 * 100000)
            {
                
                Console.WriteLine("da");
            }
        }
    }
}