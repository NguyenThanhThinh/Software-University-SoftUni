using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Generic_Box
{
    public class Box<T>
    {
        private List<T> type;

        public Box()
        {
            this.Type = new List<T>();
        }

        public List<T> Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            this.Type.ForEach(t => sb.AppendLine(String.Format($"{t.GetType().FullName}: {t}")));
            return sb.ToString();
        }

        public void Swap<T>(int[] indexes)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            var firstValue = type[firstIndex];
            type[firstIndex] = type[secondIndex];
            type[secondIndex] = firstValue;
        }
    }
}