using System;

namespace _01.Card_Suit
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