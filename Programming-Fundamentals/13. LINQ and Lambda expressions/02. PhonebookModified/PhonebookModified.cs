using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PhonebookModified
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();
        SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();
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
            else if (input[0] == "ListAll")
            {
                foreach (var contact in phoneBook)
                {
                    results.Append(contact.Key + " -> " + contact.Value);
                    results.AppendLine();
                }
            }
            input = Console.ReadLine().Split(' ').ToArray();
        }
        Console.WriteLine(results.ToString());
    }
}