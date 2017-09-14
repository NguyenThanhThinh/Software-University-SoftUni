using System;
using System.Collections.Generic;
using System.Linq;

public class FixEmails
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<string> inputSequence = new List<string>();
        Dictionary<string, string> peopleAndEmails = new Dictionary<string, string>();

        while (input != "stop")
        {
            inputSequence.Add(input);
            input = Console.ReadLine();
        }

        for (int i = 0; i < inputSequence.Count; i++)
        {
            if (i % 2 == 0)
            {
                peopleAndEmails.Add(inputSequence[i], "default");
            }
            else
            {
                peopleAndEmails[inputSequence[i - 1]] = inputSequence[i];
            }
        }

        var fixedPeopleAndEmails = peopleAndEmails
            .Where(n => !n.Value.ToLower().EndsWith("us") && !n.Value.ToLower().EndsWith("uk")).ToDictionary(m => m.Key, m => m.Value);

        foreach (var email in fixedPeopleAndEmails)
        {
            Console.WriteLine("{0} -> {1}", email.Key, email.Value);
        }
    }
}