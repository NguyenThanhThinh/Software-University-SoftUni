using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PhoneBook
{
    public static void Main()
    {
        var phonebook = new Dictionary<string, string>();
        var input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var result = new StringBuilder();

        while (input[0] != "search")
        {
            string name = input[0];
            string number = input[1];
            phonebook[name] = number;
            input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        var secondInput = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        while (!secondInput[0].ToLower().Equals("stop"))
        {
            if (phonebook.ContainsKey(secondInput[0]))
            {
                result.AppendLine($"{secondInput[0]} -> {phonebook[secondInput[0]]}");
            }
            else
            {
                result.AppendLine($"Contact {secondInput[0]} does not exist.");
            }
            secondInput = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
        Console.WriteLine(result.ToString());
    }
}