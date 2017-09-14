namespace _04.Bubble_Sort
{
    public class Bubble
    {
        private int[] collection;

        public Bubble(int[] collection)
        {
            this.Collection = collection;
        }

        public int[] Collection
        {
            get { return collection; }
            private set { collection = value; }
        }

        public int[] Sort()
        {
            int exchange = 0;
            bool notSorted = true;

            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < this.Collection.Length; i++)
                {
                    exchange = this.Collection[i];
                    if (i + 1 < this.Collection.Length && exchange > this.Collection[i + 1])
                    {
                        this.Collection[i] = this.Collection[i + 1];
                        this.Collection[i + 1] = exchange;
                        notSorted = true;
                    }
                }
            }
            return this.Collection;
        }
    }
}