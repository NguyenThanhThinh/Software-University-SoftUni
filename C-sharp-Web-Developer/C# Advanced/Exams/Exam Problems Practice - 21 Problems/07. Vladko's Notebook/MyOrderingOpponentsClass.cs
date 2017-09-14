using System.Collections.Generic;

public class MyOrderingClass : IComparer<Opponents>
{
    public int Compare(Opponents x, Opponents y)
    {
        int compareColor = x.Color.CompareTo(y.Color);
        return compareColor;
    }
}