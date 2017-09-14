using System;
using System.Collections.Generic;

public class ParkingLot
{
    public static void Main()
    {
        var cars = new SortedSet<string>();
        var input = Console.ReadLine();

        while (!input.Equals("END"))
        {
            if (input.StartsWith("IN"))
            {
                cars.Add(input.Substring(4));
            }
            if (input.StartsWith("OUT"))
            {
                cars.RemoveWhere(c => c.Equals(input.Substring(5)));
            }

            input = Console.ReadLine();
        }

        if (cars.Count > 0)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}