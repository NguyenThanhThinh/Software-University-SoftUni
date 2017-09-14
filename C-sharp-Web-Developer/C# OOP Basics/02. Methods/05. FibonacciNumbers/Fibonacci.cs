using System.Collections.Generic;

public class Fibonacci
{
    private List<long> allFibNumsInRange;

    public Fibonacci(List<long> allFibNumsInRange)
    {
        this.AllFibNumsInRange = allFibNumsInRange;
    }

    public List<long> AllFibNumsInRange
    {
        get { return allFibNumsInRange; }
        set { allFibNumsInRange = value; }
    }

    public List<long> GetNumbersInRange(int startPosition, int endPosition)
    {
        var fibNumbers = new List<long>();
        allFibNumsInRange.Reverse();
        for (int i = startPosition; i < endPosition; i++)
        {
            fibNumbers.Add(allFibNumsInRange[i]);   
        }
        return fibNumbers;
    }
}