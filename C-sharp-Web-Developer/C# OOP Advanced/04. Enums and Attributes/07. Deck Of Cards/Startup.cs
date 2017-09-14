using System;
using _01.Card_Suit;
using _03.Card_Power;

namespace _07.Deck_Of_Cards
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var ranks = Enum.GetValues(typeof(Rank));
            var suits = Enum.GetValues(typeof(Suit));

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}