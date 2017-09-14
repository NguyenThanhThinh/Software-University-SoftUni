using System;
using System.Collections.Generic;

public class CalculateSequencewithQueue
{
    public static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        Queue<double> numbers = new Queue<double>();
        List<double> result = new List<double>();
        double a = n;
        double b = 0;
        double c = 0;
        double d = 0;
        result.Add(a);

        while (result.Count <= 50)
        {
            b = a + 1;
            numbers.Enqueue(b);
            result.Add(b);
            c = 2 * a + 1;
            numbers.Enqueue(c);
            result.Add(c);
            d = a + 2;
            numbers.Enqueue(d);
            result.Add(d);
            a = numbers.Dequeue();
        }
        result.RemoveAt(result.Count - 1);
        result.RemoveAt(result.Count - 1);
        Console.WriteLine(string.Join(" ", result));
    }
}