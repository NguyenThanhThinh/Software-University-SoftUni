using System.Collections.Generic;
using _03.Card_Power;

namespace _08.Card_Game
{
    public abstract class Player
    {
        private string name;
        private List<Card> cards;

        protected Player(string name)
        {
            this.Name = name;
            this.Cards = new List<Card>();
        }

        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Card FindPowerfulestCard()
        {
            int bestPower = 0;
            int cardIndex = 0;

            foreach (Card card in this.Cards)
            {
                if (card.GetCardPower() > bestPower)
                {
                    bestPower = card.GetCardPower();
                    cardIndex = this.Cards.IndexOf(card);
                }
            }

            return this.Cards[cardIndex];
        }

    }
}