using System;
using System.Collections.Generic;

public class MatchingBrackets
{
    public static void Main()
    {
        var expretion = Console.ReadLine();
        var brackets = new Stack<int>();

        for (int i = 0; i < expretion.Length; i++)
        {
            if (expretion[i].Equals('('))
            {
                brackets.Push(i);
            }
            if (expretion[i].Equals(')'))
            {
                Console.WriteLine(expretion.Substring(brackets.Peek(), i - brackets.Pop() + 1));
            }
        }
    }
}