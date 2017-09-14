using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();
        private int currentIndex;

        public ListyIterator(List<T> list)
        {
            this.List = list;
        }

        public List<T> List
        {
            get { return list; }
            set { list = value; }
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        public bool Move()
        {
            if (this.CurrentIndex + 1 < this.List.Count)
            {
                this.CurrentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.CurrentIndex + 1 < this.List.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.List.Count > 0)
            {
                Console.WriteLine(this.List[currentIndex]);
            }
            else
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int j = 0; j < this.List.Count; j++)
            {
                yield return this.List[j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //private class ListyIteratorEnumerator : IEnumerator<T>
        //{
        //    private int currentIndex;
        //    private List<T> list;

        //    public ListyIteratorEnumerator(List<T> list)
        //    {
        //        Reset();
        //        this.list = list;
        //    }

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        return ++this.currentIndex < this.list.Count;
        //    }

        //    public void Reset()
        //    {
        //        currentIndex = -1;
        //    }

        //    public T Current
        //    {
        //        get { return this.list[currentIndex]; }
        //    }

        //    object IEnumerator.Current
        //    {
        //        get { return Current; }
        //    }
        //}

    }
}