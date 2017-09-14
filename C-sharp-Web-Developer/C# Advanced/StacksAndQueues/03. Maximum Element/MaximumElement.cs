using System;
using System.Collections.Generic;
using System.Text;

public class MaximumElement
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> numbers = new Stack<int>();
        Stack<int> maxNumbers = new Stack<int>();
        StringBuilder result = new StringBuilder();
        int num = 0;
        int max = 0;

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            if (input.Length == 1)
            {
                if (input[0].Equals("2"))
                {
                    int elementAtTop = numbers.Pop();
                    int currentMaxNumber = maxNumbers.Peek();
                    if (elementAtTop == currentMaxNumber)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count > 0)
                        {
                            max = maxNumbers.Peek();
                        }
                        else
                        {
                            max = int.MinValue;
                        }
                    }
                }
                else
                {
                    result.AppendLine(maxNumbers.Peek().ToString());
                }
            }
            else
            {
                num = int.Parse(input[1]);
                numbers.Push(num);
                if (num >= max)
                {
                    max = num;
                    maxNumbers.Push(max);
                }
            }
        }
        Console.Write(result.ToString());
    }
}