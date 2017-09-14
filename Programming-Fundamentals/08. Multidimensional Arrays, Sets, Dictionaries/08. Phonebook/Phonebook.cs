using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        string input = Console.ReadLine();
        string[] separetor = new string[2];
        List<string> output = new List<string>();

        while (input != "search")
        {
            separetor = input.Split('-');
            if (phonebook.ContainsKey(separetor[0]) == true)
            {
                phonebook[separetor[0]].Add(separetor[1]);
            }
            else
            {
                phonebook.Add(separetor[0], new List<string>());
                phonebook[separetor[0]].Add(separetor[1]);
            }
            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "")
        {
            if (phonebook.ContainsKey(input) == false)
            {
                Console.WriteLine("\nContact {0} doesn not exist.\n", input);
            }
            else
            {
                output = phonebook[input];
                Console.Write("\n{0} -> ", input);
                for (int i = 0; i < output.Count; i++)
                {
                    if (i > 0)
                    {
                        Console.WriteLine("{0}\n".PadLeft(input.Length + 7), output[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0}\n", output[i]);
                    }
                }
            }
            input = Console.ReadLine();
        }
    }
}