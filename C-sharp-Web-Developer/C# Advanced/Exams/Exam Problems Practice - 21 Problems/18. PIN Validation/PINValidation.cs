using System;
using System.Text.RegularExpressions;

public class PINValidation
{
    private static int[] numValidators = new int[] {2, 4, 8, 5, 10, 9, 7, 3, 6};

    public static void Main()
    {
        string name = string.Empty;
        string gender = string.Empty;
        string pin = string.Empty;

        var input = Console.ReadLine();
        var namePattern = @"^[A-Z][a-zA-Z]+\s[A-Z][a-zA-Z]+";
        if (!Regex.Match(input, namePattern).Success)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        name = input;

        input = Console.ReadLine();
        var genderPattern = @"(male|female)";
        if (!Regex.Match(input, genderPattern).Success)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        gender = input;

        input = Console.ReadLine();
        var pinPattern = @"^(?=[0-9]{10})([0-9]{2})([0-9]{2})([0-9]{2})[0-9]{2}([0-9])([0-9]{1})";
        Match pinMatch = Regex.Match(input, pinPattern);

        if (pinMatch.Success)
        {
            bool validatePin = ValidateBornYear(pinMatch.Groups[1].Value, pinMatch.Groups[2].Value, pinMatch.Groups[3].Value) &&
                ValidateGender(pinMatch.Groups[4].Value, gender) &&
                ValidateCheckSum(pinMatch.Groups[5].Value, pinMatch.Groups[0].Value);

            if (!validatePin)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            pin = input;
            Console.WriteLine("{" + $@"""name"":""{name}"",""gender"":""{gender}"",""pin"":""{pin}""" + "}");
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
    }

    private static bool ValidateCheckSum(string pinLastNumber, string pinNums)
    {
        long sum = 0L;

        for (int i = 0; i < pinNums.Length - 1; i++)
        {
            sum += (long.Parse(pinNums[i].ToString()) * numValidators[i]);
        }

        long reminder = sum % 11;
        long checksum = 0;

        if (reminder != 10)
        {
            checksum = reminder;
        }

        if (checksum.ToString().Equals(pinLastNumber))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool ValidateGender(string pinGender, string inputGender)
    {
        int pinGenderInt = int.Parse(pinGender);

        if (pinGenderInt % 2 == 0)
        {
            return inputGender.Equals("male") ? true : false;
        }
        else
        {
            return inputGender.Equals("female") ? true : false;
        }
    }

    private static bool ValidateBornYear(string yearStr, string monthStr, string dateStr)
    {
        int month = int.Parse(monthStr);
        int date = int.Parse(dateStr);
        int year = FindExactYear(dateStr, month);
        month = month < 12 ? month : 12;
        int daysInMonth = DateTime.DaysInMonth(year, month);

        if (date > daysInMonth)
        {
            return false;
        }
        return true;
    }

    private static int FindExactYear(string dateStr, int month)
    {

        if (month < 20)
        {
            return int.Parse("19" + dateStr);
        }
        else if (month >= 20 && month < 40)
        {
            return int.Parse("18" + dateStr);
        }
        else if (month >= 40 && month <= 99)
        {
            return int.Parse("20" + dateStr);
        }
        return -100;
    }
}