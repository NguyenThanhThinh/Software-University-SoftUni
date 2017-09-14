using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class FixEmails
{
    static void Main()
    {
        var input = File.ReadAllLines(@"../../input.txt");
        List<string> inputSequence = new List<string>();
        Dictionary<string, string> peopleAndEmails = new Dictionary<string, string>();

        for (int x = 0; x < input.Length; x++)
        {
            var currentLine = input[x];

            if (currentLine != "stop")
            {
                inputSequence.Add(currentLine);
            }
            else
            {
                break;
            }
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
            File.AppendAllText(@"../../output.txt", email.Key + " -> " + email.Value + Environment.NewLine);
        }
    }
}