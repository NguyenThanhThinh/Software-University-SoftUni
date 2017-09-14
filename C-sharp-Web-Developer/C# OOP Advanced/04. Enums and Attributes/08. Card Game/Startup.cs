using System;
using System.Collections.Generic;
using System.Linq;
using _03.Card_Power;

namespace _08.Card_Game
{
    public class Startup
    {
        private static List<Card> allGivenCards = new List<Card>();

        public static void Main()
        {
            var firstPlayer = new FirstPlayer(Console.ReadLine());
            var secondPlayer = new FirstPlayer(Console.ReadLine());

            while (firstPlayer.Cards.Count < 5)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    AddPlayerCard(input, firstPlayer);
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }

            while (secondPlayer.Cards.Count < 5)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    AddPlayerCard(input, secondPlayer);
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }

            CheckWhoWins(firstPlayer, secondPlayer);
        }

        private static void AddPlayerCard(string[] input, Player player)
        {
            var rank = input[0];
            var suit = input[2];
            var card = new Card(rank, suit);
            HasCardInTheDesk(card);
            player.Cards.Add(card);
            allGivenCards.Add(card);
        }

        public static void HasCardInTheDesk(Card card)
        {
            if (allGivenCards.Any(c => c.Equals(card)))
            {
                throw new ArgumentException("Card is not in the deck.");
            }
        }

        public static void CheckWhoWins(Player first, Player second)
        {
            var firstPlayerPowerfullestCard = first.FindPowerfulestCard();
            var secondPlayerPowerfullestCard = second.FindPowerfulestCard();

            Console.WriteLine(firstPlayerPowerfullestCard.CompareTo(secondPlayerPowerfullestCard) < 0 ? 
                string.Format($"{first.Name} wins with {firstPlayerPowerfullestCard.CurrentRank} of {firstPlayerPowerfullestCard.CurrentSuit}.") 
                : string.Format($"{second.Name} wins with {secondPlayerPowerfullestCard.CurrentRank} of {secondPlayerPowerfullestCard.CurrentSuit}."));
        }
    }
}