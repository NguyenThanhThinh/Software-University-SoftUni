using System;

namespace _02.Card_Rank
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine($"{input}:");
            var cards = Enum.GetValues(typeof(Cards));

            foreach (var card in cards)
            {
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");    
            }
        }
    }
}