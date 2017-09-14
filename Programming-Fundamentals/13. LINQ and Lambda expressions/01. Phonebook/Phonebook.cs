using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Phonebook
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        StringBuilder results = new StringBuilder();

        while (input[0] != "END")
        {
            if (input[0] == "A")
            {
                if (phoneBook.ContainsKey(input[1]))
                {
                    phoneBook[input[1]] = input[2];
                }
                else
                {
                    phoneBook.Add(input[1], input[2]);
                }
            }
            else if (input[0] == "S")
            {
                if (phoneBook.ContainsKey(input[1]))
                {
                    results.Append(input[1] + " -> " + phoneBook[input[1]]);
                    results.AppendLine();
                }
                else
                {
                    results.Append("Contact " + input[1] + " does not exist.");
                    results.AppendLine();
                }
            }
            input = Console.ReadLine().Split(' ').ToArray();
        }
        Console.WriteLine(results.ToString());
    }
}