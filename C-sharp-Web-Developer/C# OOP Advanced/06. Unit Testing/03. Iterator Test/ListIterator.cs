using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Iterator_Test
{
    public class ListIterator
    {
        private List<string> collection;
        public int Index { get; private set; }

        public ListIterator(List<string> collection)
        {
            this.collection = collection;
            this.Index = 0;
        }

        public bool Move()
        {
            if (Index + 1 == collection.Count)
            {
                return false;
            }
            Index++;
            return true;
        }

        public bool HasNext()
        {
            if (Index + 1 == collection.Count)
            {
                return false;
            }
            return true;
        }

        public string Print()
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(collection[Index]);
            return collection[Index];
        }
    }
}