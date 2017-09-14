using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumsFindMinMaxAverage
{
    static void Main()
    {
        List<decimal> input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
        List<int> roundNumbers = new List<int>();
        List<decimal> floatingNumbers = new List<decimal>();

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] % 1 == 0)
            {
                roundNumbers.Add((int)input[i]);
            }
            else
            {
                floatingNumbers.Add(input[i]);
            }
        }

        string roundResult = "";
        Console.Write("[");
        for (int i = 0; i < roundNumbers.Count; i++)
        {
            roundResult = string.Join(", ", roundNumbers);
            
        }
        Console.Write(roundResult);
        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}\n", roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), 
            roundNumbers.Average());

        string floatingPointRezult = "";
        Console.Write("[");
        for (int i = 0; i < floatingNumbers.Count; i++)
        {
            floatingPointRezult = string.Join(", ", floatingNumbers);
        }
        Console.Write(floatingPointRezult);
        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}\n", floatingNumbers.Min(), floatingNumbers.Max(), floatingNumbers.Sum(),
            floatingNumbers.Average());
    }
}