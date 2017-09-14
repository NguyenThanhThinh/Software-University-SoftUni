using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class HornetComm
{
    static void Main()
    {
        var input = Console.ReadLine();
        StringBuilder privateMessages = new StringBuilder();
        StringBuilder broadcast = new StringBuilder();
        string patternMessage = @"^([0-9]+)\s<->\s([\da-zA-Z]+)(?!.)";
        string patternBroadcast = @"^([^0-9]+)\s<->\s([\da-zA-Z]+)(?=\s|)";

        while (input != "Hornet is Green")
        {
            Regex regexMessage = new Regex(patternMessage);
            Regex regexBroadcast = new Regex(patternBroadcast);
            Match matchMessage = regexMessage.Match(input);
            Match matchBroadcast = regexBroadcast.Match(input);

            if (matchMessage.Success)
            {
                privateMessages.AppendLine(GetPrivateMessageOutput(matchMessage));

            }
            else if (matchBroadcast.Success)
            {
                broadcast.AppendLine(GetBroadcastOutput(matchBroadcast));
            }

            input = Console.ReadLine();
        }

        Console.WriteLine("Broadcasts:");
        if (broadcast.Length == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            Console.Write(broadcast);
        }
        Console.WriteLine("Messages:");
        if (privateMessages.Length == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            Console.Write(privateMessages);
        }
    }

    private static string GetBroadcastOutput(Match matchBroadcast)
    {
        string message = matchBroadcast.Groups[1].Value;
        string frequience = new string(matchBroadcast.Groups[2].Value.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                          char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
        return $"{frequience} -> {message}";
    }

    private static string GetPrivateMessageOutput(Match matchMessage)
    {
        string recipientCode = Reverse(matchMessage.Groups[1].Value);
        string message = matchMessage.Groups[2].Value;
        return $"{recipientCode} -> {message}";
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}