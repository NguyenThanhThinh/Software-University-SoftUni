using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _08.CistomList
{
    public class DataStructure<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> data;

        public DataStructure()
        {
            this.Data = new List<T>();
        }

        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public void Remove(int index)
        {
            this.Data.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            if (this.Data.Contains(element))
            {
                return true;
            }
            return false;
        }

        public void Swap(int indexOne, int indexTwo)
        {
            T firstValue = this.Data[indexOne];
            this.Data[indexOne] = this.Data[indexTwo];
            this.Data[indexTwo] = firstValue;
        }

        public int CountGreaterThan<T>(T element)
            where T : IComparable
        {
            int count = 0;

            for (int i = 0; i < this.Data.Count; i++)
            {
                if (element.CompareTo(this.Data[i]) < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            T max = this.Data[0];

            for (int i = 1; i < this.Data.Count; i++)
            {
                if (this.Data[i].CompareTo(max) > 0)
                {
                    max = this.Data[i];
                }
            }

            return max;
        }

        public T Min()
        {
            T min = this.Data[0];

            for (int i = 1; i < this.Data.Count; i++)
            {
                if (this.Data[i].CompareTo(min) < 0)
                {
                    min = this.Data[i];
                }
            }

            return min;
        }

        //PROBLEM 9
        public int CompareTo(T other)
        {
            //return other.CompareTo()
            return 0;
        }

        // PROBLEM 10
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Data.Count; i++)
            {
                yield return this.Data[i];
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            this.Data.ForEach(a => sb.AppendLine(a.ToString()));

            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}