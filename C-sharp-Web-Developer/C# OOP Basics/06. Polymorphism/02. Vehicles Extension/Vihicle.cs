using System;

public abstract class Vihicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    private bool empty;

    public Vihicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public virtual double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (value > TankCapacity && GetType().FullName != "Truck")
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            fuelQuantity = value;
        }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public double TankCapacity
    {
        get { return tankCapacity; }
        set { tankCapacity = value; }
    }

    public bool Empty
    {
        get { return empty; }
        set { empty = value; }
    }

    public abstract void IncreaseOfConsumption();

    public virtual void DrivenDistance(double distance)
    {
        double neededFuel = distance * fuelConsumption;

        if (neededFuel > fuelQuantity)
        {
            throw new ArgumentException($"{GetType().FullName} needs refueling");
        }
        else
        {
            fuelQuantity -= neededFuel;
        }

        if (empty)
        {
            fuelConsumption -= 1.4;
            empty = false;
        }
    }

    public abstract void RefuelTank(double fuel);
}