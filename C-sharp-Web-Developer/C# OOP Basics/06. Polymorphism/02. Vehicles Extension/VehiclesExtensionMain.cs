using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VehiclesExtensionMain
{
    public static Car car;
    public static Bus bus;
    public static Truck truck;
    public static List<Vihicle> vihicles = new List<Vihicle>();

    public static void Main(string[] args)
    {
        string vihicleType = string.Empty;
        var result = new StringBuilder();

        for (int i = 0; i < 3; i++)
        {
            var vihicleInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            vihicleType = vihicleInfo[0];
            double vihicleFuel = double.Parse(vihicleInfo[1]);
            double vihicleConsump = double.Parse(vihicleInfo[2]);
            double vihicleTankCapacity = double.Parse(vihicleInfo[3]);

            CreateSpecificVihicle(vihicleType, vihicleFuel, vihicleConsump, vihicleTankCapacity);
        }

        var numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var fullCommand = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = fullCommand[0];
            vihicleType = fullCommand[1];
            var distanceToTravelOrFuel = double.Parse(fullCommand[2]);
            var vihicleIndex = GetVihicleIndex(vihicleType);

            try
            {
                switch (command)
                {
                    case "Drive":
                        if (vihicleType.Equals("Car"))
                        {
                            vihicles[vihicleIndex].DrivenDistance(distanceToTravelOrFuel);
                            result.AppendLine($"Car travelled {distanceToTravelOrFuel} km");
                        }
                        else if (vihicleType.Equals("Truck"))
                        {
                            vihicles[vihicleIndex].DrivenDistance(distanceToTravelOrFuel);
                            result.AppendLine($"Truck travelled {distanceToTravelOrFuel} km");
                        }
                        else
                        {
                            vihicles[vihicleIndex].IncreaseOfConsumption();
                            vihicles[vihicleIndex].Empty = true;
                            vihicles[vihicleIndex].DrivenDistance(distanceToTravelOrFuel);
                            result.AppendLine($"Bus travelled {distanceToTravelOrFuel} km");
                        }
                        break;
                    case "Refuel":
                        if (vihicleType.Equals("Car"))
                        {
                            vihicles[vihicleIndex].RefuelTank(distanceToTravelOrFuel);
                        }
                        else if (vihicleType.Equals("Truck"))
                        {
                            vihicles[vihicleIndex].RefuelTank(distanceToTravelOrFuel);
                        }
                        else
                        {
                            vihicles[vihicleIndex].RefuelTank(distanceToTravelOrFuel);
                        }
                        break;
                    case "DriveEmpty":
                        vihicles[vihicleIndex].DrivenDistance(distanceToTravelOrFuel);
                        result.AppendLine($"Bus travelled {distanceToTravelOrFuel} km");
                        break;
                }
            }
            catch (ArgumentException aex)
            {
                result.AppendLine(aex.Message);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            result.AppendLine($"{vihicles[i].GetType().FullName}: {vihicles[i].FuelQuantity:F2}");
        }
        Console.WriteLine($"{Environment.NewLine}{result}");
    }

    private static int GetVihicleIndex(string vihicleType)
    {
        int index = -1;
        index = vihicles.FindIndex(v => v.GetType().FullName.Equals(vihicleType));
        return index;
    }

    private static void CreateSpecificVihicle(string vihicleType, double vihicleFuel, double vihicleConsump, double vihicleTankCapacity)
    {
        switch (vihicleType)
        {
            case "Car":
                car = new Car(vihicleFuel, vihicleConsump, vihicleTankCapacity);
                vihicles.Add(car);
                break;
            case "Bus":
                bus = new Bus(vihicleFuel, vihicleConsump, vihicleTankCapacity);
                vihicles.Add(bus);
                break;
            case "Truck":
                truck = new Truck(vihicleFuel, vihicleConsump, vihicleTankCapacity);
                vihicles.Add(truck);
                break;
        }
    }
}