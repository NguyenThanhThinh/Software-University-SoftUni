using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class VehiclePark
{ 
    static void Main(string[] args)
    {
        var vehicle = Console.ReadLine().Split(' ').ToList();

        string command = Console.ReadLine();
        int countSoldCars = 0;
        StringBuilder result = new StringBuilder();

        while (command != "End of customers!")
        {
            var separateCommand = command.Split();
            string carType = separateCommand[0][0].ToString().ToLower();
            string numberOfSeats = separateCommand[2];
            string carForSale = carType + numberOfSeats;

            if (vehicle.Contains(carForSale))
            {
                result = (SoldCar(vehicle, carForSale, result));
                countSoldCars++;
            }
            else
            {
                result.AppendLine("No");
            }
            command = Console.ReadLine();
        }

        Console.Write(result.ToString());
        Console.WriteLine("Vehicles left: {0}", string.Join(", ", vehicle));
        Console.WriteLine("Vehicles sold: {0}", countSoldCars);
    }

    private static StringBuilder SoldCar(List<string> vehicle, string carForSale, StringBuilder result)
    {
        int price = 0;
        price = (int)carForSale[0] * int.Parse(carForSale.Substring(1, carForSale.Length - 1));

        vehicle.Remove(carForSale);
        result.AppendLine($"Yes, sold for {price}$");

        return result;
    }
}