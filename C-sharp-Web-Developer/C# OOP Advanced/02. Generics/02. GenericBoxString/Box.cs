using System;

namespace _01.Generic_Box
{
    public class Box<T>
    {
        private T type;

        public Box(T type)
        {
            this.Type = type;
        }

        public T Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            return String.Format($"{this.Type.GetType().FullName}: {this.Type}");
        }
    }
}