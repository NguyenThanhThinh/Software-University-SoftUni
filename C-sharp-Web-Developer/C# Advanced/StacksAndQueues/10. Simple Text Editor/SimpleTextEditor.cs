using System;
using System.Collections.Generic;
using System.Text;

public class SimpleTextEditor
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<char> text = new Stack<char>();
        Stack<char[]> backUpText = new Stack<char[]>();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var command = 0;
            var commandArgument = string.Empty;
            command = int.Parse(input[0]);

            if (input.Length > 1)
            {
                commandArgument = input[1];
            }

            switch (command)
            {
                case 1:
                    AppendsText(commandArgument, text, backUpText);
                    break;
                case 2:
                    EraseLastCountElementsFromText(commandArgument, text, backUpText);
                    break;
                case 3:
                    ReturnsSpecificIndexElement(commandArgument, text, result);
                    break;
                case 4:
                    UndoLastOperation(text, backUpText);
                    break;
            }
        }
        Console.Write(result.ToString());
    }

    private static void UndoLastOperation(Stack<char> text, Stack<char[]> backUpText)
    {
        text.Clear();
        backUpText.Pop();
        var back = backUpText.Peek();
        for (int i = back.Length - 1; i >= 0; i--)
        {
            text.Push(back[i]);
        }
    }

    private static void ReturnsSpecificIndexElement(string commandArgument, Stack<char> text, StringBuilder result)
    {
        var index = text.Count - int.Parse(commandArgument);
        result.AppendLine(text.ToArray()[index].ToString());
    }

    private static void EraseLastCountElementsFromText(string commandArgument, Stack<char> text, Stack<char[]> backUpText)
    {
        for (int i = 0; i < int.Parse(commandArgument); i++)
        {
            text.Pop();
        }
        var erased = new char[text.Count];
        text.CopyTo(erased, 0);
        backUpText.Push(erased);
    }

    private static void AppendsText(string commandArgument, Stack<char> text, Stack<char[]> backUpText)
    {
        for (int i = 0; i < commandArgument.Length; i++)
        {
            text.Push(commandArgument[i]);
        }

        var appendNewText = new char[text.Count];
        text.CopyTo(appendNewText, 0);
        backUpText.Push(appendNewText);
    }
}