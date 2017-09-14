using System.Collections.Generic;

public class ImmutableList
{
    public List<int> collection;

    public ImmutableList(List<int> collection)
    {
        this.collection = collection;
    }

    public ImmutableList GetCollection()
    {
        return new ImmutableList(this.collection);
    }
}