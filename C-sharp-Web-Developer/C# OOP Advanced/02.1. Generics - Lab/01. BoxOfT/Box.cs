using System.Collections.Generic;

public class Box<T>
{
    private List<T> collection;
    private int count;

    public Box()
    {
        this.Collection = new List<T>();
    }

    public List<T> Collection
    {
        get { return collection; }
        set { collection = value; }
    }

    public int Count
    {
        get
        {
            return this.Collection.Count;
        }
        private set { count = value; }
    }

    public void Add(T element)
    {
        this.Collection.Add(element);
    }

    public T Remove()
    {
        int topMostIndex = this.Collection.Count - 1;
        T removed = this.Collection[topMostIndex];

        this.Collection.RemoveAt(topMostIndex);

        return removed;
    }
}