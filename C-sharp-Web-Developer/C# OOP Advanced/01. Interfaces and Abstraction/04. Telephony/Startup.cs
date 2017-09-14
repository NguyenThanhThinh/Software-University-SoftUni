using System;
using System.Linq;

namespace _04.Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split(new char[] {' ', '\t'}).ToList();
            var webs = Console.ReadLine().Split(new char[] { ' ', '\t' }).ToList();

            Smartphone smartphone = new Smartphone(phoneNumbers, webs);

            smartphone.Call();
            smartphone.Browse();
        }
    }
}