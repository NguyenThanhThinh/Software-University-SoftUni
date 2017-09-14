using System;
using System.Text;

class SoftUniAirline
{
    static void Main(string[] args)
    {
        int flightsNumber = int.Parse(Console.ReadLine());

        int adultCount = 0;
        decimal adultPrice = 0M;
        int youthCount = 0;
        decimal youthPrice = 0M;
        decimal fuelPrice = 0M;
        decimal fuelConsumption = 0M;
        int flightDuration = 0;

        decimal overallProfit = 0L;

        decimal income = 0M;
        decimal expense = 0M;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < flightsNumber; i++)
        {
            adultCount = int.Parse(Console.ReadLine());
            adultPrice = decimal.Parse(Console.ReadLine());
            youthCount = int.Parse(Console.ReadLine());
            youthPrice = decimal.Parse(Console.ReadLine());
            fuelPrice = decimal.Parse(Console.ReadLine());
            fuelConsumption = decimal.Parse(Console.ReadLine());
            flightDuration = int.Parse(Console.ReadLine());

            income = CalculateCurrentFlightIncome(adultCount, adultPrice, youthCount, youthPrice);
            expense = CalculateCurrentFlightExpense(flightDuration, fuelConsumption, fuelPrice);
            decimal profit = income - expense;
            overallProfit += profit;

            if (profit >= 0)
            {
                result.AppendLine($"You are ahead with {profit:F3}$.");
            }
            else
            {
                result.AppendLine($"We've got to sell more tickets! We've lost {profit:F3}$.");
            }
        }

        result.AppendLine($"Overall profit -> {overallProfit:F3}$.");
        result.AppendLine($"Average profit -> {overallProfit / flightsNumber:F3}$.");
        Console.WriteLine(result.ToString());
    }

    private static decimal CalculateCurrentFlightExpense(int flightDuration, decimal fuelConsumption, decimal fuelPrice)
    {
        decimal expense = 0M;
        expense = flightDuration * fuelPrice * fuelConsumption;
        return expense;
    }

    private static decimal CalculateCurrentFlightIncome(int adultCount, decimal adultPrice, int youthCount, decimal youthPrice)
    {
        decimal income = 0M;
        income = (adultCount * adultPrice) + (youthCount * youthPrice);

        return income;
    }
}