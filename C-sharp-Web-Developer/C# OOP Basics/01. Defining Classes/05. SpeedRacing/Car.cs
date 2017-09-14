using System;

public class Car
{
    public string model;
    public double fuel;
    public double amountOfKm;
    public double fuelCostPerKm;
    public double distanceTraveled;

    public Car(string model, double fuel, double fuelCostPerKm)
    {
        this.model = model;
        this.fuel = fuel;
        this.fuelCostPerKm = fuelCostPerKm;
    }

    public void CalculateCarsTravels(double amountOfKm)
    {
        var fuelNeeded = amountOfKm * fuelCostPerKm;

        if (fuelNeeded <= fuel)
        {
            this.fuel -= fuelNeeded;
            this.distanceTraveled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
