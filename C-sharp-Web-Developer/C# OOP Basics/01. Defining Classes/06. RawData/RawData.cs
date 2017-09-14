using System;
using System.Collections.Generic;
using System.Linq;

public class RawData
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var carStats = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = new Engine(int.Parse(carStats[1]), int.Parse(carStats[2]));
            var cargo = new Cargo(int.Parse(carStats[3]), carStats[4]);
            var tire = new Tires();
            tire.tire.Add(double.Parse(carStats[5]), int.Parse(carStats[6]));
            tire.tire[double.Parse(carStats[7])] = int.Parse(carStats[8]);
            tire.tire[double.Parse(carStats[9])] = int.Parse(carStats[10]);
            tire.tire[double.Parse(carStats[11])] = int.Parse(carStats[12]);
            cars.Add(new Car(carStats[0], cargo, engine, tire));
        }

        var command = Console.ReadLine();

        if (command.Equals("flamable"))
        {
            //print all cars whose Cargo Type is “flamable” and have Engine Power > 250
            var result = cars.Where(c => c.cargo.type.Equals("flamable")).Where(c => c.engine.power > 250);
            foreach (Car car in result)
            {
                Console.WriteLine(car.model);
            }
        }
        else if (command.Equals("fragile"))
        {
            //print all cars whose Cargo Type is “fragile” with a tire whose pressure is  < 1
            var result = cars.Where(c => c.cargo.type.Equals("fragile")).Where(c => c.tires.tire.Any(t => t.Key < 1));
            foreach (Car car in result)
            {
                Console.WriteLine(car.model);
            }
        }
    }
}