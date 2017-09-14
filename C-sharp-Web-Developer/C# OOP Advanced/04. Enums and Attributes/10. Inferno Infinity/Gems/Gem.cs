namespace _10.Inferno_Infinity
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;
        private string quality;

        protected Gem(int strength, int agility, int vitality, string quality)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.Quality = quality;
            IncreaseStats(this.Quality);
        }

        public int Strength
        {
            get { return strength; }
            protected set { strength = value; }
        }

        public int Agility
        {
            get { return agility; }
            protected set { agility = value; }
        }

        public int Vitality
        {
            get { return vitality; }
            protected set { vitality = value; }
        }

        public string Quality
        {
            get { return quality; }
            protected set { quality = value; }
        }

        protected void IncreaseStats(string quality)
        {
            int increaseValue = GetIncreaseValueByQuality(quality);
            this.Strength += increaseValue;
            this.Agility += increaseValue;
            this.Vitality += increaseValue;
        }

        protected static int GetIncreaseValueByQuality(string quality)
        {
            switch (quality)
            {
                case "Chipped":
                    return 1;
                case "Regular":
                    return 2;
                case "Perfect":
                    return 5;
                case "Flawless":
                    return 10;
            }

            return 0;
        }
    }
}