using System;

namespace _03.Card_Power
{
    public class Startup
    {
        public static void Main()
        {
            var firstRank = Console.ReadLine();
            var firstSuit = Console.ReadLine();
            var secondRank = Console.ReadLine();
            var secondSuit = Console.ReadLine();
            var firstCard = new Card(firstRank, firstSuit);
            var secondCard = new Card(secondRank, secondSuit);

            Console.WriteLine(firstCard.CompareTo(secondCard) < 0 ? secondCard.ToString() : firstCard.ToString());
        }
    }
}