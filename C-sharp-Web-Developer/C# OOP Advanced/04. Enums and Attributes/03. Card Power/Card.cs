using System;
using _01.Card_Suit;

namespace _03.Card_Power
{
    public class Card
    {
        private string currentRank;
        private string currentSuit;

        public Card(string currentRank, string currentSuit)
        {
            this.CurrentRank = currentRank;
            this.CurrentSuit = currentSuit;
        }

        public string CurrentRank
        {
            get { return currentRank; }
            set { currentRank = value; }
        }

        public string CurrentSuit
        {
            get { return currentSuit; }
            set { currentSuit = value; }
        }

        public override string ToString()
        {
            return String.Format($"Card name: {this.CurrentRank} of {this.CurrentSuit}; Card power: {GetCardPower()}");
        }

        private int GetCardPower()
        {
            var rank = (int)Enum.Parse(typeof(Rank), this.CurrentRank);
            var suit = (int)Enum.Parse(typeof(Suit), this.CurrentSuit);

            return rank + suit;
        }
    }
}