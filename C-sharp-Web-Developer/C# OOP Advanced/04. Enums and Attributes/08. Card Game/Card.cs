using System;
using _01.Card_Suit;

namespace _03.Card_Power
{
    public class Card : IComparable<Card>
    {
        private string currentRank;
        private string currentSuit;
        private readonly Array ranks;
        private readonly Array suits;
        private const string cardDoNotExist = "No such card exists.";

        public Card(string currentRank, string currentSuit)
        {
            this.ranks = Enum.GetValues(typeof(Rank));
            this.suits = Enum.GetValues(typeof(Suit));
            this.CurrentRank = currentRank;
            this.CurrentSuit = currentSuit;
        }

        public string CurrentRank
        {
            get { return currentRank; }
            set
            {
                if (!IsValidCard(this.ranks, value))
                {
                    throw new ArgumentException(cardDoNotExist);
                }
                currentRank = value;
            }
        }

        public string CurrentSuit
        {
            get { return currentSuit; }
            set
            {
                if (!IsValidCard(this.suits, value))
                {
                    throw new ArgumentException(cardDoNotExist);
                }
                currentSuit = value;
            }
        }

        public int CompareTo(Card other)
        {
            if (String.Compare(this.CurrentRank, other.CurrentRank, StringComparison.Ordinal) == 0)
            {
                return String.Compare(this.CurrentSuit, other.CurrentSuit, StringComparison.Ordinal);
            }
            return String.Compare(this.CurrentRank, other.CurrentRank, StringComparison.Ordinal);
        }

        public override bool Equals(object card)
        {
            if (CompareTo(card as Card) == 0)
            {
                return true;
            }
            return false;
        }

        public int GetCardPower()
        {
            var rank = (int)Enum.Parse(typeof(Rank), this.CurrentRank);
            var suit = (int)Enum.Parse(typeof(Suit), this.CurrentSuit);

            return rank + suit;
        }

        private bool IsValidCard(Array currentEnum, string value)
        {
            foreach (var item in currentEnum)
            {
                if (item.ToString().Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}