using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class CubicsMessages
{
    static void Main()
    {
        var message = Console.ReadLine();
        var verificationCode = new List<int>();
        StringBuilder result = new StringBuilder();

        while (message != "Over!")
        {
            var length = int.Parse(Console.ReadLine());
            string pattern = @"^\d+([a-zA-Z]+)([^a-zA-Z\s\t]+)?(?=\s|$)";
            Regex regex = new Regex(pattern);
            Match singleMatch = regex.Match(message);

            if (singleMatch.Success && singleMatch.Groups[1].Value.Length == length)
            {
                var matchedMessage = singleMatch.Groups[1].Value;
                regex = new Regex(@"\d");
                MatchCollection digits = regex.Matches(message);

                foreach (Match digit in digits)
                {
                    verificationCode.Add(int.Parse(digit.Value));
                }

                string code = GetVerificationCode(matchedMessage, verificationCode);
                result.AppendLine($"{matchedMessage} == {code}");
            }
            message = Console.ReadLine();
            verificationCode.Clear();
        }

        Console.WriteLine();
        Console.Write(result);
    }

    private static string GetVerificationCode(string matchedMessage, List<int> verificationCode)
    {
        StringBuilder code = new StringBuilder();
        for (int i = 0; i < verificationCode.Count; i++)
        {
            int index = verificationCode[i];
            if (index < matchedMessage.Length)
            {
                code.Append(matchedMessage[index]);
            }
            else
            {
                code.Append(" ");
            }
        }

        return code.ToString();
    }
}