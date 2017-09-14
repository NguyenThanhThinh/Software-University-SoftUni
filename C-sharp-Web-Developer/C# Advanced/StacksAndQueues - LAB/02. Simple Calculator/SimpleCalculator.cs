using System;
using System.Collections.Generic;
using System.Linq;

public class SimpleCalculator
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var elements = new Stack<string>(input.Reverse());

        while (elements.Count > 1)
        {
            var firstNum = int.Parse(elements.Pop());
            var sign = elements.Pop();
            var secondNum = int.Parse(elements.Pop());
            elements.Push(sign.Equals("+") ? (firstNum + secondNum).ToString() : (firstNum - secondNum).ToString());
        }

        Console.WriteLine(elements.Pop());
    }
}