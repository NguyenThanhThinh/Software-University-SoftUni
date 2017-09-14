using System;
using System.Collections.Generic;

namespace _01.Generic_Box
{
    public class Box<T>
    {
        private List<T> collection;

        public Box()
        {
            this.Collection = new List<T>();
        }

        public List<T> Collection
        {
            get { return collection; }
            set { collection = value; }
        }

        public int Compare<T>(T element)
            where T : IComparable
        {
            int count = 0;

            for (int i = 0; i < this.Collection.Count; i++)
            {
                var compare = element.CompareTo(this.Collection[i]);
                if (compare < 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}