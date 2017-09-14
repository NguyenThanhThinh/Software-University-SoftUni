public class Bus : Vihicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void IncreaseOfConsumption()
    {
        FuelConsumption += 1.4d;
    }

    public void DecreaseOfConsumption()
    {
        FuelConsumption -= 1.4d;
    }

    public override void RefuelTank(double fuel)
    {
        FuelQuantity += fuel;
    }
}