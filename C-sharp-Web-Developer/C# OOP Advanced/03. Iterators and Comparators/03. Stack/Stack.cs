using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data = new List<T>();

        public void Push(T number)
        {
            this.data.Add(number);
        }

        public void Pop()
        {
            if (this.data.Count == 0 || this.data.Equals(null))
            {
                throw new ArgumentException("No elements");
            }
            int lastIndex = this.data.Count - 1;
            this.data.RemoveAt(lastIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}