using System;

namespace _03.Card_Power
{
    public class Startup
    {
        public static void Main()
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();
            var card = new Card(rank, suit);
            Console.WriteLine(card.ToString());
        }
    }
}