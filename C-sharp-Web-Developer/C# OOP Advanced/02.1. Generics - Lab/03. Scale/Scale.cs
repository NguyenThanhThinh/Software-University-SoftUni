using System;

public class Scale<T> where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T Left
    {
        get { return left; }
        private set { left = value; }
    }

    public T Right
    {
        get { return right; }
        private set { right = value; }
    }

    public T GetHavier()
    {
        if (this.Left.CompareTo(this.Right) != 0)
        {
            return this.Left.CompareTo(this.Right) > 0 ? this.Left : this.Right;
        }

        return default(T);
    }
}