using System;

public abstract class Vihicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Vihicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    protected abstract void IncreaseOfConsumption();

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
    }

    public abstract void RefuelTank(double fuel);
}