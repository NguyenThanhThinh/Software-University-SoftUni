using System;

class DreamItem
{
    static void Main()
    {
        string input = Console.ReadLine();
        char splitSymbol = '\\';
        string[] splitedInput = input.Split(splitSymbol);

        string month = splitedInput[0];
        double moneyPerHour = double.Parse(splitedInput[1]);
        double hoursPerDay = Double.Parse(splitedInput[2]);
        double itemPrice = double.Parse(splitedInput[3]);

        double moneyEarned = 0d;

        if (month == "Feb")
        {
            moneyEarned = (28 - 10) * (moneyPerHour * hoursPerDay);
        }

        if (month == "Jan" || month == "Mar" || month == "May" || month == "July" || month == "Aug" || month == "Oct" || month == "Dec")
        {
            moneyEarned = 21 * (moneyPerHour * hoursPerDay);

        }
        else
        {
            moneyEarned += 20 * (moneyPerHour * hoursPerDay);
        }

        if (moneyEarned > 700)
        {
            moneyEarned += (moneyEarned / 100) * 10;
        }

        if (moneyEarned >= itemPrice)
        {
            Console.WriteLine("Money left = {0:F2} leva", (moneyEarned - itemPrice));
        }
        else
        {
            Console.WriteLine("Not enough money. {0:F2} leva needed.", (itemPrice - moneyEarned));
        }
    }
}