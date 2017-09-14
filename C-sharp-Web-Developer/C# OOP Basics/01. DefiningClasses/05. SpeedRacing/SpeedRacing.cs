using System;
using System.Collections.Generic;

public class SpeedRacing
{
    public static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var carStats = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            cars.Add(new Car(carStats[0], double.Parse(carStats[1]), double.Parse(carStats[2])));
        }

        var carTravel = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (!carTravel[0].Equals("End"))
        {
            var carIndex = cars.FindIndex(c => c.model.Equals(carTravel[1]));
            cars[carIndex].CalculateCarsTravels(double.Parse(carTravel[2]));

            carTravel = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model} {car.fuel:F2} {car.distanceTraveled}");
        }
    }
}