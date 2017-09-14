using System;
using System.Collections.Generic;

public class CarSalesman
{
    public static void Main()
    {
        int enginesNumber = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < enginesNumber; i++)
        {
            var engineInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = new Engine(engineInput[0], double.Parse(engineInput[1]));

            if (engineInput.Length > 3)
            {
                engine.efficiency = engineInput[3];
            }
            if (engineInput.Length > 2)
            {
                if (!char.IsLetter(engineInput[2][0]))
                {
                    engine.displacement = double.Parse(engineInput[2]);
                }
                else
                {
                    engine.efficiency = engineInput[2];
                }
            }
            engines.Add(engine);
        }

        int carsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsNumber; i++)
        {
            var carsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carEngineIndex = engines.FindIndex(e => e.model.Equals(carsInput[1]));
            var car = new Car(carsInput[0], engines[carEngineIndex]);

            if (carsInput.Length > 3)
            {
                car.color = carsInput[3];
            }
            if (carsInput.Length > 2)
            {
                if (!char.IsLetter(carsInput[2][0]))
                {
                    car.weight = double.Parse(carsInput[2]);
                }
                else
                {
                    car.color = carsInput[2];
                }     
            }
            cars.Add(car);
        }

        Console.WriteLine();
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model}:");
            Console.WriteLine($"  {car.engine.model}:");
            Console.WriteLine($"    Power: {car.engine.power}");
            var displacement = car.engine.displacement != 0d ? car.engine.displacement.ToString() : "n/a";
            Console.WriteLine($"    Displacement: {displacement}");
            Console.WriteLine($"    Efficiency: {car.engine.efficiency}");
            var weight = car.weight != 0d ? car.weight.ToString() : "n/a";
            Console.WriteLine($"  Weight: {weight}");
            Console.WriteLine($"  Color: {car.color}");
        }
    }
}