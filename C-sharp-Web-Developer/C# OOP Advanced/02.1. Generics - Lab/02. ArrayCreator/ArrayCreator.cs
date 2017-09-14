using System.Linq;

public class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        var array = Enumerable.Repeat(item, length).ToArray();
        return array;
    }
}