using System;
using System.Text;
using System.Text.RegularExpressions;

public class CubicMessages
{
    public static void Main()
    {
        string cryptedMessage = Console.ReadLine();
        int lenght = int.Parse(Console.ReadLine());
        string pattern = @"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";
        Regex regex = new Regex(pattern);
        StringBuilder result = new StringBuilder();
        string numbers = string.Empty;
        string message = string.Empty;

        while (cryptedMessage != "Over!")
        {
            Match match = regex.Match(cryptedMessage);

            if (match.Success && match.Groups[2].Value.Length == lenght)
            {
                string lastNumbers = GetLastNumbers(match.Groups[3].Value);
                numbers = match.Groups[1].Value + lastNumbers;
                message = match.Groups[2].Value;

                result.AppendLine($"{message} == " + ReturnValidatedMessage(message, numbers));
            }

            cryptedMessage = Console.ReadLine();
            if (!cryptedMessage.Equals("Over!"))
            {
                lenght = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine(result);
    }

    private static string ReturnValidatedMessage(string message, string numbers)
    {
        StringBuilder validatedMessage = new StringBuilder();
        for (int i = 0; i < numbers.Length; i++)
        {
            int index = int.Parse(numbers[i].ToString());
            if (index >= 0 && index < message.Length)
            {
                validatedMessage.Append(message[index]);
            }
            else
            {
                validatedMessage.Append(" ");
            }
        }
        return validatedMessage.ToString();
    }

    private static string GetLastNumbers(string value)
    {
        Match match = Regex.Match(value, @"([0-9]+)");
        return match.Groups[1].Value;
    }
}