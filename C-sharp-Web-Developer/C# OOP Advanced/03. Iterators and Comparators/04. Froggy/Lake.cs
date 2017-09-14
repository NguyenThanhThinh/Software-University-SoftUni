using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.Stones = stones;
        }

        public List<int> Stones
        {
            get { return stones; }
            set { stones = value; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Count; i += 2)
            {
                yield return this.Stones[i];
            }

            int nextIndex = this.Stones.Count % 2 == 0 ? this.Stones.Count - 1 : this.Stones.Count - 2;

            for (int i = nextIndex; i >= 0; i -= 2)
            {
                yield return this.Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}