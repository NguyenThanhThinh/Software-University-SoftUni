using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Database
{
    public class Database
    {
        private const int DefaultCapacity = 16;
        private int[] numbers;
        private int currentIndex;

        public Database(IEnumerable<int> numbers)
        {
            this.Numbers = numbers.ToArray();
        }

        public int[] Numbers
        {
            get
            {
                return numbers.Take(currentIndex).ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.numbers = new int[DefaultCapacity];
                int bufferIndex = 0;

                foreach (var element in value)
                {
                    this.numbers[bufferIndex++] = element;
                }
                this.currentIndex = value.Length;
            }
        }

        public int Capacity { get { return DefaultCapacity; } }

        public int Count { get { return this.currentIndex; } }

        public void Add(int number)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements in the collection");
            }
            this.numbers[currentIndex] = number;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }
            this.Numbers[--this.currentIndex] = default(int);
            //this.currentIndex--;
        }
    }
}