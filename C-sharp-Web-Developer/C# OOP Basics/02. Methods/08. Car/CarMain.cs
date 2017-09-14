using System;
using System.Linq;
using System.Text;

public class CarMain
{
    public static void Main()
    {
        var carStats = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(decimal.Parse).ToArray();

        var car = new Car(carStats[0], carStats[1], carStats[2]);
        decimal distance = 0M;
        var spendTime = 1.99d;
        var result = new StringBuilder();

        var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (!command[0].Equals("END"))
        {
            if (command[0].Equals("Travel"))
            {
                decimal km = decimal.Parse(command[1]);
                Travel(car, km, ref distance, ref spendTime);
            }

            if (command[0].Equals("Distance"))
            {
                result.AppendLine($"Total distance: {distance:F1} kilometers");
            }

            if (command[0].Equals("Time"))
            {
                TimeSpan timespan = TimeSpan.FromHours(spendTime);

                result.AppendLine($"Total time: {(timespan.Days * 24) + timespan.Hours} hours and {timespan.Minutes} minutes");
            }

            if (command[0].Equals("Fuel"))
            {
                result.AppendLine($"Fuel left: {car.Fuel:F1} liters");
            }

            if (command[0].Equals("Refuel"))
            {
                car.Fuel += decimal.Parse(command[1]);
            }

            command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        Console.WriteLine(result);
    }

    private static void Travel(Car car, decimal currentKm, ref decimal distance, ref double spendTime)
    {
        decimal km = currentKm;
        decimal calculateTravelInfo = (km / car.Speed) * car.FuelEconomy;
        if (calculateTravelInfo <= car.Fuel)
        {
            distance += km;
            car.Fuel -= calculateTravelInfo;
            spendTime += (double)(km / car.Speed);
        }
        else
        {
            while (calculateTravelInfo > car.Fuel && km > 0)
            {
                km--;
                calculateTravelInfo = (km / car.Speed) * car.FuelEconomy;
            }
            if (km > 0)
            {
                distance += km;
                car.Fuel -= calculateTravelInfo;
                spendTime += (double)(km / car.Speed);
            }
        }
    }
}