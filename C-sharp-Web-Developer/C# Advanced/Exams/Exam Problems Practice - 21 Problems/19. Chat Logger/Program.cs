using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    private static char[] invalidChars = new char[] { '<', '>', '&', '\"', '\'' };

    public static void Main()
    {
        var input = Console.ReadLine();
        var currentDate = GetDate(input);
        var correspondence = new SortedDictionary<DateTime, string>();

        var message = string.Empty;
        var messageDateTime = new DateTime();

        input = Console.ReadLine();

        while (!input.Equals("END"))
        {
            var splitInput = Regex.Split(input, @"(.+\s)\/(\s.+)");
            message = SecureElements(splitInput[1].Trim());
            messageDateTime = GetDate(splitInput[2].Trim());

            correspondence[messageDateTime] = message;
            input = Console.ReadLine();
        }

        Print(correspondence, currentDate);
    }

    private static string SecureElements(string message)
    {
        var securedMessage = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            if (invalidChars.Contains(message[i]))
            {
                string xmlText = SecurityElement.Escape(message[i].ToString());
                securedMessage.Append(xmlText);
            }
            else
            {
                securedMessage.Append(message[i]);
            }
        }
        return securedMessage.ToString();
    }

    private static void Print(SortedDictionary<DateTime, string> correspondence, DateTime currentDate)
    {
        var lastDateTime = new DateTime();
        foreach (var message in correspondence)
        {
            Console.WriteLine($"<div>{message.Value}</div>");
            lastDateTime = message.Key;
        }
        PrintTimestampOfLastMessage(lastDateTime, currentDate);
    }

    private static void PrintTimestampOfLastMessage(DateTime lastDateTime, DateTime currentDate)
    {
        var timeDifference = currentDate.Subtract(lastDateTime);

        if (timeDifference.TotalMinutes < 1 && lastDateTime.Day.Equals(currentDate.Day))
        {
            Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
        }
        else if (timeDifference.TotalHours < 1 && lastDateTime.Day.Equals(currentDate.Day))
        {
            Console.WriteLine($"<p>Last active: <time>{timeDifference.Minutes:0.#} minute(s) ago</time></p>");
        }
        else if (timeDifference.TotalHours < 24 && lastDateTime.Day.Equals(currentDate.Day))
        {
            Console.WriteLine($"<p>Last active: <time>{timeDifference.Hours:0.#} hour(s) ago</time></p>");
        }
        else if (lastDateTime.AddDays(1.0).Day.Equals(currentDate.Day))
        {
            Console.WriteLine($"<p>Last active: <time>yesterday</time></p>");
        }
        else if (timeDifference.TotalDays > 1)
        {
            Console.WriteLine($"<p>Last active: <time>{lastDateTime.ToString("dd-MM-yyyy")}</time></p>");
        }
    }

    private static DateTime GetDate(string input)
    {
        var inputDateAndTime = input.Split();
        var splitDate = inputDateAndTime[0].Split('-');
        var splitTime = inputDateAndTime[1].Split(':');
        int day = int.Parse(splitDate[0]);
        int month = int.Parse(splitDate[1]);
        int year = int.Parse(splitDate[2]);
        int hours = int.Parse(splitTime[0]);
        int minutes = int.Parse(splitTime[1]);
        int second = int.Parse(splitTime[2]);

        return new DateTime(year, month, day, hours, minutes, second);
    }
}