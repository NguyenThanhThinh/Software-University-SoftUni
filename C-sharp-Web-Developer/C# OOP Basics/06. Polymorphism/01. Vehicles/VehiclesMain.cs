using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VehiclesMain
{
    public static void Main()
    {
        var carInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var truckInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        double carFuel = double.Parse(carInfo[1]);
        double carConsump = double.Parse(carInfo[2]);

        double truckFuel = double.Parse(truckInfo[1]);
        double truckConsump = double.Parse(truckInfo[2]);

        List<Vihicle> vihicles = new List<Vihicle>();
        vihicles.Add(new Car(carFuel, carConsump));
        vihicles.Add(new Truck(truckFuel, truckConsump));

        var numberOfCommands = int.Parse(Console.ReadLine());
        var result = new StringBuilder(); 

        for (int i = 0; i < numberOfCommands; i++)
        {
            var fullCommand = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = fullCommand[0];
            var vihicleType = fullCommand[1];
            var distanceToTravelOrFuel = double.Parse(fullCommand[2]);

            try
            {
                switch (command)
                {
                    case "Drive":
                        if (vihicleType.Equals("Car"))
                        {
                            vihicles[0].DrivenDistance(distanceToTravelOrFuel);
                            result.AppendLine($"Car travelled {distanceToTravelOrFuel} km");
                        }
                        else
                        {
                            vihicles[1].DrivenDistance(distanceToTravelOrFuel);
                            result.AppendLine($"Truck travelled {distanceToTravelOrFuel} km");
                        }
                        break;
                    case "Refuel":
                        if (vihicleType.Equals("Car"))
                        {
                            vihicles[0].RefuelTank(distanceToTravelOrFuel);
                        }
                        else
                        {
                            vihicles[1].RefuelTank(distanceToTravelOrFuel);
                        }
                        break;
                }
            }
            catch (ArgumentException aex)
            {
                result.AppendLine(aex.Message);
            }
        }

        result.AppendLine($"Car: {vihicles[0].FuelQuantity:F2}");
        result.AppendLine($"Truck: {vihicles[1].FuelQuantity:F2}");
        Console.WriteLine($"{Environment.NewLine}{result}");
    }
}